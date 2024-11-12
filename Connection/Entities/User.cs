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
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(32)]
        public string Name { get; set; }
        [Required, MaxLength(32)]
        public string SecName { get; set; }
        [Required, MaxLength(32)]
        public string MidName { get; set; }
        [Required, MaxLength(64), MinLength(16)]
        public string Login { get; set; }
        [Required, MaxLength(64), MinLength(16)]
        public string Pass { get; set; }
        [Required]
        public Roles Role { get; set; } = Roles.User;
        [Required]
        public byte[] Photo { get; set; }
        [Required, ForeignKey(nameof(Companyid))]
        public int Companyid { get; set; }
        public virtual List<Offer> Events { get; set; }
        [Required]
        public virtual Company Company { get; set; }
        [NotMapped, MinLength(9), MaxLength(12), Display(Name = "Номер")]
        public string sPhone
        {
            get
            {
                return "+7" + Phone.ToString();
            }
            set
            {
                
            }
        }
        public virtual List<News> News { get; set; }
        public User() { 
        News= new List<News>();
        Events= new List<Offer>();
        }
        [NotMapped]
        public string FIO
        {
            get
            {
                return Name + " " + SecName+ " "+ MidName;
            }
            set
            {

            }
        }
        public enum Roles
        {
            User,
            Moderator,
            Admin
        }
        [Phone, MaxLength(10), MinLength(9)]
        public long? Phone { get; set; } = null;
        [NotMapped]
        public string SRole
        {
            get
            {
                switch (Role)
                {
                    case Roles.User:
                        return "Пользователь";
                    case Roles.Moderator:
                        return "Модератор";
                    default: return "Администратор";
                }
            }
            set { }
        }
        [NotMapped]
        public Brush ColorName
        {
            get
            {
                if (Role != Roles.User)
                    return Brushes.Green;
                return Brushes.Black;
                     
            }
            set
            {

            }
        }
    }
} 
