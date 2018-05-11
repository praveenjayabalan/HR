using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HR.Models.HR
{
    [Table("Designation")]
    public class Designation
    {
        [Key]
        public long DesignationID { get; set; }
        [StringLength(500)]
        [Required]
        public string Designation_Name { get; set; }
        [StringLength(500)]
        [Required]
        public string Designation_code { get; set; }



        public bool? Is_Actv { get; set; }
        public bool? Is_Del { get; set; }
        public long? Crtd_by { get; set; }
        public DateTime? Crtd_ts { get; set; }
        public long? Mod_by { get; set; }
        public DateTime? Mod_ts { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }


        [ForeignKey("Department")]
        public long DepartmentID { get; set; }
        public Department Department { get; set; }


        public ICollection<Employee> Employee { get; set; }
    }
}