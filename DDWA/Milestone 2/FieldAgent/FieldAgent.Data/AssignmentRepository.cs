using FieldAgent.Domain;
using FieldAgent.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FieldAgent.Data
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private static string filePath = @"C:/Test/assignments.txt";
        private static string filePathSeed = @"C:/Test/assignmentsSeed.txt";
        static AssignmentRepository()
        {
            //Files should be in the root of the project, may need to move them to the specified path
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            File.Copy(filePathSeed, filePath);
        }
        //private static List<Assignment> assignments = new List<Assignment>();


        //static AssignmentRepository()
        //{
        //    assignments.Add(new Assignment {
        //        Identifier = "SC-123-REX9",
        //        CountryCode = "ERI",
        //        StartDate = DateTime.Parse("04/12/2002"),
        //        ProjectedEndDate = DateTime.Parse("08/21/2002"),
        //        ActualEndDate = DateTime.Parse("10/1/2003"),
        //        Notes = "Boat Arrival.\nMeet local contact and exchange objectives.\nBlend in.",
        //        AssignmentIdentifier = 1
        //    });
        //}

        public IEnumerable<Assignment> All()
        {
            List<Assignment> assignments = new List<Assignment>();

            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] columns = line.Split(',');
                        if (columns.Length == 7)
                        {

                            assignments.Add(new Assignment
                            {
                                Identifier = columns[0],
                                CountryCode = columns[1],
                                StartDate = DateTime.Parse(columns[2]),
                                ProjectedEndDate = DateTime.Parse(columns[3]),
                                ActualEndDate = DateTime.Parse(columns[4]),
                                Notes = columns[5],
                                AssignmentIdentifier = int.Parse(columns[6])
                                
                            });
                        }
                    }
                }
                return assignments;
            }
            return null;
        }

        public void AddAssign(Assignment assignment)
        {
            var assignments = All().ToList();
            var exist = FindAssignmentsById(assignment.Identifier);
            if (exist == null)
            {
                assignment.AssignmentIdentifier = 1;
            }
            else
            {
                assignment.AssignmentIdentifier = exist.Count() + 1;
            }
            assignments.Add(assignment);
            WriteAll(assignments);
        }

        public void DeleteAllAssign(string identifier)
        {
            var newAssignments = All().ToList();
            newAssignments.RemoveAll(a=>a.Identifier == identifier);
            WriteAll(newAssignments);
        }
        public Assignment FindAssignmentByID(string identifier, int assignmentIdentifier)
        {
            var assignments = All().ToList();
            return assignments.FirstOrDefault(a=>a.Identifier == identifier && a.AssignmentIdentifier == assignmentIdentifier);
        }

        public List<Assignment> FindAssignmentsById(string identifier)
        {
            var assignments = All().ToList();
            var listOfAssignments = assignments.Where(a => a.Identifier == identifier);
            if(listOfAssignments.Any())
            {
                return listOfAssignments.ToList();
            }
            return null;
        }
        public void DeleteAssign(Assignment assignment)
        {
            var assignments = All().ToList();
            foreach (var a in assignments)
            {
                if (assignment.Identifier == a.Identifier && assignment.AssignmentIdentifier == a.AssignmentIdentifier)
                {
                    assignment = a;
                }
            }
            assignments.Remove(assignment);
            WriteAll(assignments);
        }

        public void EditAssign(Assignment assignment)
        {
            
            var oldAssignment = FindAssignmentByID(assignment.Identifier, assignment.AssignmentIdentifier);
            if (oldAssignment != null)
            {
                DeleteAssign(oldAssignment);
            }
            
            var assignments = All().ToList();
            assignments.Add(assignment);
            WriteAll(assignments);
        }

        private void WriteAll(List<Assignment> assignments)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {

                foreach (var a in assignments)
                {
                    sw.WriteLine($"{a.Identifier}," +
                        $"{a.CountryCode}," +
                        $"{a.StartDate}," +
                        $"{a.ProjectedEndDate}," +
                        $"{a.ActualEndDate}," +
                        $"{a.Notes}," +
                        $"{a.AssignmentIdentifier}" );
                }

            }
        }
    }
}