using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERent.DAL.Entities
{
    public class Salesman
    {
        public int Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime PayedDate { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }


        public ICollection<Apartment> Apartments { get; set; }
    }

    public class Apartment
    {
        public int Id { get; set; }
        public DateTime PublishDate { get; set; }

        public int SalesmanId { get; set; }
        public Salesman Salesman { get; set; }

        public bool SalesmanPayedState { get; set; }


        public decimal Price { get; set; }
        public string PriceInfo { get; set; }

        public int Floor { get; set; }
        public decimal TotalArea { get; set; }
        public decimal LivingArea { get; set; }
        public decimal KitchenArea { get; set; }
        public string OtherInfo { get; set; }



        public int? HouseId { get; set; }
        public House House { get; set; }


        public int? ToiletTypeId { get; set; }
        public ToiletType ToiletType { get; set; }


        public int? BalconyId { get; set; }
        public Balcony Balcony { get; set; }


        public int? RepairTypeId { get; set; }
        public RepairType RepairType { get; set; }


        public int? ElevatorId { get; set; }
        public Elevator Elevator { get; set; }

        public ICollection<ApartmentInclude> ApartmentIncludes { get; set; }

        public ICollection<ImagesInclude> ImagesIncludes { get; set; }
    }

    /// <summary>
    /// Фото квартиры
    /// </summary>
    public class ImagesInclude
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }


    /// <summary>
    /// Материалы стен
    /// </summary>
    public class BuildingType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Информация о доме
    /// </summary>
    public class House
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Year { get; set; }
        public int Floors { get; set; }

        public int? BuildingTypeId { get; set; }
        public BuildingType BuildingType { get; set; }
    }

    /// <summary>
    /// Туалет
    /// </summary>
    public class ToiletType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Балкон / лоджия
    /// </summary>
    public class Balcony
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Ремонт
    /// </summary>
    public class RepairType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Лифт
    /// </summary>
    public class Elevator
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// В квартире имеется
    /// </summary>
    public class ApartmentInclude
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Apartment> Apartments { get; set; }
    }
}
