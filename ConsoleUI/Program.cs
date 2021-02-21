using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carService = new CarManager(new CarProductDal());

            foreach (var car in carService.GetAll())
            {
                Console.WriteLine(car.ModelYear + car.Description);
            }
            Console.ReadKey();
        }
    }
}
