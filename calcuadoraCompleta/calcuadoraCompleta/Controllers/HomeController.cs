﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace calcuadoraCompleta.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.visor = "0";
            return View();
        }
        /// <summary>
        /// recebe numeros  
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public ActionResult Index(string btn, string visor)
        {
            string auxvisor = visor;
            
            switch (btn)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    if (visor.Equals("0"))
                    visor = btn;   
                    else                 
                    visor += btn;
                    break;
                case "C":
                    visor = "0";
                    break;
                case ",":
                if (!visor.Contains(",")) visor += btn;
                    break;
                case "+":
                    visor = auxvisor + "+";
                    break;
            }
            ViewBag.visor = visor;
            return View();
        }
    }
}