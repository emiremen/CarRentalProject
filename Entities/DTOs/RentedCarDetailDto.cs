using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentedCarDetailDto : IDto
    {
        public string Customer { get; set; }
        public string CompanyName { get; set; }
        public string CarBrand { get; set; }
        public string CarColor { get; set; }
        public int CarModelYear { get; set; }
        public DateTime RentedDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
