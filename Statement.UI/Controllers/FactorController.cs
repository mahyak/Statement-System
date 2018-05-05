using Statement.Core.DomainModels;
using Statement.Core.Dtos.Factor;
using Statement.Data.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Statement.UI.Controllers
{
    public class FactorController : Controller
    {
        private IFactorRepository _factorRepository;
        private ICustomerRepository _customerRepository;

        public FactorController(IFactorRepository factorRepo, ICustomerRepository customerRepo)
        {
            _factorRepository = factorRepo;
            _customerRepository = customerRepo;
        }

        #region List

        public ActionResult List(int? Id)
        {
            if (Id == null)
            {
                Id = Convert.ToInt32(TempData["CurrentUser"]);
            }
          
            var factor = _factorRepository.Factors.Where(a => a.CustomerId == Id).
                Select(a => new ListFactorDto()
                {
                    Id = a.Id,
                    Price = a.Price,
                    Date = a.Date,
                    CustomerName = a.Customer.FirstName + " " + a.Customer.LastName

                }).ToList();
        

            return View(factor);

        }

        #endregion

        #region Create

        public ActionResult Create(int Id)
        {
            var factorDto = new AddFactorDto();
            factorDto.Customer = _customerRepository.Customers.Where(a => a.Id == Id)
                .Select(a => new SelectListItem()
                {
                    Text = a.FirstName + " " + a.LastName,
                    Value = a.Id.ToString()
                }).ToList();

            return View(factorDto);
        }

        [HttpPost]
        public ActionResult Create(AddFactorDto factorDto)
        {
            var factor = new Factor();

            factor.Price = factorDto.Price;
            factor.Date = DateTime.Now;
            factor.CustomerId = factorDto.CustomerId;

            _factorRepository.CreateFactor(factor);

            TempData["CurrentUser"] = factorDto.CustomerId;

            return RedirectToAction("List");
        }

        #endregion

        #region Edit

        [HttpGet]
        public ActionResult Edit(int Id)
        {

            var factor = _factorRepository.Factors.Where(a => a.Id == Id)
                .Select(a => new EditFactorDto()
                {
                    Id = a.Id,
                    Price = a.Price,
                    CustomerId = a.CustomerId,

                }).FirstOrDefault();

            factor.Customer = _customerRepository.Customers.Where(a => a.Id == factor.CustomerId)
                .Select(a => new SelectListItem()
                {
                    Text = a.FirstName + " " + a.LastName,
                    Value = a.Id.ToString()
                }).ToList();

            if (factor == null)
                return RedirectToAction("List");


            return View(factor);
        }

        [HttpPost]
        public ActionResult Edit(EditFactorDto vm)
        {

            if (ModelState.IsValid)
            {
                var factor = new Factor();
                factor.Id = vm.Id;
                factor.Date = DateTime.Now;
                factor.Price = vm.Price;
                factor.CustomerId = vm.CustomerId;

                _factorRepository.EditFactor(factor);

                TempData["CurrentUser"] = vm.CustomerId;

                return RedirectToAction("List");
            }
            else
            {
                vm.Customer = _customerRepository.Customers
                    .Select(a => new System.Web.Mvc.SelectListItem()
                    {
                        Text = a.FirstName + " " + a.LastName,
                        Value = a.Id.ToString()
                    }).ToList();

                return View(vm);
            }
        }

        #endregion

        #region Delete

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Factor deleteFactor = _factorRepository.DeleteFactor(Id);
            if (deleteFactor != null)
            {
              
                return RedirectToAction("List", "Customer");
            }
            return RedirectToAction("List", "Customer");
        }

        #endregion
    }
}