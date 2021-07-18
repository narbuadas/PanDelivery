using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MyInventory.Data;
using MyInventory.Models;

namespace MyInventory.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SupplierController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Suppliers.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Supplier record)
        {
            var supplier = new Supplier();
            supplier.CompanyName = record.CompanyName;
            supplier.Representative = record.Representative;
            supplier.Code = record.Code;
            supplier.Address = record.Address;
            supplier.DateAdded = record.DateAdded;
            supplier.Type = record.Type;

            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var supplier = _context.Suppliers.Where(i => i.SupplierId == id).SingleOrDefault();
            if (supplier == null)
            {
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        [HttpPost]
        public IActionResult Edit(int? id, Supplier record)
        {
            var supplier = _context.Suppliers.Where(i => i.SupplierId == id).SingleOrDefault();
            supplier.CompanyName = record.CompanyName;
            supplier.Representative = record.Representative;
            supplier.Code = record.Code;
            supplier.Address = record.Address;
            supplier.DateModified = DateTime.Now;
            supplier.Type = record.Type;

            _context.Suppliers.Update(supplier);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var supplier = _context.Suppliers.Where(i => i.SupplierId == id).SingleOrDefault();
            if (supplier == null)
            {
                return RedirectToAction("Index");
            }

            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
