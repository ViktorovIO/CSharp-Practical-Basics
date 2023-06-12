using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace LogisticManagerWorkspace.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LogisticManagerWorkspaceContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LogisticManagerWorkspaceContext>>()))
            {
                context.Categories.AddRange(
                    new Category
                    {
                        Id = 1,
                        Name = "Перевозки",
                        Description = "Перевозка грузов на любое расстояние"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Международные перевозки",
                        Description = "Перевозка грузов в другую страну"
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Перевозки по России",
                        Description = "Перевозка грузов в любой город России"
                    },
                    new Category
                    {
                        Id = 4,
                        Name = "Перевозки в городе",
                        Description = "Перевозка грузов в пределах города"
                    },
                    new Category
                    {
                        Id = 5,
                        Name = "Аренда техники",
                        Description = "Аренда специальной техники"
                    },
                    new Category
                    {
                        Id = 6,
                        Name = "Аренда газели",
                        Description = "Аренда грузового автомобиля, вместимостью до 2 тонн"
                    }
                );

                context.Clients.AddRange(
                    new Client
                    {
                        Id = 1,
                        Name = "ООО Ромашка",
                        Phone = "89221804537",
                        Email = "romashka@mail.ru",
                        City = "Москва",
                        Address = "ул. Техников, д. 24, оф. 31"
                    },
                    new Client
                    {
                        Id = 2,
                        Name = "ИП Васильев О.О.",
                        Phone = "89120042202",
                        Email = "vasyan@mail.ru",
                        City = "Самара",
                        Address = "ул. Учителей, д. 8, оф. 1"
                    },
                    new Client
                    {
                        Id = 3,
                        Name = "ЗАО Брусника",
                        Phone = "83432140218",
                        Email = "brusnika@mail.ru",
                        City = "Екатеринбург",
                        Address = "ул. Энгельса, д. 36, оф. 1101"
                    },
                    new Client
                    {
                        Id = 4,
                        Name = "ПАО Уральское отделение Сбербанка",
                        Phone = "88004000600",
                        Email = "ural@sberbank.ru",
                        City = "Екатеринбург",
                        Address = "ул. Куйбышева, д. 55"
                    }
                );

                context.Statuses.AddRange(
                    new Status
                    {
                        Name = "В работе",
                        Description = "Ведется оказание услуг"
                    },
                    new Status
                    {
                        Name = "Завершено",
                        Description = "Услуга оказана"
                    },
                    new Status
                    {
                        Name = "Отказ",
                        Description = "Отказ от услуги"
                    },
                    new Status
                    {
                        Name = "Ожидает оплаты",
                        Description = "Услуга ожидает оплаты"
                    }
                );

                context.Services.AddRange(
                    new Service
                    {
                        Id = 1,
                        Name = "Перевозка вещей",
                        Description = "Перевозка из пункта А в пункт Б",
                        Date = "11.01.2020",
                        ClientName = "ООО Ромашка",
                        Cost = "3000",
                        Status = "Завершено"
                    },
                    new Service
                    {
                        Id = 2,
                        Name = "Доставка документов",
                        Description = "Доставка документов из офиса компании",
                        Date = "29.04.2020",
                        ClientName = "ООО Ромашка",
                        Cost = "1500",
                        Status = "Отказано"
                    },
                    new Service
                    {
                        Id = 3,
                        Name = "Перевозка вещей",
                        Description = "Перевозка из пункта А в пункт Б",
                        Date = "20.02.2019",
                        ClientName = "ИП Васильев О.О.",
                        Cost = "5200",
                        Status = "Завершено"
                    },
                    new Service
                    {
                        Id = 4,
                        Name = "Перевозка в другой город на газели",
                        Description = "Перевозка вещей в другой город на малотоннажном грузовом автомобиле",
                        Date = "11.08.2020",
                        ClientName = "ЗАО Брусника",
                        Cost = "3000",
                        Status = "Ожидает оплаты"
                    },
                    new Service
                    {
                        Id = 5,
                        Name = "Доставка предметов со склада",
                        Description = "Доставка мебели со склада",
                        Date = "12.08.2020",
                        ClientName = "ООО Ромашка",
                        Cost = "10000",
                        Status = "В работе"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}