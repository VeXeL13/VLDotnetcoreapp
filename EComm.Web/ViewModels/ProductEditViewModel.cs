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
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EComm.Web.ViewModels
{
    public class ProductEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(1, 500)]
        public decimal? UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }
        public int SupplierId { get; set; }

        public List<SelectListItem> Suppliers { get; set; }

    }
}
