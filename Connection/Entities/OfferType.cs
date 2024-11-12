using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOA.Connection.Entities
{
    [Table("TypesOffer")]
    public class OfferType
    {
        [Key]
        public int Id { get; set; }
        [ MaxLength(54)]
        public string? Name { get; set; } = null;
        public virtual List<Offer> Offers { get; set; }
        public OfferType()
        {
            Offers = new List<Offer>();
        }
    }
}
