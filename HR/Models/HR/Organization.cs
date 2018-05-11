using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HR.Models.HR
{
    [Table("Organization")]
    public class Organization
    {
        [Key]
        public long OrganizationID { get; set; }
        [StringLength(500)]
        [Required]
        public string Organization_Name { get; set; }
        [StringLength(500)]
        [Required]
        public string Organization_code { get; set; }
        public bool? Is_Actv { get; set; }
        public bool? Is_Del { get; set; }
        public long? Crtd_by { get; set; }
        public DateTime? Crtd_ts { get; set; }
        public long? Mod_by { get; set; }
        public DateTime? Mod_ts { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public ICollection<Department> Departments { get; set; }
        public ICollection<Holiday> Holidays { get; set; }
    }
}