using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Az204.DAL.Models
{
    [Table("Project")]
    public partial class Project
    {
        public Project()
        {
            Requirements = new HashSet<Requirement>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        public double? Price { get; set; }
        public double? Hours { get; set; }
        public int? ProjectStateId { get; set; }
        public int? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("Projects")]
        public virtual Customer? Customer { get; set; }
        [ForeignKey("ProjectStateId")]
        [InverseProperty("Projects")]
        public virtual ProjectState? ProjectState { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}
