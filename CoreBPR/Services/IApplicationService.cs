using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreBPR.Models;

namespace CoreBPR.Services
{
    public interface IApplicationService
    {
        Task<List<ApplicationMenu>> GetUserMenuAsync(ClaimsPrincipal principal);
    }
}
