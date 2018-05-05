using Statement.Core.DomainModels;
using Statement.Core.Dtos.Material;
using Statement.Data.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Statement.UI.Controllers
{
    public class MaterialController : Controller
    {
        private IMaterialRepository _materialRepository;


        public MaterialController(IMaterialRepository materialRepo)
        {
            _materialRepository = materialRepo;
        }

        #region List

        public ActionResult List()
        {
            var material = _materialRepository.Materials.Select(a => new ListMaterialDto()
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();

            IEnumerable<ListMaterialDto> materialData = material;

            return View(materialData);

        }

        #endregion

        #region Create

        public ActionResult Create()
        {
            var materialDto = new AddMaterialDto();
            return View(materialDto);
        }

        [HttpPost]
        public ActionResult Create(AddMaterialDto materialDto)
        {
            var material = new Material();
            material.Name = materialDto.Name;
           

            _materialRepository.CreateMaterial(material);

            return RedirectToAction("List");
        }

        #endregion

        #region Edit

        [HttpGet]
        public ViewResult Edit(int Id)
        {
            var material = _materialRepository.Materials.Where(a => a.Id == Id)
                .Select(a => new EditMaterialDto()
            {
                Id = a.Id,
               Name = a.Name

            }).FirstOrDefault();

            return View(material);
        }

        [HttpPost]
        public ActionResult Edit(EditMaterialDto vm)
        {
            if (ModelState.IsValid)
            {
                var material = new Material();
                material.Id = vm.Id;
                material.Name = vm.Name;

                _materialRepository.EditMaterial(material);

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
            Material deleteMaterial = _materialRepository.DeleteMaterial(Id);
            if (deleteMaterial != null)
            {
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }

        #endregion
    }
}
