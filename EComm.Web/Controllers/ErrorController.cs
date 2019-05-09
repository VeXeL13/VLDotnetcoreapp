using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EComm.Web.Models;
using EComm.DataAccess;
using EComm.Model;
using Microsoft.EntityFrameworkCore;

namespace EComm.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("error/{statusCode:int}")]
        public IActionResult Index(int statusCode)
        {
            var evm = new ErrorViewModel();
            ViewBag.StatusCode = statusCode;
            return View("Error", evm);
        }
    }
}