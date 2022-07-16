using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Az204.DAL.Models
{
    [Table("ProjectState")]
    public partial class ProjectState
    {
        public ProjectState()
        {
            Projects = new HashSet<Project>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Name { get; set; }

        [InverseProperty("ProjectState")]
        public virtual ICollection<Project> Projects { get; set; }
    }
}
