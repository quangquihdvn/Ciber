using Ciber.Infrastructure.Infrastructure.EF;
using Ciber.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Infrastructure.EF
{
    public class CiberDbContextSeed
    {
        public async Task SeedAsync(CiberDbContext context,
            ILogger<CiberDbContextSeed> logger)
        {
            await context.Database.CreateExecutionStrategy().Execute(async () =>
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (!context.Users.Any())
                        {
                            var users = SeedUsers();
                            context.Users.AddRange(users);
                        }

                        if (!context.Categories.Any())
                        {
                            var catogories = SeedCategories();
                            context.Categories.AddRange(catogories);
                        }

                        if (!context.Products.Any())
                        {
                            var products = SeedProducts();
                            context.Products.AddRange(products);
                        }

                        if (!context.Customers.Any())
                        {
                            var customers = SeedCustomers();
                            context.Customers.AddRange(customers);
                        }

                        if (!context.Orders.Any())
                        {
                            var orders = SeedOrders();
                            context.Orders.AddRange(orders);
                        }

                        await context.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex.Message);
                        transaction.Rollback();
                    }
                }
            });
        }

        private List<User> SeedUsers()
        {
            var hasher = new PasswordHasher<User>();
            return new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "admin",
                    Email = "quangquihdvn@gmail.com",
                    Password = hasher.HashPassword(null, "ciber@123"),
                    FullName = "Bui Quang Qui",
                    Address = "Thanh Lan, HN",
                    Phone = "0374868675",
                }
            };
        }
        private List<Category> SeedCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    Id = Guid.Parse("9881B249-2AD7-445E-8158-F72D3254DC33"),
                    Name = "Cat1",
                    Description = "Category description 1"
                },
                new Category
                {
                    Id = Guid.Parse("5AF9F217-B032-403D-AD3E-727AF9654110"),
                    Name = "Cat2",
                    Description = "Category description 2"
                }
            };
        }

        private List<Product> SeedProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = Guid.Parse("807267FD-8F2E-40FA-9BA8-A96F4B70AC37"),
                    Name = "prod1 - cat1",
                    Description = "Product description 1",
                    CategoryId = Guid.Parse("9881B249-2AD7-445E-8158-F72D3254DC33"),
                    Price = 500,
                    Quantity = 10

                },
                new Product
                {
                    Id = Guid.Parse("BF2FED1C-080A-4997-AF05-B8D9572A7D01"),
                    Name = "prod2 - cat1",
                    Description = "Product description 2 - cat1",
                    CategoryId = Guid.Parse("9881B249-2AD7-445E-8158-F72D3254DC33"),
                    Price = 550,
                    Quantity = 10

                },
                new Product
                {
                    Id = Guid.Parse("655AD26F-2D4E-4BF6-AD0C-32673B289C9E"),
                    Name = "prod3 - cat2",
                    Description = "Product description 3",
                    CategoryId = Guid.Parse("5AF9F217-B032-403D-AD3E-727AF9654110"),
                    Price = 700,
                    Quantity = 20
                },
                new Product
                {
                    Id = Guid.Parse("52BF589E-FA14-48C4-87A9-CB2AFD77DD18"),
                    Name = "prod4 - cat2",
                    Description = "Product description 4",
                    CategoryId = Guid.Parse("5AF9F217-B032-403D-AD3E-727AF9654110"),
                    Price = 700,
                    Quantity = 20
                },
                new Product
                {
                    Id = Guid.Parse("0395E41A-6E87-4598-8054-BFC15598E08B"),
                    Name = "prod5 - cat2",
                    Description = "Product description 4",
                    CategoryId = Guid.Parse("5AF9F217-B032-403D-AD3E-727AF9654110"),
                    Price = 800,
                    Quantity = 30
                },
                new Product
                {
                    Id = Guid.Parse("A3F9A137-C7FD-4AD4-B577-C501EAE67D3D"),
                    Name = "prod5 - cat2",
                    Description = "Product description 5",
                    CategoryId = Guid.Parse("5AF9F217-B032-403D-AD3E-727AF9654110"),
                    Price = 850,
                    Quantity = 35
                },
                new Product
                {
                    Id = Guid.Parse("0FEC5596-FD11-43D8-B6E1-EE3349707A2A"),
                    Name = "prod6 - cat2",
                    Description = "Product description 6",
                    CategoryId = Guid.Parse("5AF9F217-B032-403D-AD3E-727AF9654110"),
                    Price = 850,
                    Quantity = 35
                },
                new Product
                {
                    Id = Guid.Parse("2B7E162F-0064-4A54-816F-F256E9FF2C5C"),
                    Name = "prod7 - cat2",
                    Description = "Product description 7",
                    CategoryId = Guid.Parse("5AF9F217-B032-403D-AD3E-727AF9654110"),
                    Price = 850,
                    Quantity = 45
                },
                new Product
                {
                    Id = Guid.Parse("5FC55456-B7F6-4AE7-9A40-7B5A89768A9F"),
                    Name = "prod8 - cat2",
                    Description = "Product description 8",
                    CategoryId = Guid.Parse("5AF9F217-B032-403D-AD3E-727AF9654110"),
                    Price = 900,
                    Quantity = 50
                },
                new Product
                {
                    Id = Guid.Parse("42F31FAD-6539-4DCD-9F0B-3E9F4FAC68F7"),
                    Name = "prod9 - cat2",
                    Description = "Product description 9",
                    CategoryId = Guid.Parse("5AF9F217-B032-403D-AD3E-727AF9654110"),
                    Price = 950,
                    Quantity = 55
                },
                new Product
                {
                    Id = Guid.Parse("5BF014FB-71DE-4B0A-9D89-459767CAC937"),
                    Name = "prod10 - cat2",
                    Description = "Product description 10",
                    CategoryId = Guid.Parse("5AF9F217-B032-403D-AD3E-727AF9654110"),
                    Price = 1000,
                    Quantity = 50
                },
                new Product
                {
                    Id = Guid.Parse("3EF7770B-5187-4847-8D15-71FA6064951B"),
                    Name = "prod11 - cat2",
                    Description = "Product description 11",
                    CategoryId = Guid.Parse("5AF9F217-B032-403D-AD3E-727AF9654110"),
                    Price = 900,
                    Quantity = 50
                },
            };
        }

        private List<Customer> SeedCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = Guid.Parse("1662FE1B-529C-436C-A72B-320B1D9E7D9D"),
                    Name = "Cus1",
                    Address = "Address 1"
                },
                new Customer
                {
                    Id = Guid.Parse("4C719FCD-FBC0-45BE-A976-A069669E0CAF"),
                    Name = "Cus2",
                    Address = "Address 2"
                }
            };
        }

        private List<Order> SeedOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    Id = Guid.NewGuid(),
                    Name = "Order1",
                    CustomerId = Guid.Parse("1662FE1B-529C-436C-A72B-320B1D9E7D9D"),
                    ProductId = Guid.Parse("807267FD-8F2E-40FA-9BA8-A96F4B70AC37"),
                    Amount = 10,
                    OrderDate = DateTime.Now
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Name = "Order2",
                    CustomerId = Guid.Parse("1662FE1B-529C-436C-A72B-320B1D9E7D9D"),
                    ProductId = Guid.Parse("655AD26F-2D4E-4BF6-AD0C-32673B289C9E"),
                    Amount = 20,
                    OrderDate = DateTime.Now
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Name = "Order3",
                    CustomerId = Guid.Parse("1662FE1B-529C-436C-A72B-320B1D9E7D9D"),
                    ProductId = Guid.Parse("52BF589E-FA14-48C4-87A9-CB2AFD77DD18"),
                    Amount = 20,
                    OrderDate = DateTime.Now
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Name = "Order4",
                    CustomerId = Guid.Parse("1662FE1B-529C-436C-A72B-320B1D9E7D9D"),
                    ProductId = Guid.Parse("BF2FED1C-080A-4997-AF05-B8D9572A7D01"),
                    Amount = 20,
                    OrderDate = DateTime.Now
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Name = "Order5",
                    CustomerId = Guid.Parse("1662FE1B-529C-436C-A72B-320B1D9E7D9D"),
                    ProductId = Guid.Parse("655AD26F-2D4E-4BF6-AD0C-32673B289C9E"),
                    Amount = 20,
                    OrderDate = DateTime.Now
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Name = "Order6",
                    CustomerId = Guid.Parse("1662FE1B-529C-436C-A72B-320B1D9E7D9D"),
                    ProductId = Guid.Parse("655AD26F-2D4E-4BF6-AD0C-32673B289C9E"),
                    Amount = 20,
                    OrderDate = DateTime.Now
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Name = "Order7",
                    CustomerId = Guid.Parse("1662FE1B-529C-436C-A72B-320B1D9E7D9D"),
                    ProductId = Guid.Parse("5FC55456-B7F6-4AE7-9A40-7B5A89768A9F"),
                    Amount = 20,
                    OrderDate = DateTime.Now
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Name = "Order8",
                    CustomerId = Guid.Parse("1662FE1B-529C-436C-A72B-320B1D9E7D9D"),
                    ProductId = Guid.Parse("2B7E162F-0064-4A54-816F-F256E9FF2C5C"),
                    Amount = 20,
                    OrderDate = DateTime.Now
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Name = "Order9",
                    CustomerId = Guid.Parse("1662FE1B-529C-436C-A72B-320B1D9E7D9D"),
                    ProductId = Guid.Parse("0FEC5596-FD11-43D8-B6E1-EE3349707A2A"),
                    Amount = 20,
                    OrderDate = DateTime.Now
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Name = "Order10",
                    CustomerId = Guid.Parse("1662FE1B-529C-436C-A72B-320B1D9E7D9D"),
                    ProductId = Guid.Parse("A3F9A137-C7FD-4AD4-B577-C501EAE67D3D"),
                    Amount = 20,
                    OrderDate = DateTime.Now
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Name = "Order11",
                    CustomerId = Guid.Parse("1662FE1B-529C-436C-A72B-320B1D9E7D9D"),
                    ProductId = Guid.Parse("0395E41A-6E87-4598-8054-BFC15598E08B"),
                    Amount = 20,
                    OrderDate = DateTime.Now
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Name = "Order12",
                    CustomerId = Guid.Parse("1662FE1B-529C-436C-A72B-320B1D9E7D9D"),
                    ProductId = Guid.Parse("52BF589E-FA14-48C4-87A9-CB2AFD77DD18"),
                    Amount = 20,
                    OrderDate = DateTime.Now
                },
            };
        }
    }
}
