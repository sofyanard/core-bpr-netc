using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreBPR.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreBPR.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly ApplicationDbContext _context;

        public ApplicationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationMenu>> GetUserMenuAsync(ClaimsPrincipal principal)
        {
            List<ApplicationMenu> resultMenus = new List<ApplicationMenu>();

            string userId = GetUserId(principal);

            var user = _context.ApplicationUsers.Find(userId);

            if (user == null)
            {
                return resultMenus;
            }

            string groupId = user.GroupId;

            if (groupId == null)
            {
                return resultMenus;
            }

            // Get Level 1 Menu
            var lv1Menus = await (from g in _context.RefGroupMenus
                                  join m in _context.RefMenus on g.MenuId equals m.MenuId
                                  where m.Level == 1 && g.GroupId == groupId
                                  select m).Distinct().ToListAsync();

            if (lv1Menus == null)
            {
                return resultMenus;
            }

            foreach (var lv1Menu in lv1Menus)
            {
                ApplicationMenu singleMenu = new ApplicationMenu();
                singleMenu.MenuId = lv1Menu.MenuId;
                singleMenu.MenuName = lv1Menu.MenuName;

                var lv2Menus = await (from g in _context.RefGroupMenus
                                      join m in _context.RefMenus on g.MenuId equals m.MenuId
                                      where m.Level == 2 && g.GroupId == groupId && m.ParentRefMenu.MenuId == singleMenu.MenuId
                                      select m).Distinct().ToListAsync();

                foreach (var lv2Menu in lv2Menus)
                {
                    ApplicationMenuChild childMenu = new ApplicationMenuChild();
                    childMenu.MenuId = lv2Menu.MenuId;
                    childMenu.MenuName = lv2Menu.MenuName;
                    childMenu.Controller = lv2Menu.Controller;
                    childMenu.Action = lv2Menu.Action;
                    childMenu.Param = lv2Menu.Param;

                    singleMenu.Children.Add(childMenu);
                }

                resultMenus.Add(singleMenu);
            }

            return resultMenus;
        }

        private string GetUserId(ClaimsPrincipal user)
        {
            return ((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.Name)?.Value;
        }
    }
}
