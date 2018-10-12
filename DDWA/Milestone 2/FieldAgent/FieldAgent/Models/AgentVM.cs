using FieldAgent.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FieldAgent.Models
{
    public class AgentVM
    {
        public Agent Agent { get; set; } = new Agent();
        public IEnumerable<Alias> Aliases { get; set; }
        public List<int> SelectedAliasIds { get; set; } = new List<int>();
        public IEnumerable<SelectListItem> Agencies { get { return ListOfAgency(); } }
        public IEnumerable<SelectListItem> Clearances { get { return ListOfClearance(); } }

        public bool HasAlias(int aliasId)
        {
            return Agent.Aliases.Any(a => a.Id == aliasId);
        }

        public void SynchToSelectedAliasIds()
        {
            SelectedAliasIds.AddRange(Agent.Aliases.Select(a => a.Id));
        }

        public void SynchToAgentAliases()
        {
            foreach (var id in SelectedAliasIds)
            {
                Agent.Aliases.Add(Aliases.FirstOrDefault(a => a.Id == id));
            }
        }

        private IEnumerable<SelectListItem> ListOfAgency()
        {
            List<SelectListItem> agencies = new List<SelectListItem>();
            agencies.Add(new SelectListItem { Text = "--Select One--", Value = "" });
            agencies.Add(new SelectListItem { Text = "CIA" });
            agencies.Add(new SelectListItem { Text = "FBI" });
            agencies.Add(new SelectListItem { Text = "NSA" });
            agencies.Add(new SelectListItem { Text = "Homeland Security" });
            agencies.Add(new SelectListItem { Text = "Defense Intelligence Agency" });
            agencies.Add(new SelectListItem { Text = "Southern Reach" });
            agencies.Add(new SelectListItem { Text = "CONTROL" });
            agencies.Add(new SelectListItem { Text = "ODIN" });
            agencies.Add(new SelectListItem { Text = "Special Forces" });

            return agencies;
        }

        private IEnumerable<SelectListItem> ListOfClearance()
        {
            List<SelectListItem> securities = new List<SelectListItem>();
            securities.Add(new SelectListItem { Text = "--Select One--", Value = "" });
            securities.Add(new SelectListItem { Text = "Confidential" });
            securities.Add(new SelectListItem { Text = "Secret" });
            securities.Add(new SelectListItem { Text = "Top Secret" });
            securities.Add(new SelectListItem { Text = "Dark Matter" });

            return securities;
        }

    }
}