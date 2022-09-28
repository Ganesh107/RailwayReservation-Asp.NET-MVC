using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.DynamicData;

namespace RailwayReservationUsingMVC.Models
{
    [TableName("Traininfo")]
    public class Traininfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Train Number")]
        [Required(ErrorMessage ="Please Enter Train Number")]
        public int Trainnumber { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Please Enter Train Name")]
        [DisplayName("Train Name")]
        public string Trainname { get; set; }

        [StringLength(50)]
        [Column(TypeName ="nvarchar")]
        [Required(ErrorMessage ="Please Enter Starting location")]
        [DisplayName("Starting Location")]
        public string Startloc { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Please Enter Ending location")]
        [DisplayName("Ending Location")]
        public string Endloc { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Please Enter Arrival time")]
        [DisplayName("Arrival Time")]
        public string Arrivaltime { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Please Enter Departure Time")]
        [DisplayName("Departure Time")]
        public string Departuretime { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Please Enter Arrival Date")]
        [DisplayName("Arrival Date")]
        public string Arrivaldate { get; set; }

        [Column(TypeName ="int")]
        [Required(ErrorMessage ="Enter AC-2 tier seats")]
        [DisplayName("AC-2 Tier Seats")]
        public int Ac2tier { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Enter Sleeper class seats")]
        [DisplayName("Sleeper class Seats")]
        public int Sleeper { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Enter AC-3 tier seats")]
        [DisplayName("AC-3 Tier Seats")]
        public int Ac3tier { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Enter Tatkal class seats")]
        [DisplayName("Tatkal class Seats")]
        public int Tatkal { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Enter Ladies class seats")]
        [DisplayName("Ladies class Seats")]
        public int Ladies { get; set; }
    }
}