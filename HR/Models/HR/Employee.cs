using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HR.Models.HR
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public long EmployeeID { get; set; }
        [StringLength(500)]
        [Required]
        public string Employee_Name { get; set; }
        [StringLength(500)]
        [Required]
        public string Employee_Code { get; set; }
        [StringLength(500)]
        [Required]
        public string Email { get; set; }
       
        public DateTime Date_Of_Birth { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(50)]
        public string Contact_No { get; set; }
        [StringLength(50)]
        public string Emergency_Contact_No { get; set; }
        [StringLength(250)]
        public string Qualifications { get; set; }



        public bool? Is_Actv { get; set; }
        public bool? Is_Del { get; set; }
        public long? Crtd_by { get; set; }
        public DateTime? Crtd_ts { get; set; }
        public long? Mod_by { get; set; }
        public DateTime? Mod_ts { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [ForeignKey("EmployeeType")]
        public long EmployeeTypeId { get; set; }
        public EmployeeType EmployeeType { get; set; }

        [ForeignKey("Designation")]
        public long DesignationId { get; set; }
        public Designation Designation { get; set; }


    }
}