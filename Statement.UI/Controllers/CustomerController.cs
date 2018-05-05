using Microsoft.AspNet.Identity;
using Statement.Core.DomainModels;
using Statement.Core.Dtos.Customer;
using Statement.Data;
using Statement.Data.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Statement.UI.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepo)
        {
            _customerRepository = customerRepo;
        }

        #region List

        public ActionResult List()
        {
            var id = Convert.ToInt32(Session["UserId"]);

            var customer = _customerRepository.Customers.Where(a => a.UserId == id).
                Select(a => new ListCustomerDto()
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    CellPhone = a.CellPhone,
                    Email = a.Email

                }).ToList();

            return View(customer);

        }

        #endregion

        #region Create

        public ActionResult Create()
        {
            var customerDto = new AddCustomerDto();
            return View(customerDto);
        }

        [HttpPost]
        public ActionResult Create(AddCustomerDto customerDto)
        {
            var customer = new Customer();

            var id = Convert.ToInt32(Session["UserId"]);

            customer.FirstName = customerDto.FirstName;
            customer.LastName = customerDto.LastName;
            customer.CellPhone = customerDto.CellPhone;
            customer.Email = customerDto.Email;
            customer.UserId = id;

            _customerRepository.CreateCustomer(customer);

            return RedirectToAction("List");
        }

        #endregion

        #region Edit

        [HttpGet]
        public ViewResult Edit(int Id)
        {

            var customer = _customerRepository.Customers.Where(a => a.Id == Id).Select(a => new EditCustomerDto()
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Email = a.Email,
                CellPhone = a.CellPhone,
                UserId = a.UserId

            }).FirstOrDefault();

            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(EditCustomerDto vm)
        {
            var id = Convert.ToInt32(Session["UserId"]);

            if (ModelState.IsValid)
            {
                var customer = new Customer();
                customer.Id = vm.Id;
                customer.FirstName = vm.FirstName;
                customer.LastName = vm.LastName;
                customer.Email = vm.Email;
                customer.CellPhone = vm.CellPhone;
                customer.UserId = id;

                _customerRepository.EditCustomer(customer);

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
            Customer deleteUser = _customerRepository.DeleteCustomer(Id);
            if (deleteUser != null)
            {
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }

        #endregion
    }
}