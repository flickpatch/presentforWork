using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AOA.Connection.Entities
{
    [Table("Events")]
    public class Offer
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(60) ]
        public string Name { get; set; }
        public int Price { get; set; }  
        public string Description { get; set; }
        public byte[]? Photo { get; set; } = null;
        public virtual User Author { get; set; }    
        public int AuthorId { get; set; }
        public DateTime DateCreate { get; set; } = DateTime.Now;
        public Status _Status { get; set; } = Status.Open;
        public int CategoryID { get; set; } = 8;
        public EType TypeEvent { get; set; } = EType.Zakaz;
        [ForeignKey("CategoryID")]
        public virtual OfferType Type { get; set; }
        public enum EType
        {
            Zakaz,
            Offer
        }        
        public enum Status
        {
            Open,
            Close,
            Working
        }
        [NotMapped]
        public string sPrice
        {
            get
            {
                return Price + "руб";
            }
            set
            {

            }
        }
        public string sStatus { get
            {
                if (_Status == Status.Open)
                {
                    return "Свободен";
                }
                else if (_Status == Status.Close)
                    return "Занят";
                return "В разработке";
            } 
        }
        public Brush sColor { get
            {
                if (_Status == Status.Open)
                {
                    return Brushes.Green;
                }
                else if (_Status == Status.Close)
                    return Brushes.Red;
                return Brushes.Purple;
            } }
    }
}
