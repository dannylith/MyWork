using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.Domain
{
    public class Assignment
    {
        [Required]
        public string Identifier { get; set; }
        [Required]
        [DisplayName("Country Code:")]
        public string CountryCode { get; set; }
        [Required]
        [DisplayName("Start Date:")]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayName("Projected End Date")]
        public DateTime ProjectedEndDate { get; set; }
        [DisplayName("Actual End Date")]
        public DateTime ActualEndDate { get; set; }
        public string Notes { get; set; }
        [Required]
        public int AssignmentIdentifier { get; set; }

    }
}
