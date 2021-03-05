using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentedCarDetailDto : IDto
    {
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string CarBrand { get; set; }
        public string CarColor { get; set; }
        public DateTime RentedDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
