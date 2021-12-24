using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing_System.ViewModel
{
    public class RegisterVM
    {
        public string IdEmployee { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdRole { get; set; }
        public string NameRole { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}
