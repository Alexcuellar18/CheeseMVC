﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        
        public IActionResult Index()
        {
            List<Cheese> cheeses = CheeseData.GetAll();

            //example of a view model

            return View(cheeses);
        }
        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }
        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel) // can do this instead of passing parameter for name and description

        {
            /*
             Cheese newCheese = new Cheese();
             newCheese.Name = Request.get(name);
             newCheese.Description = Request.get(description);

            In order for this to work, you need a default constructor with no parameters
             
            */

            if(ModelState.IsValid)
            {
                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Type = addCheeseViewModel.Type
                };
                //Add the new cheese to existing cheese list
                CheeseData.Add(newCheese);
                return Redirect("/Cheese");
            }
            return View(addCheeseViewModel);
            
        }
        
        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach( int cheeseId in cheeseIds)
            {
                //Cheese.RemoveAll(p => p.CheeseId == cheeseId); LINQ syntax
                CheeseData.Remove(cheeseId);

            }

            return Redirect("/");
        }
       public IActionResult Edit(int cheeseId)
        {
            ViewBag.cheeseToBeUpdated = CheeseData.GetById(cheeseId);
            return View();
        }
        
        [HttpPost]
        public IActionResult Edit(int cheeseId, string name, string description)
        {
            var myCheese = CheeseData.GetById(cheeseId);
            myCheese.Name = name;
            myCheese.Description = description;
            return Redirect("/");
        }

    }
}