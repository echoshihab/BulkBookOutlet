﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkBookOutlet.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BulkBookOutlet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CatogoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public CatogoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Category.GetAll();
            return Json(new { data = allObj });
        }

        #endregion
    }
}