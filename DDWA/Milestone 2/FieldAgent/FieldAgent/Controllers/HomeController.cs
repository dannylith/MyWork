using FieldAgent.Data;
using FieldAgent.Domain;
using FieldAgent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FieldAgent.Controllers
{
    public class HomeController : Controller
    {

        private Service service;

        public HomeController(Service service)
        {
            this.service = service;
        }
        // GET: Home
        public ActionResult Index()
        {
            
            return View(service.AllAgent());
        }

        public ActionResult AddAgent()
        {
            var agentVM = new AgentVM();
            agentVM.Aliases = Alias.All();
            return View(agentVM);
        }
        [HttpPost]
        public ActionResult AddAgent(AgentVM agentVM)
        {
            agentVM.Aliases = Alias.All();
            agentVM.SynchToAgentAliases();
            if (!ModelState.IsValid)
            {
                return View(agentVM);
            }
            var result = service.AddAgent(agentVM.Agent);
            if (!result.Success)
            {
                foreach (var e in result.Messages)
                {
                    ModelState.AddModelError("", e);
                }
                return View(agentVM);
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditAgent(string identifier)
        {
            var agentVM = new AgentVM();
            agentVM.Agent = service.FindAgentById(identifier);
            ViewBag.countries = GetCountries();
            agentVM.Aliases = Alias.All();
            agentVM.SynchToAgentAliases();
            agentVM.SynchToSelectedAliasIds();
            return View(agentVM);
        }

        [HttpPost]
        public ActionResult EditAgent(AgentVM agentVM, string currentIdentifier)
        {
            agentVM.Aliases = Alias.All();
            agentVM.SynchToAgentAliases();
            agentVM.SynchToSelectedAliasIds();
            if (!ModelState.IsValid)
            {
                return View(agentVM);
            }
            var result = service.EditAgent(agentVM.Agent, currentIdentifier);
            if (!result.Success)
            {
                foreach (var e in result.Messages)
                {
                    ModelState.AddModelError("", e);
                }
                agentVM.Agent = result.Payload;
                return View(agentVM);
            }
            return RedirectToAction("Index");
        }

        public ActionResult AddAssignment(string identifier)
        {
            ViewBag.AllAgents = service.AllAgent().Select(a=>new SelectListItem { Text=$"{a.FirstName} {a.MiddleName} {a.LastName}", Value=a.Identifier});
            ViewBag.countries = GetCountries();
            var assign = new Assignment();
            return View(assign);
        }
        [HttpPost]
        public ActionResult AddAssignment(Assignment assignment)
        {
            ViewBag.AllAgents = service.AllAgent().Select(a => new SelectListItem { Text = $"{a.FirstName} {a.MiddleName} {a.LastName}", Value = a.Identifier });
            ViewBag.countries = GetCountries();
            if (!ModelState.IsValid)
            {
                return View(assignment);
            }
            var result = service.AddAssign(assignment);

            if (!result.Success)
            {
                foreach (var e in result.Messages)
                {
                    ModelState.AddModelError("", e);
                }
                return View(result.Payload);
                
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult EditAssignment(string identifier, string assignmentIdentifier)
        {
            ViewBag.AllAgents = service.AllAgent().Select(a => new SelectListItem { Text = $"{a.FirstName} {a.MiddleName} {a.LastName}", Value = a.Identifier });
            ViewBag.countries = GetCountries();
            var result = service.FindAssignmentById(identifier, int.Parse(assignmentIdentifier));
            if (!result.Success)
            {
                foreach (var m in result.Messages)
                {
                    ModelState.AddModelError("", m);
                }
                return Content("Assignment Not Found.");
            }
            return View(result.Payload);
        }
        [HttpPost]
        public ActionResult EditAssignment(Assignment assignment, string oldIdentifier)
        {
            ViewBag.AllAgents = service.AllAgent().Select(a => new SelectListItem { Text = $"{a.FirstName} {a.MiddleName} {a.LastName}", Value = a.Identifier });
            ViewBag.countries = GetCountries();
            var result = service.EditAssign(assignment, oldIdentifier);
            if (!result.Success)
            {
                foreach (var e in result.Messages)
                {
                    ModelState.AddModelError("", e);
                }
                return View(result.Payload);
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAgent(string identifier)
        {
            var agent = service.FindAgentById(identifier);
            return View(agent);
            
        }

        [HttpPost]
        public ActionResult DeleteAgent(Agent agent)
        {
            agent = service.FindAgentById(agent.Identifier);
            service.DeleteAgent(agent);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAssignment(string identifier, string assignmentIdentifier)
        {
            var result = service.FindAssignmentById(identifier, int.Parse(assignmentIdentifier));
            ViewBag.countries = GetCountries();
            return View(result.Payload);
        }

        [HttpPost]
        public ActionResult DeleteAssignment(Assignment assignment)
        {
            var result = service.FindAssignmentById(assignment.Identifier, assignment.AssignmentIdentifier);
            service.DeleteAssign(result.Payload);
            ViewBag.countries = GetCountries();
            return RedirectToAction("Index");
        }


        private Dictionary<string, string> GetCountries()
        {
            Dictionary<string, string> countries = new Dictionary<string, string>();
            countries.Add("ALB", "Albania");
            countries.Add("AUS", "Australia");
            countries.Add("ECU", "Ecuador");
            countries.Add("ERI", "Eritrea");
            return countries;

        }
    }
}