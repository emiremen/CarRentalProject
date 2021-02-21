using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class CarProductDal : ICarProductDal
    {
        List<Brand> _brands = new List<Brand>
        {
            new Brand{Id = 1, CarBrand="Volkswagen"},
            new Brand{Id = 2, CarBrand="Kia"},
            new Brand{Id = 3, CarBrand="Tesla"}
        };

        List<Color> _colors = new List<Color>
        {
            new Color{Id = 1, CarColor = "Black"},
            new Color{Id = 2, CarColor = "White"},
            new Color{Id = 3, CarColor = "Silver"}
        };

        List<Car> _cars = new List<Car>
        {
            new Car{ Id = 1, BrandId = 1, ColorId= 1, ModelYear= 2006, DailyPrice=260, Description= "Volkswagen Benzinli Kiralık araç."},
            new Car{ Id = 2, BrandId = 2, ColorId= 2, ModelYear= 2013, DailyPrice=350, Description= "Kia Dizel Kiralık araç."},
            new Car{ Id = 3, BrandId = 2, ColorId= 2, ModelYear= 2015, DailyPrice=300, Description= "Kia Benzinli Kiralık araç."},
            new Car{ Id = 4, BrandId = 3, ColorId= 3, ModelYear= 2018, DailyPrice=400, Description= "Tesla Elektrikli Kiralık araç."}
        };

        

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car toRemoveCar = _cars.SingleOrDefault(p=>p.Id == car.Id);
            _cars.Remove(toRemoveCar);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.Id == carId);
        }

        public void Update(Car car)
        {
            Car toUpdateCar = _cars.SingleOrDefault(p => p.Id == car.Id);
            toUpdateCar.Id = car.Id;
            toUpdateCar.BrandId = car.BrandId;
            toUpdateCar.ColorId = car.ColorId;
            toUpdateCar.ModelYear = car.ModelYear;
            toUpdateCar.DailyPrice = car.DailyPrice;
            toUpdateCar.Description = car.Description;
        }
    }
}
