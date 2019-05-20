using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStore.Domain.Entities;

namespace StoresStore.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}