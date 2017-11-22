using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolSupport.Model.Model;
using SchoolSupport.Business;
using School_Support.Models;
using School_Support.Controllers;
using System.Web.Security;
using System.IO;
using Microsoft.AspNet.Identity;
using System.Security.Claims;


namespace School_Support.Areas.Security.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Home()
        {
            return View();
        }
        // GET: Security/Account
        public ActionResult ChangePassword()
        {
            ManageUserViewModel manageUserviewModel = new ManageUserViewModel();

            try
            {
                ViewBag.UserId = User.Identity.Name;
                manageUserviewModel.Username = User.Identity.Name;
            }
            catch (Exception)
            {
                throw;
            }
            return View(manageUserviewModel);
        }
        [HttpPost]
        public ActionResult ChangePassword(ManageUserViewModel manageUserviewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserLogic userLogic = new UserLogic();
                    User LoggedInUser = new User();
                    LoggedInUser = userLogic.GetModelBy(u => u.User_Name == manageUserviewModel.Username && u.Password == manageUserviewModel.OldPassword);
                    if (LoggedInUser != null)
                    {
                        LoggedInUser.Password = manageUserviewModel.NewPassword;
                        userLogic.ChangeUserPassword(LoggedInUser);
                        TempData["Msg"] = "Password Changed Successfully. Please Keep safe";
                        return RedirectToAction("Login", "Account", new { Area = "Security" });
                    }
                    else
                    {
                        TempData["Msg"] = "Please LogOff And Login Again";
                    }

                    return View(manageUserviewModel);
                }
            }
            catch (Exception ex)
            {
                SetMessage("Error Occured! " + ex.Message, Message.Category.Error);
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel viewModel, string returnUrl)
        {
            try
            {
                UserLogic userLogic = new UserLogic();
                if (userLogic.ValidateUser(viewModel.UserName, viewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(viewModel.UserName, false);

                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Home", "Account", new { Area = "Security" });
                    }
                    else
                    {
                        return RedirectToLocal(returnUrl);
                    }
                }
                else
                {
                    TempData["Msg"] = "Login Failed";
                    //SetMessage("Invalid Username or Password!", Message.Category.Error);
                    return View();
                }
            }
            catch (Exception ex)
            {
                SetMessage("Error Occurred! " + ex.Message, Message.Category.Error);
            }
            return View();

        }

        //[HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { Area = "Common" });
            }
        }
    }
}