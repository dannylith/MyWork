using FieldAgent.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FieldAgent.Models
{
    public class Agent
    {
        [DisplayName("First Name:")]
        [Required(ErrorMessage ="First Name is Required.")]
        public string FirstName { get; set; }
        [DisplayName("Middle Name:")]
        public string MiddleName { get; set; } = "";
        [DisplayName("Last Name:")]
        [Required(ErrorMessage ="Last Name is Required.")]
        public string LastName { get; set; }
        [DisplayName("Picture Url:")]
        public string PicturUrl { get; set; } = "";
        [DisplayName("Birth Date:")]
        public DateTime BirthDate { get; set; }
        [Range(36, 96, ErrorMessage ="Please select a number between 36 - 96.")]
        public int Height { get; set; }
        [Required]
        public string Identifier { get; set; }
        [Required]
        public string Agency { get; set; }
        [DisplayName("Activation Date:")]
        [Required(ErrorMessage = "Activation Date is Required.")]
        public DateTime ActivationDate { get; set; }
        [DisplayName("Security Clearance")]
        [Required]
        public string SecurityClearance { get; set; }
        [DisplayName("Active")]        
        public bool IsActive { get; set; }
        public List<Alias> Aliases { get; set; } = new List<Alias>();
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();


    }
}