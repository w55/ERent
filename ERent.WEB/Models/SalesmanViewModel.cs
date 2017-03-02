using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERent.WEB.Models
{
    public class SalesmanViewModel
    {
        public int Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime PayedDate { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }


    public class ApartmentViewModel
    {
        public int Id { get; set; }
        public DateTime PublishDate { get; set; }

        public int SalesmanId { get; set; }
        public SalesmanViewModel Salesman { get; set; }

        public bool SalesmanPayedState { get; set; }


        public decimal Price { get; set; }
        public string PriceInfo { get; set; }

        public int Floor { get; set; }
        public decimal TotalArea { get; set; }
        public decimal LivingArea { get; set; }
        public decimal KitchenArea { get; set; }
        public string OtherInfo { get; set; }



        public int? HouseId { get; set; }
        public HouseViewModel House { get; set; }


        public int? ToiletTypeId { get; set; }
        public ToiletTypeViewModel ToiletType { get; set; }


        public int? BalconyId { get; set; }
        public BalconyViewModel Balcony { get; set; }


        public int? RepairTypeId { get; set; }
        public RepairTypeViewModel RepairType { get; set; }


        public int? ElevatorId { get; set; }
        public ElevatorViewModel Elevator { get; set; }

        public ICollection<ApartmentIncludeViewModel> ApartmentIncludes { get; set; }

        public ICollection<ImagesIncludeViewModel> ImagesIncludes { get; set; }
    }

    /// <summary>
    /// Фото квартиры
    /// </summary>
    public class ImagesIncludeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }

    /// <summary>
    /// В квартире имеется
    /// </summary>
    public class ApartmentIncludeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Балкон / лоджия
    /// </summary>
    public class BalconyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Туалет
    /// </summary>
    public class ToiletTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Ремонт
    /// </summary>
    public class RepairTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Лифт
    /// </summary>
    public class ElevatorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Материалы стен
    /// </summary>
    public class BuildingTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Информация о доме
    /// </summary>
    public class HouseViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Year { get; set; }
        public int Floors { get; set; }

        public int? BuildingTypeId { get; set; }
        public BuildingTypeViewModel BuildingType { get; set; }
    }
}