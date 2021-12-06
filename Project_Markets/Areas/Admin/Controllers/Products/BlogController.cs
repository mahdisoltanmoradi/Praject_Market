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
    public class BlogController : Controller
    {
        private readonly IRepository<Blogs> _blogrepository;
        private readonly IMapper _mapper;
        public BlogController(IRepository<Blogs> repository, IMapper mapper)
        {
            this._blogrepository = repository;
            this._mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
