using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarProductDal());
            //carManager.Add(new Car {BrandId = 1, ColorId = 1, ModelYear = 2014, DailyPrice = 280, Description = "Kiralık benzinli araç" });
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand {CarBrand = "Audi"});
            //brandManager.Add(new Brand {CarBrand = "Volkswagen" });
            //brandManager.Add(new Brand {CarBrand = "BMW" });

            ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color {CarColor = "Kırmızı"});
            //colorManager.Add(new Color {CarColor = "Mavi" });
            //colorManager.Add(new Color {CarColor = "Siyah" });

            Console.WriteLine("------------------------- Cars --------------------------");
            foreach (var car in carManager.GetCarsByBrand(1))
            {
                Console.WriteLine(car.ModelYear + " Model - " + car.Description);
            }

            Console.WriteLine("\n\n\n------------------------- Brands --------------------------");
            foreach (var brand in brandManager.GetAllBrands())
            {
                Console.WriteLine(brand.CarBrand);
            }

            Console.WriteLine("\n\n\n------------------------- Colors --------------------------");
            foreach (var color in colorManager.GetAllColors())
            {
                Console.WriteLine(color.CarColor);
            }
            Console.ReadKey();
        }
    }
}
