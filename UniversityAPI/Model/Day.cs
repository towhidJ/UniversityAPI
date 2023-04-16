using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityAPI.Model
{
    public class Day
    {
        [Key]
        public int Id { get; set; }
        public string DayName { get; set; }
        public List<AllocateClass> AllocateClass { get; set; }
    }
}