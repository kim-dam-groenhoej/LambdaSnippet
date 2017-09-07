using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LambdaSnippet.Models;

namespace LambdaSnippet.ViewModels
{
    public class ProductsVM
    {
        public List<Product> Products { get; set; }

        public int Pages { get; set; }
    }
}