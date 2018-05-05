using Statement.Core.DomainModels;
using Statement.Core.Dtos.Factor;
using Statement.Core.Dtos.Material;
using Statement.Core.Dtos.MaterialFactor;
using Statement.Data.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Statement.UI.Controllers
{
    public class MaterialFactorController : Controller
    {
        private IMaterialRepository _materialRepository;
        private IFactorRepository _FactorRepository;
        private IMaterialFactorRepository _MaterialFactorRepository;

        public MaterialFactorController(IMaterialRepository materialRepo,
            IFactorRepository factorRepo, IMaterialFactorRepository materialFactorRepo)
        {
            _materialRepository = materialRepo;
            _FactorRepository = factorRepo;
            _MaterialFactorRepository = materialFactorRepo;
        }

        #region List

        public ActionResult List(int id)
        {
            var materialFactorDto = new ListMaterialFactorDto();
            var materialFactor = new MaterialFactor();

            var materialExistDto = _materialRepository.Materials
              .Where(a => _MaterialFactorRepository.MaterialFactors
                     .Where(s => s.FactorId == id)
                     .Select(s => s.MaterialId).Contains(a.Id))
              .Select(a => new ListMaterialDto
              {
                  Id = a.Id,
                  Name = a.Name
              }).ToList();

            materialFactorDto.MaterialExistDto = materialExistDto;

            return View(materialFactorDto);

        }

        #endregion


        #region Index

        [HttpGet]
        public ActionResult Index(int id)
        {
            var materialFactorDto = new ListMaterialFactorDto();
            var materialFactor = new MaterialFactor();

            var factors = _FactorRepository.Factors.Where(a => a.Id == id)
                .Select(a => new ListFactorDto
                {
                    Id = a.Id,
                    CustomerName = a.Customer.FirstName + " " + a.Customer.LastName,
                    Price = a.Price,
                    Date = a.Date

                }).FirstOrDefault();

            TempData["factorId"] = factors.Id;

            materialFactorDto.FactorDto = factors;

            var materialExistDto = _materialRepository.Materials
                .Where(a => _MaterialFactorRepository.MaterialFactors
                       .Where(s => s.FactorId == id)
                       .Select(s => s.MaterialId).Contains(a.Id))
                .Select(a => new ListMaterialDto
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList();

            materialFactorDto.MaterialExistDto = materialExistDto;

            var materialDto = _materialRepository.Materials
                .Where(a => !_MaterialFactorRepository.MaterialFactors
                      .Where(s => s.FactorId == id)
                      .Select(s => s.MaterialId).Contains(a.Id))
                .Select(a => new ListMaterialDto
                {
                    Id = a.Id,
                    Name = a.Name
                });

            materialFactorDto.MaterialDto = materialDto;

            var materialExistId = materialFactorDto.MaterialExistDto
                 .Select(a => a.Id).ToList();

            string listMaterialExistId = string.Join(",", materialExistId);

            materialFactorDto.ListMaterialExistDtoId = listMaterialExistId;

            return View(materialFactorDto);
        }

        [HttpPost]
        public ActionResult Index(int[] material)
        {
            foreach (var id in material)
            {
                var materialFactor = new MaterialFactor();
                materialFactor.FactorId = Convert.ToInt32(TempData["factorId"]);
                materialFactor.MaterialId = id;
                _MaterialFactorRepository.CreateMaterialFactor(materialFactor);
            }

            return RedirectToAction("List", "Customer");
        }
    }

    #endregion
}


