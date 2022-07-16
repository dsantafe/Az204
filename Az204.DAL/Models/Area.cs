using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Az204.DAL.Models
{
    [Table("Area")]
    public partial class Area
    {
        public Area()
        {
            Requirements = new HashSet<Requirement>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Description { get; set; }

        [InverseProperty("Area")]
        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}
