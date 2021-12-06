using AutoMapper;
using Data.Contracts;
using Entities.Blog;
using infrastructure.WebFramework.CrudRefrences;
using Microsoft.AspNetCore.Mvc;
using Project_Markets.DTOs.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Markets.Areas.Admin.Controllers.Products
{
    [Area("Admin")]
    public class BlogCategoryController : Controller
    {
       public IActionResult Index()
        {
            return View();
        }
    }
}
