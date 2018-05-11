using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HR.Models.HR
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public long DepartmentID { get; set; }
        [StringLength(500)]
        [Required]
        public string Department_Name { get; set; }
        [StringLength(500)]
        [Required]
        public string Department_Code { get; set; }

        public bool? Is_Actv { get; set; }
        public bool? Is_Del { get; set; }
        public long? Crtd_by { get; set; }
        public DateTime? Crtd_ts { get; set; }
        public long? Mod_by { get; set; }
        public DateTime? Mod_ts { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [ForeignKey("Organization")]
        public long OrganizationID { get; set; }
        public Organization Organization { get; set; }

        public ICollection<Designation> Designations { get; set; }

    }
}