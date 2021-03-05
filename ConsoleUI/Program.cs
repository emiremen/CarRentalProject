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
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //var user = new User { FirstName = "Muhammed", LastName = "EMEN", Email = "emen@mail.com", Password = "123456" };
            //userManager.Add(user);
            //var customer = new Customer {UserId = user.Id, CompanyName = "Nexus Corp." };
            //customerManager.Add(customer);
            //var rental = new Rental { CarId = 4, CustomerId=customer.Id, RentedDate = new DateTime(2021, 3, 1), ReturnDate = new DateTime(2021, 3, 5) };
            //rentalManager.Add(rental);

            CarManager carManager = new CarManager(new EfCarProductDal());
            //CarManagerTest(carManager);

            Console.WriteLine("------------------------- Rentals --------------------------");
            if (rentalManager.GetRentedCarDetail().Success)
            {
                foreach (var item in rentalManager.GetRentedCarDetail().Data)
                {
                    Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5}", item.CustomerName, item.CompanyName, item.CarBrand,item.CarColor,item.RentedDate,item.ReturnDate);
                }
            }

            Console.ReadKey();
        }

        private static void CarManagerTest(CarManager carManager)
        {
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
        }
    }
}
