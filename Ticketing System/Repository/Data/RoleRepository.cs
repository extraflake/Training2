using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing_System.Context;
using Ticketing_System.Models;

namespace Ticketing_System.Repository.Data
{
    public class RoleRepository : GeneralRepository<MyContext, Role, int>
    {
        private readonly MyContext context;
        public RoleRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
