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

namespace EComm.Web.ViewComponents
{
    public class ProductList : ViewComponent
    {
        private ECommDataContext _dataContext;

        public ProductList(ECommDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            var products = _dataContext.Products.Include(p => p.Supplier).ToList();
            return Task.FromResult<IViewComponentResult>(View(products));
        }
    }
}
