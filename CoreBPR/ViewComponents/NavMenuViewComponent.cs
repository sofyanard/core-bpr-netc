/*
Reference :
https://www.codeproject.com/Articles/5163177/MVC-6-Dynamic-Navigation-Menu-from-Database
*/

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CoreBPR.Models;
using CoreBPR.Services;

namespace CoreBPR.ViewComponents
{
    public class NavMenuViewComponent : ViewComponent
    {
        private readonly IApplicationService _applicationService;

        public NavMenuViewComponent(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _applicationService.GetUserMenuAsync(HttpContext.User);

            return View(items);
        }
    }
}
