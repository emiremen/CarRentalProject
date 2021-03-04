using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.CarBrand.Length >= 2)
            {
                _brandDal.Add(brand);
            }
            else
            {
                Console.WriteLine("Marka ismi minimum 2 karakter olabilir.");
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public List<Brand> GetAllBrands()
        {
            return _brandDal.GetAll();
        }

        public Brand GetBrandById(int Id)
        {
            return _brandDal.GetById(p => p.Id == Id);
        }

        public void Update(Brand brand)
        {
            if (brand.CarBrand.Length >= 2)
            {
                _brandDal.Update(brand);
            }
            else
            {
                Console.WriteLine("Marka ismi minimum 2 karakter olabilir.");
            }
        }
    }
}
