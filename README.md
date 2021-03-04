# CarRentalProject
C# Car Rental Console Project


- ##### CRUD samples
```csharp
    carManager.Delete(new Car { Id = 5, BrandId = 3, ColorId = 2, ModelYear = 2014, DailyPrice = 300, Description = "Kiralık dizel araç" });
    carManager.Add(new Car { BrandId = 3, ColorId = 2, ModelYear = 2014, DailyPrice = 300, Description = "Kiralık dizel araç" });
    carManager.Update(new Car { Id = 1005, BrandId = 2, ColorId = 2, ModelYear = 2014, DailyPrice = 300, Description = "Kiralık dizel araç" });
```

- ##### Add DB Sample Data
```csharp
    CarManager carManager = new CarManager(new EfCarProductDal());
    carManager.Add(new Car { BrandId = 1, ColorId = 3, ModelYear = 2017, DailyPrice = 350, Description = "Kiralık benzinli araç" });
    carManager.Add(new Car { BrandId = 3, ColorId = 2, ModelYear = 2014, DailyPrice = 300, Description = "Kiralık dizel araç" });
    carManager.Add(new Car { BrandId = 3, ColorId = 1, ModelYear = 2008, DailyPrice = 270, Description = "Kiralık lpgli araç" });
    carManager.Add(new Car { BrandId = 2, ColorId = 1, ModelYear = 2020, DailyPrice = 400, Description = "Kiralık elektrikli araç" });

    BrandManager brandManager = new BrandManager(new EfBrandDal());
    brandManager.Add(new Brand { CarBrand = "Audi" });
    brandManager.Add(new Brand { CarBrand = "Tesla" });
    brandManager.Add(new Brand { CarBrand = "BMW" });

    ColorManager colorManager = new ColorManager(new EfColorDal());
    colorManager.Add(new Color { CarColor = "Beyaz" });
    colorManager.Add(new Color { CarColor = "Gümüş" });
    colorManager.Add(new Color { CarColor = "Siyah" });
```
