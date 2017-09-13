using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Resume
    {
        [Key]
        public int Id { get; set; }

        public string Headline { get; set; }

        public virtual List<Skill> Skills { get; set; }
        public virtual List<Certification> Certifications { get; set; }
        public virtual List<WorkHistory> WorkHistoryList { get; set; }
    }
}