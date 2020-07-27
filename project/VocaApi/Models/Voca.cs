using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VocaApi.Models
{
    public class Voca
    {

        public int Id { get; set; }
        public string Word { get; set; }
        public string Meaning { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime EditDate { get; set; }

    }
}
