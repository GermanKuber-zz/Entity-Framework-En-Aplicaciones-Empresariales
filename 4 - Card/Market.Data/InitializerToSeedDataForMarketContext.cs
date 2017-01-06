using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Market.Domain;
using Market.Domain.Enums;

namespace Market.Data
{

    public class InitializerToSeedDataForMarketContext : DropCreateDatabaseIfModelChanges<MarketContext>
    {
        protected override void Seed(MarketContext context)
        {

            var category = new Category
            {
                Name = "Tecnología"

            };
            var productlist = new[] {   new Product
                {
                Category = category,
                Description =@"PANTALLA 13.3 Full HD (1920x1080) | MEMORIA RAM 4GB | ALMACENAMIENTO 128GB SSD | BATERIA Li-ion, 4 celdas, 4125mAh (Integrada) | CERFITICACION AMBIENTAL ENERGY STAR 6.1| TECLADO Retroiluminado | AUDIO Intel HD Audio Micrófono Mono Integrado | GRÁFIC Name=NOTEBOOK VAIO PRO 13G",ProductionStart=DateTime.Now, IsAvailable=true
                },
                                        new Product {Category = category,Description=@"Pantalla LED 7 (1024x600). Proc.Intel Atom SoFia 3G-R. SO Android 5.1. Memoria int. 8Gb- RAM 1Gb. Slot p/micro SD h/32Gb. Cámara post. 2.0Mp- frontal 0.3Mp. Video integrado h/1080p. Wi-Fi. Bluetooth. Micro USB. Bateria Li-Polymero 3.7V 3000mAh. Name=TABLET PC J14",ProductionStart=DateTime.Now, IsAvailable=true },
                                        new Product {Category = category,Description=@"Sistema Operativo Windows 10 - Pantalla 19,5 HD 1600x900 Bright Display - Procesador Intel Pentium 4ta generación - Memoria 4 GB DDR3 SODIMM 1600 MHZ - Unidad , Name=COMPUTADORA AIO E19-I2",ProductionStart=DateTime.Now, IsAvailable=true },
                                        new Product {Category = category,Description=@"Procesador Intel Core i5 | Gráficos Nvidia Gforce GV-N950OC-2GD | Motherboard Gigabyte H110 | Memoria 8GB DDR4 2133MHz HyperX | Fuente Thermaltake TR2 600W", Name="PC GAMER GM-Y 950 I5",ProductionStart=DateTime.Now, IsAvailable=true },
                                        new Product {Category = category,Description=@"Procesador Intel Core i7 | Gráficos Nvidia Gforce GV-N970IX-4GD | Motherboard Gigabyte H170 Gaming 3 | Disco 2TB 7200RPM + HDD SSD 240GB | Realtek ALC1150, 5.1", Name="PC GAMER GM-Y970 I7",ProductionStart=DateTime.Now, IsAvailable=true },
                                        new Product {Category = category,Description=@"SAMSUNG J7 2016 NEGRO J710 LIb", Name="CELULAR LIBRE GALAXY J7 2016 NEGRO",ProductionStart=DateTime.Now, IsAvailable=true }
                                    };

            var mariano = new Customer { FirstName = "Mariano", LastName = "Perez", DateOfBirth = new DateTime(2010, 1, 1) };
            var marianoOrders = new List<Order> {
                    new Order
                    {
                        OrderDate = new DateTime(2015, 12, 25),
                        OrderSource = OrderSource.Online,
                        LineItems = new[] {new LineItem {Quantity=6, ProductId=2},
                                            new LineItem {Quantity=6, ProductId=5},
                                            new LineItem {Quantity=7, ProductId=3} }
                    },
                    new Order
                    {
                        OrderDate = new DateTime(2015, 12, 24),
                        OrderSource = OrderSource.InPerson,
                        LineItems=  new[] {
                                            new LineItem
                                            {
                                                Quantity=1,
                                                ProductId =3
                                            },
                                            new LineItem
                                            {
                                                Quantity=1,
                                                ProductId =1
                                            },
                                             new LineItem
                                            {
                                                Quantity=4,
                                                ProductId =4
                                            }
                        }
                    },
                    new Order
                    {
                        OrderDate = new DateTime(2015, 12, 23),
                        OrderSource = OrderSource.Email
                    },
                    new Order
                    {
                        OrderDate = new DateTime(2015, 12, 23),
                        OrderSource = OrderSource.Online,
                         LineItems = new[] {new LineItem {Quantity=6, ProductId=2},
                                            new LineItem {Quantity=6, ProductId=5},
                                            new LineItem {Quantity=7, ProductId=3} }
                    }};
            marianoOrders.ForEach(o => mariano.Orders.Add(o));

            var martin = new Customer { FirstName = "Martín", LastName = "Valdez", DateOfBirth = new DateTime(1988, 2, 3) };
            var juanMiron = new Customer { FirstName = "Juan", LastName = "Mirón", DateOfBirth = new DateTime(1988, 2, 3) };
            context.Products.AddOrUpdate(productlist);
            context.SaveChanges();
            context.Customers.AddOrUpdate(new[] { mariano, martin, juanMiron });

            base.Seed(context);
        }
    }
}