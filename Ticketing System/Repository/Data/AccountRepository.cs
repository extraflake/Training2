using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing_System.Context;
using Ticketing_System.Models;

namespace Ticketing_System.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        private readonly MyContext context;
        public AccountRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
