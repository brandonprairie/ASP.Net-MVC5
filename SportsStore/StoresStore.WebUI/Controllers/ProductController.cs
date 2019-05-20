using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace StoresStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository myrepository;

        public ProductController(IProductRepository productRepository)
        {
            this.myrepository = productRepository;
        }

        public ViewResult List()
        {
            return View(myrepository.Products);
        } 
    }
}