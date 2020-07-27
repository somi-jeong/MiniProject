using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace VocaMvc.Models
{
    public class Voca
    {
        public int Id { get; set; }
        [Display(Name = " ")]
        public string Word { get; set; }
        [Display(Name = " ")]
        public string Meaning { get; set; }
        [Display(Name = " ")]
        public DateTime EnrollmentDate { get; set; }
        [Display(Name = " ")]
        public DateTime EditDate { get; set; }

        public Voca()
        {
            EnrollmentDate = DateTime.UtcNow;
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(EnrollmentDate, cstZone);
            this.EnrollmentDate = cstTime;

        }



    }
}
