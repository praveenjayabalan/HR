using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HR.Models.HR
{
    [Table("EmployeeType")]
    public class EmployeeType
    {
        [Key]
        public long EmployeeTypeId { get; set; }
        [StringLength(50)]
        public string EmployeeTyp { get; set; }
        [StringLength(500)]
        public string Desc { get; set; }

        public bool? Is_Actv { get; set; }
        public bool? Is_Del { get; set; }
        public long? Crtd_by { get; set; }
        public DateTime? Crtd_ts { get; set; }
        public long? Mod_by { get; set; }
        public DateTime? Mod_ts { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

     

        public ICollection<Employee> Employees { get; set; }
    }
}