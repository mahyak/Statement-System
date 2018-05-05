using Statement.Core.Dtos.User;
using Statement.Data;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Statement.UI.Controllers
{
    public class LoginVm
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
    public class HomeController : Controller
    {
        #region Index 

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (vm.UserName == "admin" && vm.Password == "admin")
            {
                string authId = Guid.NewGuid().ToString();
                Session["AuthID"] = authId;

                var cookie = new HttpCookie("AuthID");
                cookie.Value = authId;
                Response.Cookies.Add(cookie);

                return RedirectToAction("List", "User");
            }
            return View();

        }

        #endregion

        #region Signin

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SigninDto Vm)
        {

            var db = new StatementDbContext();

            var user = db.Users
                .Where(a => a.UserName == Vm.Username && a.Password == Vm.Password)
                .FirstOrDefault();
            if (user == null)
            {
                ModelState.AddModelError("Username", "Username or Password is incorrect ...!");
                return View();
            }
            
            Session["UserId"] = user.Id;

            return RedirectToAction("List", "Customer");
        }

        #endregion
    }
}
