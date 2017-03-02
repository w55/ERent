using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERent.BLL.DTO
{
    public class SalesmanDTO
    {
        public int Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime PayedDate { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ApartmentDTO
    {
        public int Id { get; set; }
        public DateTime PublishDate { get; set; }

        public int SalesmanId { get; set; }
        public SalesmanDTO Salesman { get; set; }

        public bool SalesmanPayedState { get; set; }


        public decimal Price { get; set; }
        public string PriceInfo { get; set; }

        public int Floor { get; set; }
        public decimal TotalArea { get; set; }
        public decimal LivingArea { get; set; }
        public decimal KitchenArea { get; set; }
        public string OtherInfo { get; set; }



        public int? HouseId { get; set; }
        public HouseDTO House { get; set; }


        public int? ToiletTypeId { get; set; }
        public ToiletTypeDTO ToiletType { get; set; }


        public int? BalconyId { get; set; }
        public BalconyDTO Balcony { get; set; }


        public int? RepairTypeId { get; set; }
        public RepairTypeDTO RepairType { get; set; }


        public int? ElevatorId { get; set; }
        public ElevatorDTO Elevator { get; set; }

        public ICollection<ApartmentIncludeDTO> ApartmentIncludes { get; set; }

        public ICollection<ImagesIncludeDTO> ImagesIncludes { get; set; }
    }

    /// <summary>
    /// Фото квартиры
    /// </summary>
    public class ImagesIncludeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }


    /// <summary>
    /// Материалы стен
    /// </summary>
    public class BuildingTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Информация о доме
    /// </summary>
    public class HouseDTO
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Year { get; set; }
        public int Floors { get; set; }

        public int? BuildingTypeId { get; set; }
        public BuildingTypeDTO BuildingType { get; set; }
    }

    /// <summary>
    /// Туалет
    /// </summary>
    public class ToiletTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Балкон / лоджия
    /// </summary>
    public class BalconyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Ремонт
    /// </summary>
    public class RepairTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Лифт
    /// </summary>
    public class ElevatorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// В квартире имеется
    /// </summary>
    public class ApartmentIncludeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
