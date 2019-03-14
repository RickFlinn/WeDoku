using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace We_Doku.Controllers
{
    public class PolicyController : Controller
    {
        [Authorize(Policy = "MemberOnly")]
        public IActionResult Game()
        {
            return LocalRedirect("~/Pages/Game");
        }
    }
}