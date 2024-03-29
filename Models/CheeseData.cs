﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class CheeseData
    {
        static private List<Cheese> cheeses = new List<Cheese>();

        //get all 
        public static List<Cheese> GetAll()
        {
            return cheeses;
        }

        // need an add method
        public static void Add(Cheese newCheese)
        {
            cheeses.Add(newCheese);
        }

        // need a remove method
        public static void Remove(int id)
        {
            Cheese cheeseToRemove = GetById(id);
            cheeses.Remove(cheeseToRemove);
        }

        //getbyid
        public static Cheese GetById(int id)
        {
            return cheeses.Single(p => p.CheeseId == id);
        }
    }
}
