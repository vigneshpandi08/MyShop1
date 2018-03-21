﻿using MyShop1.Core.Models;
using MyShop1.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop1.WebUI.Controllers
{
    public class ProductCategoryController : Controller
    {
        InMemoryRepo<ProductCategory> Context;
        public ProductCategoryController()
        {
            Context = new InMemoryRepo<ProductCategory>();
        }
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = Context.Collection().ToList();
            return View(productCategories);
        }
        public ActionResult Create()
        {

            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {
                Context.Insert(productCategory);
                Context.Commit();
                return RedirectToAction("Index");
            }

        }
        public ActionResult Edit(string Id)
        {
            ProductCategory productCategory = Context.Find(Id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategory);
            }
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string Id)
        {
            ProductCategory productCategoryToEdit = Context.Find(Id);
            if (productCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategory);
                }
                productCategoryToEdit.Category = productCategory.Category;

                Context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            ProductCategory productCategoryToDelete = Context.Find(Id);
            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategoryToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory productCategoryToDelete = Context.Find(Id);
            if (productCategoryToDelete == null)
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