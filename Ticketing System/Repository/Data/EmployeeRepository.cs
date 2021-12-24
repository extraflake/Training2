using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing_System.Context;
using Ticketing_System.Models;
using Ticketing_System.ViewModel;

namespace Ticketing_System.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employee, string>
    {
        private readonly MyContext context;

        public EmployeeRepository(MyContext context) : base(context)
        {
            this.context = context;
        }

        public int Register(RegisterVM registerVM)
        {
            Employee e = new Employee()
            {
                IdEmployee = registerVM.IdEmployee,
                FirstName = registerVM.Firstname,
                LastName = registerVM.Lastname,
                Email = registerVM.Email,
                Password = registerVM.Password,
                Gender = (Models.Gender)registerVM.Gender
            };
            var cekIdEmployee = context.Employees.Find(registerVM.IdEmployee);
            var cekEmail = context.Employees.Where(b => b.Email == registerVM.Email).FirstOrDefault();

            if (cekIdEmployee != null)
            {
                return 2;
            }
            if (cekEmail != null)
            {
                return 3;
            }
            context.Employees.Add(e);
            context.SaveChanges();

            Account a = new Account()
            {
                IdEmployee = registerVM.IdEmployee,
                Password = Hashing.Hashing.HashPassword(registerVM.Password)
            };
            context.Accounts.Add(a);
            context.SaveChanges();
            int cekRole = registerVM.IdRole;
            int roleId;
            if (cekRole == 0 || cekRole == 1)
            {
                roleId = 1;
            }
            else if (cekRole == 2)
            {
                roleId = 2;
            }
            else
            {
                roleId = 3;
            }

            Accounts_Has_Role ar = new Accounts_Has_Role()
            {
                IdEmployee = a.IdEmployee,
                IdRole = roleId
            };
            context.Accounts_Has_Roles.Add(ar);
            context.SaveChanges();
            var result = context.SaveChanges();
            return result;

        }
    }
}
