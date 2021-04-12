using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public List<CarImage> CarImage { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
        public short CarFindex { get; set; }
    }
}
