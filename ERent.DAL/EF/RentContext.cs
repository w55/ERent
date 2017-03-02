using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ERent.DAL.Entities;


namespace ERent.DAL.EF
{
    public class RentContext : DbContext
    {
        public DbSet<Salesman> Salesmans { get; set; }
        public DbSet<Apartment> Apartments { get; set; }

        public DbSet<ImagesInclude> ImagesIncludes { get; set; }


        public DbSet<BuildingType> BuildingTypes { get; set; }
        public DbSet<House> Houses { get; set; }

        public DbSet<ToiletType> ToiletTypes { get; set; }
        public DbSet<Balcony> Balconies { get; set; }
        public DbSet<RepairType> RepairTypes { get; set; }
        public DbSet<Elevator> Elevators { get; set; }

        public DbSet<ApartmentInclude> ApartmentIncludes { get; set; }
 
        static RentContext()
        {
            // db initializer for DEBUG only
            Database.SetInitializer<RentContext>(new RentDbInitializer());
        }
        public RentContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    /// <summary>
    /// db initializer for DEBUG only
    /// </summary>
    public class RentDbInitializer : DropCreateDatabaseIfModelChanges<RentContext>
    {
        // DropCreateDatabaseAlways  <->  DropCreateDatabaseIfModelChanges
        protected override void Seed(RentContext db)
        {
            // Salesmans
            Salesman sale1 = new Salesman { RegisterDate = DateTime.Now.AddYears(-1), PayedDate = DateTime.Now.AddDays(-35), Name = "Иванов И.И.", Email = "ivanov@mail.ru", PhoneNumber = "+7 926 750-00-88" };
            Salesman sale2 = new Salesman { RegisterDate = DateTime.Now.AddMonths(-10), PayedDate = DateTime.Now.AddDays(-25), Name = "Петров П.П.", Email = "petrov@mail.ru", PhoneNumber = "+7 921 750-55-00" };
            Salesman sale3 = new Salesman { RegisterDate = DateTime.Now.AddMonths(-2), PayedDate = DateTime.Now.AddDays(-15), Name = "Сидоров С.С.", Email = "sidorov@mail.ru", PhoneNumber = "+7 926 760-33-33" };
            db.Salesmans.AddRange(new List<Salesman> { sale1, sale2, sale3 });
            db.SaveChanges();

            // BuildingTypes
            BuildingType build1 = new BuildingType { Name = "кирпичный" };
            BuildingType build2 = new BuildingType { Name = "панельный" };
            BuildingType build3 = new BuildingType { Name = "монолитный" };
            db.BuildingTypes.AddRange(new List<BuildingType> { build1, build2, build3 });
            db.SaveChanges();

            // Houses
            House house1 = new House { Address = "Сиреневый проезд 14К2", Year = 1969, Floors = 12, BuildingType = build1 };
            House house2 = new House { Address = "Кирпичный переулок 18К5", Year = 1979, Floors = 10, BuildingType = build2 };
            House house3 = new House { Address = "1-я Парковая 67", Year = 1988, Floors = 25, BuildingType = build3 };
            db.Houses.AddRange(new List<House> { house1, house2, house3 });
            db.SaveChanges();


            // ToiletTypes
            ToiletType toilet1 = new ToiletType { Name = "совмещенный" };
            ToiletType toilet2 = new ToiletType { Name = "раздельный" };
            db.ToiletTypes.AddRange(new List<ToiletType> { toilet1, toilet2 });
            db.SaveChanges();


            // Balconies
            Balcony balcony1 = new Balcony { Name = "балкон" };
            Balcony balcony2 = new Balcony { Name = "лоджия" };
            Balcony balcony3 = new Balcony { Name = "балкон + лоджия" };
            db.Balconies.AddRange(new List<Balcony> { balcony1, balcony2, balcony3 });
            db.SaveChanges();



            // RepairTypes
            RepairType repair1 = new RepairType { Name = "косметический" };
            RepairType repair2 = new RepairType { Name = "евроремонт" };
            RepairType repair3 = new RepairType { Name = "дизайнерский" };
            RepairType repair4 = new RepairType { Name = "без ремонта" };
            db.RepairTypes.AddRange(new List<RepairType> { repair1, repair2, repair3, repair4 });
            db.SaveChanges();

            // Elevator
            Elevator elevator1 = new Elevator { Name = "обычный" };
            Elevator elevator2 = new Elevator { Name = "грузовой" };
            Elevator elevator3 = new Elevator { Name = "обычный + грузовой" };
            db.Elevators.AddRange(new List<Elevator> { elevator1, elevator2, elevator3 });
            db.SaveChanges();

            // ApartmentIncludes
            ApartmentInclude include1 = new ApartmentInclude { Name = "мебель" };
            ApartmentInclude include2 = new ApartmentInclude { Name = "холодильник" };
            ApartmentInclude include3 = new ApartmentInclude { Name = "стиральная машина" };
            ApartmentInclude include4 = new ApartmentInclude { Name = "интернет" };
            ApartmentInclude include5 = new ApartmentInclude { Name = "телевизор" };
            ApartmentInclude include6 = new ApartmentInclude { Name = "кондиционер" };
            ApartmentInclude include7 = new ApartmentInclude { Name = "посудомоечная машина" };
            ApartmentInclude include8 = new ApartmentInclude { Name = "телефон" };
            ApartmentInclude include9 = new ApartmentInclude { Name = "ванна" };
            db.ApartmentIncludes.AddRange(new List<ApartmentInclude> { include1, include2, include3, include4, include5, include6, include7, include8, include9 });
            db.SaveChanges();


            // Images for apartments
            ImagesInclude img01 = new ImagesInclude { Name = "вид 1", Path = "..//Content//207-1.jpg"};
            ImagesInclude img02 = new ImagesInclude { Name = "вид 2", Path = "..//Content//207-2.jpg" };
            ImagesInclude img03 = new ImagesInclude { Name = "вид 3", Path = "..//Content//207-3.jpg" };
            ImagesInclude img04 = new ImagesInclude { Name = "вид 1", Path = "..//Content//208-1.jpg" };
            ImagesInclude img05 = new ImagesInclude { Name = "вид 2", Path = "..//Content//208-2.jpg" };
            ImagesInclude img06 = new ImagesInclude { Name = "вид 3", Path = "..//Content//208-3.jpg" };
            ImagesInclude img07 = new ImagesInclude { Name = "вид 4", Path = "..//Content//208-4.jpg" };
            ImagesInclude img08 = new ImagesInclude { Name = "вид 1", Path = "..//Content//209-1.jpg" };
            ImagesInclude img09 = new ImagesInclude { Name = "вид 2", Path = "..//Content//209-2.jpg" };
            db.ImagesIncludes.AddRange(new List<ImagesInclude> { img01, img02, img03, img04, img05, img06, img07, img08, img09 });
            db.SaveChanges();


            // Apartments
            Apartment apt1 = new Apartment { 
                PublishDate = DateTime.Now.AddDays(-2), 
                Salesman = sale1, 
                SalesmanPayedState = true, 
                Price = 20000m, 
                PriceInfo = "на длительный срок (от года), коммунальные платежи включены (кроме счетчиков)", 
                Floor = 1, 
                TotalArea = 36m, 
                LivingArea = 20m, 
                KitchenArea = 10m, 
                OtherInfo = "Сдаётся квартира ПОСЛЕ КАЧЕСТВЕННОГО РЕМОНТА.", 
                House = house1, 
                ToiletType = toilet1, 
                Balcony = balcony1, 
                RepairType = repair1, 
                Elevator = elevator1, 
                ApartmentIncludes = new List<ApartmentInclude> { include1, include4, include9 },
                ImagesIncludes = new List<ImagesInclude> { img01, img02, img03 }
            };

            Apartment apt2 = new Apartment { 
                PublishDate = DateTime.Now.AddDays(-1), 
                Salesman = sale2, 
                SalesmanPayedState = true, 
                Price = 21000m, 
                PriceInfo = "1 мес. предоплата + залог 10 000 руб., комиссия 25%", 
                Floor = 10, 
                TotalArea = 38m, 
                LivingArea = 22m, 
                KitchenArea = 9m, 
                OtherInfo = "Укомплектована минимумом мебели. Быт техника в наличии.", 
                House = house2, 
                ToiletType = toilet2, 
                Balcony = balcony2, 
                RepairType = repair1, 
                Elevator = elevator2, 
                ApartmentIncludes = new List<ApartmentInclude> { include2, include5, include8 }, 
                ImagesIncludes = new List<ImagesInclude> { img04, img05, img06, img07 } };

            Apartment apt3 = new Apartment { 
                PublishDate = DateTime.Now.AddHours(-10), 
                Salesman = sale3, 
                SalesmanPayedState = true, 
                Price = 20000m, 
                PriceInfo = "на длительный срок (от года)+ залог 20 000 руб., комиссия 50%", 
                Floor = 12, 
                TotalArea = 30m, 
                LivingArea = 18m, 
                KitchenArea = 8m, 
                OtherInfo = "Санузел совмещен. Балкона нет. Сдадим приличным, платежеспособным.", 
                House = house3, 
                ToiletType = toilet1, 
                Balcony = balcony3, 
                RepairType = repair4, 
                Elevator = elevator3, 
                ApartmentIncludes = new List<ApartmentInclude> { include1, include3, include4, include7, include8 }, 
                ImagesIncludes = new List<ImagesInclude> { img08, img09 } };

            db.Apartments.AddRange(new List<Apartment> { apt1, apt2, apt3 });
            db.SaveChanges();
        }
    }
}
