﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop1.DataAccess.InMemory;
using MyShop1.Core.Models;
using MyShop1.Core.ViewModel;

namespace MyShop1.WebUI.Controllers
{
    public class ProductManageController : Controller
    {
        InMemoryRepo<Product> Context;
        InMemoryRepo<ProductCategory> productCategories;
        public ProductManageController()
        {
            Context = new InMemoryRepo<Product>();
            productCategories = new InMemoryRepo<ProductCategory>();
        }



        public ActionResult Index()
        {
            List<Product> products = Context.Collection().ToList();
            return View(products);
        }



        public ActionResult Create()
        {
            ProductViewModel viewModel = new ProductViewModel();
            viewModel.Product = new Product();
            viewModel.ProductCategories = productCategories.Collection();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                Context.Insert(product);
                Context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string Id)
        {
            Product product = Context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductViewModel viewModel = new ProductViewModel();
                viewModel.Product = product;
                viewModel.ProductCategories = productCategories.Collection();
                return View(viewModel);
            }
        }
        [HttpPost]
        public ActionResult Edit(Product product, string Id)
        {
            Product productToEdit = Context.Find(Id);
            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                productToEdit.Category = product.Category;
                productToEdit.Description = product.Description;
                productToEdit.Name = product.Name;
                productToEdit.Image = product.Image;
                productToEdit.Price = product.Price;

                Context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            Product productToDelete = Context.Find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Product productToDelete = Context.Find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                Context.Delete(Id);
                Context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}