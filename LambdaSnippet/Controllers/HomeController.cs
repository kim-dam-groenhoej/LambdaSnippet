﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using LambdaSnippet.Models;
using LambdaSnippet.ViewModels;

namespace LambdaSnippet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var customers = new List<Customer>();
            customers.Add(new Customer()
            {
                Name = "Jens",
                Age = 10,
                Address = "Lindevej"
            });
            customers.Add(new Customer()
            {
                Name = "Per",
                Age = 12,
                Address = "Lindevej"
            });

            var x = customers.Where(y =>
            {
                var result = false;
                if (y.Age > 11)
                {
                    result = true;
                }

                return result;
            });

            var models = customers.Select(y => new
            {
                y.Name,
                y.Age
            });

            //var numbers = new List<int>() {1, 5, 3, 55, 2};
            //var r = numbers.Sum();

            var products = new List<Product>();
            products.Add(new Product()
            {
                Name = "Kniv",
                Price = new decimal(100)
            });
            products.Add(new Product()
            {
                Name = "Kasse",
                Price = new decimal(120)
            });

            var r = products.Sum(y => y.Price);

            return View();
        }

        public ActionResult LatestProducts()
        {
            // Latest
            var products = this.Testdata();
            var vm = new ProductsVM();
            vm.Products = products.OrderByDescending(x => x.Created).Take(10).ToList();

            return View(vm);
        }

        public ActionResult RandomProducts()
        {
            // Random
            var products = this.Testdata();
            var vm = new ProductsVM();
            vm.Products = products.OrderByDescending(x => Guid.NewGuid()).Take(10).ToList();

            return View(vm);
        }

        private List<Product> Testdata()
        {
            var products = new List<Product>();
            products.Add(new Product()
            {
                Name = "Kniv",
                Price = new decimal(100)
            });
            products.Add(new Product()
            {
                Name = "Kasse",
                Price = new decimal(120)
            });
            products.Add(new Product()
            {
                Name = "asd",
                Price = new decimal(120)
            });
            products.Add(new Product()
            {
                Name = "Kasse",
                Price = new decimal(120)
            });
            products.Add(new Product()
            {
                Name = "Kasse",
                Price = new decimal(120)
            });
            products.Add(new Product()
            {
                Name = "sdf",
                Price = new decimal(120)
            });
            products.Add(new Product()
            {
                Name = "Kasse",
                Price = new decimal(120)
            });
            products.Add(new Product()
            {
                Name = "asdasd",
                Price = new decimal(120)
            });
            products.Add(new Product()
            {
                Name = "Kasse",
                Price = new decimal(120)
            });
            products.Add(new Product()
            {
                Name = "Kasdddse",
                Price = new decimal(120)
            });
            products.Add(new Product()
            {
                Name = "asd",
                Price = new decimal(120)
            });
            products.Add(new Product()
            {
                Name = "asd",
                Price = new decimal(120)
            });
            products.Add(new Product()
            {
                Name = "Kasse",
                Price = new decimal(120)
            });
            products.Add(new Product()
            {
                Name = "Kasdfsdfsse",
                Price = new decimal(120)
            });
            products.Add(new Product()
            {
                Name = "Kasdsdsse",
                Price = new decimal(120)
            });
            products.Add(new Product()
            {
                Name = "Kaasdsse",
                Price = new decimal(120)
            });

            return products;
        }

        public ActionResult Products(int pageNumber)
        {
            var vm = new ProductsVM();
            var products = this.Testdata();

            int numberOfObjectsPerPage = 10;
            var queryResultPage = products
                .Skip(numberOfObjectsPerPage * pageNumber)
                .Take(numberOfObjectsPerPage).ToList();
            vm.Products = queryResultPage;
            var r = Math.Round((decimal)products.Count() / numberOfObjectsPerPage);
            vm.Pages = Convert.ToInt32(r);

            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}