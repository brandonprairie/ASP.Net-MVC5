using System.Collections.Generic;
using SportsStore.Domain.Entities;



namespace StoresStore.WebUI.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo pagingInfo { get; set; }

        // Add Current category property
        public string CurrentCategory { get; set; }
    }
}