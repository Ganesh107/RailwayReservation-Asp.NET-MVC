using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RailwayReservationUsingMVC.Models
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Ticket Number")]
        public int Ticketno { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Please Enter Full Name")]
        [DisplayName("Passenger Name")]
        public string Pname { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Please Enter Train Name")]
        [DisplayName("Train Name")]
        public string Trainname { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Please Enter Ticket Class")]
        [DisplayName("Class")]
        public string Ticketclass { get; set; }

        [StringLength(10)]
        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Please select your gender")]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please select berth number")]
        [DisplayName("Berth Number")]
        public int Berthnumber { get; set; }

        [Required(ErrorMessage = "Please select coach number")]
        [DisplayName("Coach Number")]
        public int Coachnumber { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Please Enter Arrival Date")]
        [DisplayName("Arrival Date")]
        public string Arrivaldate { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Please Enter Booking Date")]
        [DisplayName("Booking Date")]
        public string Bookingdate { get; set; }
         
        [StringLength(20)]
        [Column(TypeName = "nvarchar")]
        public string Bookingstatus { get; set; }

        [DisplayName("Passenger ID")]
        public int pid { get; set; }   
    }
}