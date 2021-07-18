﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MyInventory.Data;
using MyInventory.Models;

namespace PanDelivery.Controllers
{
    public class ShopController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Items.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item record)
        {
            var item = new Item();
            item.Name = record.Name;
            item.Code = record.Code;
            item.Description = record.Description;
            item.Price = record.Price;
            item.DateAdded = record.DateAdded;
            item.Type = record.Type;

            _context.Items.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var item = _context.Items.Where(i => i.ItemId == id).SingleOrDefault();
            if (item == null)
            {
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(int? id, Item record)
        {
            var item = _context.Items.Where(i => i.ItemId == id).SingleOrDefault();
            item.Name = record.Name;
            item.Code = record.Code;
            item.Description = record.Description;
            item.Price = record.Price;
            item.DateModified = DateTime.Now;
            item.Type = record.Type;

            _context.Items.Update(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var item = _context.Items.Where(i => i.ItemId == id).SingleOrDefault();
            if (item == null)
            {
                return RedirectToAction("Index");
            }

            _context.Items.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
