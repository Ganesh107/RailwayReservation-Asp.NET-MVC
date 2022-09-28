using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RailwayReservationUsingMVC.Models
{
    public class Passengers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Please Enter UserID")]
        public int Userid { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Please Enter Name")]
        [DisplayName("Name")]
        public string Pname { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Please Enter Date of Birth")]
        [DisplayName("Date of Birth")]
        public string Dob { get; set; }

        [Required(ErrorMessage = "Please select your Gender")]
        [StringLength(10)]
        [Column(TypeName = "nvarchar")]
        public string Gender { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Please Enter Address")]
        [DisplayName("Address")]
        public string Address { get; set; }

        [StringLength(10)]
        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Please Enter Phone Number")]
        [DisplayName("Phone Number")]
        [RegularExpression("^([0]|\\+91)?[6789]\\d{9}$", ErrorMessage = "Not Valid")]
        public string Phonenumber { get; set; }

        [StringLength(20)]
        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Please Enter Password")]
        [DisplayName("Password")]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please Enter Password again")]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}