using Az204.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Az204.Domain.DTOs
{
    internal class ProjectDTO
    {
        public ProjectDTO()
        {
            Requirements = new HashSet<Requirement>();
        }

        
        public int Id { get; set; }

        [Display(Name = "First MidName")]
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(50)]
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "datetime")]
        
        [StringLength(50)]
        public DateTime? EndDate { get; set; }
        
        [StringLength(50)]
        public double? Price { get; set; }

        [StringLength(50)]
        public double? Hours { get; set; }

        [StringLength(50)]
        public int? ProjectStateId { get; set; }

        [StringLength(50)]
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

