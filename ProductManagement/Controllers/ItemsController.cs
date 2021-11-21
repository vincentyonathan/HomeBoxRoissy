using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductManagement.Context;

namespace ProductManagement.Controllers
{
    public class ItemsController : Controller
    {
        StorageItemDBEntities dbObj = new StorageItemDBEntities();
        // GET: Items
        [Authorize]
        public ActionResult Items(Item obj)
        {
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddItems(Item model)
        {

            if(ModelState.IsValid)
            {
                Item obj = new Item();
                obj.ItemID = model.ItemID;  
                obj.ItemName = model.ItemName;
                obj.ItemDesc = model.ItemDesc;
                obj.ItemSupplier = model.ItemSupplier;
                obj.ItemBrand = model.ItemBrand;
                obj.ItemCategory = model.ItemCategory;
                obj.ItemPrice = model.ItemPrice;
                obj.ItemStock = model.ItemStock;

                if(model.ItemID == 0)
                {
                    dbObj.Items.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = EntityState.Modified;
                    dbObj.SaveChanges();
                }
            }
            ModelState.Clear();

            return View("Items");
        }

        [Authorize]
        public ActionResult ItemsList()
        {
            var res = dbObj.Items.ToList();
            return View(res);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var res = dbObj.Items.Where(x => x.ItemID == id).FirstOrDefault();
            dbObj.Items.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.Items.ToList();

            return View("ItemsList",list); 
        }

        [Authorize]
        public ActionResult Details(Item obj)
        {
            return View(obj);
        }
    }
}