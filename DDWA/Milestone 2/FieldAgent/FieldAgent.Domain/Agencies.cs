using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FieldAgent.Models
{
    public enum Agencies
    {
        CIA,
        FBI,
        NSA,
        [Description("Homeland Security")]
        HomelandSecurity,
        [Description("DefenseIntelligenceAgency")]
        DefenseIntelligenceAgency,
        SouthernReach,
        CONTROL,
        ODIN,
        SpecialForces

    }
}