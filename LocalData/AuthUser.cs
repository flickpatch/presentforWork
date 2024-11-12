using AOA.Connection.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOA.LocalData
{
    public  class AuthUser
    {
        public static User User { get; set; }   
        
        public static void GetFIO()
        {
            User.FIO =  User.SecName + " " + User.Name + " " + User.MidName.First()+".";
        }
    }
}
