using FieldAgent.Domain.Repositories;
using FieldAgent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.Domain
{
    public class Service
    {
        IFieldAgentRepository agentRepo;
        IAssignmentRepository assignRepo;
        public Service(IFieldAgentRepository agentRepo, IAssignmentRepository assignRepo)
        {
            this.agentRepo = agentRepo;
            this.assignRepo = assignRepo;
        }
        public List<Agent> AllAgent()
        {
            var allAgents = agentRepo.All();
            var allAssign = assignRepo.All();
            foreach (var a in allAgents)
            {
                a.Assignments = allAssign.Where(assign => assign.Identifier == a.Identifier).ToList();
            }
            return allAgents.ToList();
        }

        public Result<Agent> AddAgent(Agent agent)
        {
            var result = validateAgent(agent);
            if (result.Success)
            {
                agentRepo.Add(agent);
                result.Payload = agent;
            }
            return result;
        }

        public Agent FindAgentById(string id)
        {
            var agent = agentRepo.FindByIdentifier(id);
            var allAssign = assignRepo.All();
            if (allAssign != null)
            {
                agent.Assignments = allAssign.Where(assign => assign.Identifier == agent.Identifier).ToList();
            }
            return agent;
        }
        public Result<Assignment> FindAssignmentById(string identifier, int assignmentIdentifier)
        {
            Result<Assignment> result = new Result<Assignment>();
            var assign = assignRepo.FindAssignmentByID(identifier, assignmentIdentifier);
            if (assign == null)
            {
                result.Success = false;
                result.AddMessage("Assignment could not be found");
                return result;
            }
            result.Success = true;
            result.Payload = assign;
            return result;
        }

        public Result<Assignment> AddAssign(Assignment assignment)
        {
            var result = ValidateAssignment(assignment);

            if (result.Success)
            {
                assignRepo.AddAssign(assignment);
            }
            return result;
        }
        public Result<Assignment> EditAssign(Assignment assignment, string oldIdentifier)
        {
            var result = ValidateAssignment(assignment, true);
            var allAssignments = assignRepo.FindAssignmentsById(oldIdentifier);
            if (result.Success)
            {
                if (assignment.Identifier != oldIdentifier)
                {
                    assignRepo.DeleteAssign(assignRepo.FindAssignmentByID(oldIdentifier, assignment.AssignmentIdentifier));
                    var newIdAssignments = assignRepo.FindAssignmentsById(assignment.Identifier);
                    if (newIdAssignments != null)
                    {
                        assignment.AssignmentIdentifier = newIdAssignments.Count() + 1;
                    }
                    else
                    {
                        assignment.AssignmentIdentifier = 1;

                    }
                    result = ValidateAssignment(assignment);
                    if (!result.Success)
                    {
                        assignRepo.AddAssign(assignment);
                        return result;
                    }
                }


                assignRepo.EditAssign(assignment);

            }

            return result;
        }
        public void DeleteAssign(Assignment assignment)
        {
            assignment = assignRepo.FindAssignmentByID(assignment.Identifier, assignment.AssignmentIdentifier);
            assignRepo.DeleteAssign(assignment);
        }

        public Result<Agent> EditAgent(Agent agent, string currentIdentifier)
        {
            var result = validateAgent(agent, currentIdentifier);

            if (result.Success)
            {
                agentRepo.Edit(agent, currentIdentifier);
                var currAgentAssignments = assignRepo.FindAssignmentsById(currentIdentifier);
                if (currAgentAssignments != null)
                {
                    foreach (var a in currAgentAssignments)
                    {
                        a.Identifier = agent.Identifier;
                        EditAssign(a, currentIdentifier);
                    }
                }
               
                
                
            }
            return result;
        }

        public void DeleteAgent(Agent agent)
        {
            var assignments = assignRepo.FindAssignmentsById(agent.Identifier);
            if (assignments != null)
            {
                assignRepo.DeleteAllAssign(agent.Identifier);
            }
            agentRepo.Delete(agent);
        }

        private Result<Agent> validateAgent(Agent agent, string currentIdentifier = null)
        {
            var result = new Result<Agent>();
            var minBirth = DateTime.Parse("1/1/1900 ");
            var maxBirth = DateTime.Now.AddYears(-10);
            var allAgents = agentRepo.All();
            result.Success = true;

            if (agent.BirthDate < minBirth || agent.BirthDate > maxBirth)
            {
                result.Success = false;
                result.AddMessage($"Birth date has to be between {minBirth.ToString("MM/dd/yyyy")} - {maxBirth.ToString("MM/dd/yyyy")}");
            }
            if (string.IsNullOrWhiteSpace(agent.FirstName) || string.IsNullOrWhiteSpace(agent.LastName))
            {
                result.Success = false;
                result.AddMessage("First and Last Name is required.");
            }
            if (agent.Height < 36 || agent.Height > 96)
            {
                result.Success = false;
                result.AddMessage("Height has to be between 36 - 96");
            }
            if (currentIdentifier == null)
            {
                if (allAgents.FirstOrDefault(a => a.Identifier == agent.Identifier) != null)
                {
                    result.Success = false;
                    result.AddMessage("Identifier needs to be unique. " + agent.Identifier + " is already taken.");
                }
            }
            else
            {
                if (currentIdentifier != agent.Identifier)
                {
                    var exist = allAgents.FirstOrDefault(a => a.Identifier == agent.Identifier);
                    if (exist != null)
                    {
                        result.Success = false;
                        result.AddMessage("Identifier needs to be unique. " + agent.Identifier + " is already taken.");
                    }
                }
            }
            if (string.IsNullOrWhiteSpace(agent.Agency))
            {
                result.Success = false;
                result.AddMessage("Agency is required");
            }
            if (string.IsNullOrWhiteSpace(agent.SecurityClearance))
            {
                result.Success = false;
                result.AddMessage("Security Clearance is required");
            }

            result.Payload = agent;

            return result;
        }

        private Result<Assignment> ValidateAssignment(Assignment assignment, bool edit = false)
        {
            var result = new Result<Assignment>();
            var allAssignments = assignRepo.FindAssignmentsById(assignment.Identifier);
            result.Success = true;

            if (string.IsNullOrWhiteSpace(assignment.Identifier))
            {
                result.Success = false;
                result.AddMessage("Identifier is required");
            }
            if (string.IsNullOrWhiteSpace(assignment.CountryCode))
            {
                result.Success = false;
                result.AddMessage("Country Code is required.");
            }

            if (assignment.ProjectedEndDate < assignment.StartDate || assignment.ActualEndDate < assignment.StartDate)
            {
                result.Success = false;
                result.AddMessage("Start Date needs to be before End Dates. And Projected and Actual End Date needs to be after Start Date ");
            }
            if (edit == false)
            {
                if (allAssignments != null)
                {


                    if (allAssignments.Select(a => a.StartDate).Contains(assignment.StartDate))
                    {
                        result.Success = false;
                        result.AddMessage("There is already another assignment with the same start date.");
                    }
                }

            }

            result.Payload = assignment;

            return result;
        }
    }
}
