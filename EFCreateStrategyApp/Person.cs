using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCreateStrategyApp
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }

    //[Table("Users")]
    public class User : Person
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
    }

    //[Table("Guests")]
    public class Guest : Person
    {
        public string? Email { get; set; }
    }

    //[Table("Admins")]
    public class Admin : User
    {
        public string? Role { get; set; }
    }
}
