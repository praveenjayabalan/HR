using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HR.Models.HR
{
    public class Holiday
    {
        [Key]
        public int Holidayid { get; set; }

        [StringLength(50)]
        public string HolidayName { get; set; }

        [StringLength(500)]
        public string Desc { get; set; }

        
        public int Year { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [ForeignKey("Organization")]
        public long OrganizationID { get; set; }
        public Organization Organization { get; set; }
    }
}