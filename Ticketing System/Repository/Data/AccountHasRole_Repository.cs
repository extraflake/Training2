using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing_System.Context;
using Ticketing_System.Models;

namespace Ticketing_System.Repository.Data
{
    public class AccountHasRole_Repository : GeneralRepository<MyContext, Accounts_Has_Role, string>
    {
        private readonly MyContext context;
        public AccountHasRole_Repository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
