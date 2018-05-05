using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Statement.Core.Dtos.Factor
{
    public class AddFactorDto
    {
        [Display(Name = "Price")]
        [Required(ErrorMessage = "{0} is required.")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public string Price { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "{0} is required.")]
        public DateTime Date { get; set; }

        public List<SelectListItem> Customer { get; set; }

        [Display(Name = "Customer")]
        [Required(ErrorMessage = "{0} is required.")]
        public int CustomerId { get; set; }
    }
}
