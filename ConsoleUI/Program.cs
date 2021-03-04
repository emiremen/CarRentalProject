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

            Console.WriteLine("------------------------- Cars --------------------------");
            if (carManager.GetCarDetails().Success)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine("{0} | {1} | {2} | {3} | {4}", car.BrandName, car.ColorName, car.ModelYear, car.DailyPrice, car.Description);
                }
            }
            else
            {
                Console.WriteLine(carManager.GetCarDetails().Message);
            }

            Console.ReadKey();
        }
    }
}
