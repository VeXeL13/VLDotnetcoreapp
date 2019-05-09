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
    public class CartViewModel
    {
        public ShoppingCart Cart { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [CreditCard]
        [Display(Name = "Credit Card")]
        public string CreditCard { get; set; }
    }
}
