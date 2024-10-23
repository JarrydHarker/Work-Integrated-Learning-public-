﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.IdentityModel.Tokens;
using XBCADAttendance.Models;
using XBCADAttendance.Models.ViewModels;

namespace XBCADAttendance.Controllers
{
    [Authorize(Policy ="StudentOnly")]
    public class StudentReportController : Controller
    {

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            string? userID = User.Identity.Name;

            if (string.IsNullOrWhiteSpace(userID))
            {
                // Optionally add an error message to display on the redirected page
                TempData["ErrorMessage"] = "User ID is invalid. Please log in again.";
                return RedirectToAction("Index", "Home");
            }

            StudentReportViewModel model = new StudentReportViewModel(userID);
            return View(model);
        }


        public IActionResult StudentReport()
        {
            string? userID = null;

            if (User.Identity.IsAuthenticated)
            {
                userID = User.Identity.Name;

                if (!userID.IsNullOrEmpty())
                {
                    StudentReportViewModel model = new StudentReportViewModel(userID);
                    return View(model);
                } else
                {
                     return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Profile()
        {
            string? userID = null;

            if (User.Identity.IsAuthenticated)
            {
                userID = User.Identity.Name;

                if (!userID.IsNullOrEmpty())
                {
                    StudentReportViewModel newModel = new StudentReportViewModel(userID);
                    return View(newModel);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");

        }


        public IActionResult Modules()
        {
            string? userID = null;

            if (User.Identity.IsAuthenticated)
            {
                userID = User.Identity.Name;

                if (!userID.IsNullOrEmpty())
                {
                    StudentReportViewModel newModel = new StudentReportViewModel(userID);
                    return View(newModel);
                } else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AttendanceHistory()
        {
            string? userID = null;

            if (User.Identity.IsAuthenticated)
            {
                userID = User.Identity.Name;

                if (!userID.IsNullOrEmpty())
                {
                    StudentReportViewModel newModel = new StudentReportViewModel(userID);
                    return View(newModel);
                } else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete(".AspNetCore.Cookies");

            return RedirectToAction("Index", "Home");
        }

    }
}
