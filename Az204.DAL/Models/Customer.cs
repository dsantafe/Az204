using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Az204.DAL.Models
{
    [Table("Customer")]
    public partial class Customer
    {
        public Customer()
        {
            Projects = new HashSet<Project>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? FirstMidName { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? LastName { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Telephone { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Location { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Email { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<Project> Projects { get; set; }
    }
}
