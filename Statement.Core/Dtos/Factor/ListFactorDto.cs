using System;
using System.Web.Mvc;

namespace Statement.Core.Dtos.Factor
{
    public class ListFactorDto
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Price { get; set; }

        public DateTime Date { get; set; } 

        public string CustomerName { get; set; }
    }
}
