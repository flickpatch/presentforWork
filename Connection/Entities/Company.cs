using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOA.Connection.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegistrDate { get; set; }
        public string Description { get; set; }
        public virtual List<User> Users { get; set; }
        public byte[]? Logo { get; set; } = null;
        public DateOnly DAteCreate { get; set; }
        [Required, ForeignKey(nameof(RepresentingUserId))]
        public int RepresentingUserId { get; set; }
        [NotMapped]
        public virtual User RepresentingPerson { get; set; }
        public Company()
        {
            Users = new List<User>();
        }
    }
}
