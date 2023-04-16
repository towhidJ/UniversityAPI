using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace UniversityAPI.Model
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public List<AllocateClass> AllocateClass { get; set; }

    }
}