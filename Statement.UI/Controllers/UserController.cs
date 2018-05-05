using Statement.Core.DomainModels;
using Statement.Core.Dtos.User;
using Statement.Data.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Statement.UI.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;


        public UserController(IUserRepository userRepo)
        {
            _userRepository = userRepo;
        }

        #region List

        public ActionResult List()
        {
            var user = _userRepository.Users.Select(a => new ListUserDto()
            {
                Id = a.Id,
                Username = a.UserName,
                FirstName = a.FirstName,
                LastName = a.LastName,

            }).ToList();

            IEnumerable<ListUserDto> userData = user;

            return View(userData);

        }

        #endregion

        #region Create

        public ActionResult Create()
        {
            var userDto = new AddUserDto();
            return View(userDto);
        }

        [HttpPost]
        public ActionResult Create(AddUserDto userDto)
        {
            var user = new User();
            user.UserName = userDto.Username;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Password = userDto.Password;
            user.Role = Role.User;

            _userRepository.CreateUser(user);

            return RedirectToAction("List");
        }

        #endregion

        #region Edit

        [HttpGet]
        public ViewResult Edit(int Id)
        {
            var user = _userRepository.Users.Where(a => a.Id == Id).Select(a => new EditUserDto()
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Password = a.Password

        }).FirstOrDefault();

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(EditUserDto vm)
        {
            if (ModelState.IsValid)
            {
                var user = new User();
                user.Id = vm.Id;
                user.FirstName = vm.FirstName;
                user.LastName = vm.LastName;
                user.Password = vm.Password;

                _userRepository.EditUser(user);
                
                return RedirectToAction("List");
            }
            else
            {
                return View(vm);
            }
        }

        #endregion

        #region Delete

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            User deleteUser = _userRepository.DeleteUser(Id);
            if (deleteUser != null)
            {
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }

        #endregion
    }
}
