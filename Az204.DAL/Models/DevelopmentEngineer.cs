using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Az204.DAL.Models
{
    [Table("DevelopmentEngineer")]
    public partial class DevelopmentEngineer
    {
        public DevelopmentEngineer()
        {
            Requirements = new HashSet<Requirement>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? LastName { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? FirstMidName { get; set; }

        [InverseProperty("DevelopmentEngineer")]
        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}
