﻿using dukaan.web.Models;
using dukaan.web.Models.Content;
using Microsoft.AspNetCore.Mvc;

namespace dukaan.web.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index(Node node, CartContent content)
        {
            return View();
        }
    }
}
