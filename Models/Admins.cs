using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RailwayReservationUsingMVC.Models
{
    public class Admins
    {
        [Key]
        [Required(ErrorMessage = "Please Enter Admin ID")]
        [DisplayName("Admin ID")]
        public int Adminid { get; set; }

        [StringLength(50)]
        [Column(TypeName ="nvarchar")]
        public string Username { get; set; }

        [StringLength(20)]
        [Column(TypeName ="nvarchar")]
        [Required(ErrorMessage ="Please enter Password")]
        public string Password { get; set; }
    }
}