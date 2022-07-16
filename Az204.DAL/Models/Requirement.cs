using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Az204.DAL.Models
{
    [Table("Requirement")]
    public partial class Requirement
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("AreaID")]
        public int? AreaId { get; set; }
        [Column("ApplicativeID")]
        public int? ApplicativeId { get; set; }
        [StringLength(1000)]
        [Unicode(false)]
        public string? ScopeRequirement { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApplicationDate { get; set; }
        [Column("PriorityID")]
        public int? PriorityId { get; set; }
        [Column("DevelopmentEngineerID")]
        public int? DevelopmentEngineerId { get; set; }
        public int? DevelopmentDays { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DevelopmentDate { get; set; }
        public int? ProjectId { get; set; }

        [ForeignKey("ApplicativeId")]
        [InverseProperty("Requirements")]
        public virtual Applicative? Applicative { get; set; }
        [ForeignKey("AreaId")]
        [InverseProperty("Requirements")]
        public virtual Area? Area { get; set; }
        [ForeignKey("DevelopmentEngineerId")]
        [InverseProperty("Requirements")]
        public virtual DevelopmentEngineer? DevelopmentEngineer { get; set; }
        [ForeignKey("PriorityId")]
        [InverseProperty("Requirements")]
        public virtual Priority? Priority { get; set; }
        [ForeignKey("ProjectId")]
        [InverseProperty("Requirements")]
        public virtual Project? Project { get; set; }
    }
}
