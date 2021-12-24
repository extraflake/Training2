using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing_System.Base;
using Ticketing_System.Models;
using Ticketing_System.Repository.Data;

namespace Ticketing_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountHasRolesController : BaseController<Accounts_Has_Role, AccountHasRole_Repository, string>
    {
        private readonly Repository.Data.AccountHasRole_Repository accountHasRole_Repository;
        public IConfiguration _configuration;
        public IConfiguration _configuration2;
        public AccountHasRolesController(AccountHasRole_Repository accountRoleRepository, IConfiguration configuration) : base(accountRoleRepository)
        {
            this.accountHasRole_Repository = accountRoleRepository;
            this._configuration = configuration;
            this._configuration2 = configuration;
        }

    }
}
