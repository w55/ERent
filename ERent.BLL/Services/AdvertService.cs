using System;
using ERent.BLL.DTO;
using ERent.DAL.Entities;
using ERent.BLL.BusinessModels;
using ERent.DAL.Interfaces;
using ERent.BLL.Infrastructure;
using ERent.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;

namespace ERent.BLL.Services
{
    /// <summary>
    /// implementation for  IAdvertService interface
    /// </summary>
    public class AdvertService : IAdvertService
    {
        IUnitOfWork Database { get; set; }

        /// <summary>
        /// нам надо использовать внедрение зависимостей для передачи конкретной реализации интерфейса IUnitOfWork в AdvertService
        /// </summary>
        /// <param name="uow"></param>
        public AdvertService(IUnitOfWork uow)
        {
            Database = uow;
        }

        /// <summary>
        /// получает объект для сохранения с уровня представления и создает по нему объект Apartment и сохраняет его в базу данных.
        /// </summary>
        /// <param name="appartmentDto"></param>
        public void MakeAdvert(ApartmentDTO appartmentDto)
        {
            Salesman salesman = Database.Salesmans.Get(appartmentDto.SalesmanId);

            // валидация
            if (salesman == null)
                throw new ValidationException("Арендодатель не найден", "");

            // смотрим состояние проплаченных сервисов арендодателя
            bool salesmanPayedState = new SalesmanState(30.0).GetSalesmanPayedState(salesman.PayedDate);

            // применяем автомаппер для проекции HouseDTO на House
            Mapper.Initialize(cfg => cfg.CreateMap<HouseDTO, House>());
            House house = Mapper.Map<HouseDTO, House>(appartmentDto.House);

            Mapper.Initialize(cfg => cfg.CreateMap<ToiletTypeDTO, ToiletType>());
            ToiletType toiletType = Mapper.Map<ToiletTypeDTO, ToiletType>(appartmentDto.ToiletType);

            Mapper.Initialize(cfg => cfg.CreateMap<BalconyDTO, Balcony>());
            Balcony balcony = Mapper.Map<BalconyDTO, Balcony>(appartmentDto.Balcony);

            Mapper.Initialize(cfg => cfg.CreateMap<RepairTypeDTO, RepairType>());
            RepairType repairType = Mapper.Map<RepairTypeDTO, RepairType>(appartmentDto.RepairType);

            Mapper.Initialize(cfg => cfg.CreateMap<ElevatorDTO, Elevator>());
            Elevator elevator = Mapper.Map<ElevatorDTO, Elevator>(appartmentDto.Elevator);

            // применяем автомаппер для проекции одной коллекции на другую
            Mapper.Initialize(cfg => cfg.CreateMap<ApartmentIncludeDTO, ApartmentInclude>());
            var includes = Mapper.Map<IEnumerable<ApartmentIncludeDTO>, List<ApartmentInclude>>(appartmentDto.ApartmentIncludes);

            Mapper.Initialize(cfg => cfg.CreateMap<ImagesIncludeDTO, ImagesInclude>());
            var images = Mapper.Map<IEnumerable<ImagesIncludeDTO>, List<ImagesInclude>>(appartmentDto.ImagesIncludes);

            Apartment apartment = new Apartment
            {
                PublishDate = DateTime.Now,
                Salesman = salesman,
                SalesmanPayedState = salesmanPayedState,
                Price = appartmentDto.Price,
                PriceInfo = appartmentDto.PriceInfo,
                Floor = appartmentDto.Floor,
                TotalArea = appartmentDto.TotalArea,
                LivingArea = appartmentDto.LivingArea,
                KitchenArea = appartmentDto.KitchenArea,
                OtherInfo = appartmentDto.OtherInfo,
                House = house,
                ToiletType = toiletType,
                Balcony = balcony,
                RepairType = repairType,
                Elevator = elevator,
                ApartmentIncludes = includes,
                ImagesIncludes = images
            };

            Database.Apartments.Create(apartment);
            Database.Save();
        }

        /// <summary>
        /// получает все квартиры и с помощью автомаппера преобразует их в ApartmentDTO и передает на уровень представления.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ApartmentDTO> GetAdverts()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Apartment, ApartmentDTO>();
                cfg.CreateMap<Salesman, SalesmanDTO>();
                cfg.CreateMap<Balcony, BalconyDTO>();
                cfg.CreateMap<ToiletType, ToiletTypeDTO>();
                cfg.CreateMap<RepairType, RepairTypeDTO>();
                cfg.CreateMap<Elevator, ElevatorDTO>();
                cfg.CreateMap<BuildingType, BuildingTypeDTO>();
                cfg.CreateMap<House, HouseDTO>();
                cfg.CreateMap<ApartmentInclude, ApartmentIncludeDTO>();
                cfg.CreateMap<ImagesInclude, ImagesIncludeDTO>();
            });

            return Mapper.Map<IEnumerable<Apartment>, List<ApartmentDTO>>(Database.Apartments.GetAll());
        }

        /// <summary>
        /// находит объект Apartment в DLL и передает объект ApartmentDTO на уровень представления.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApartmentDTO GetAdvert(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id объявления", "");

            var apartment = Database.Apartments.Get(id.Value);
            if (apartment == null)
                throw new ValidationException("Квартира не найдена", "");

            Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Apartment, ApartmentDTO>();
                    cfg.CreateMap<Salesman, SalesmanDTO>();
                    cfg.CreateMap<Balcony, BalconyDTO>();
                    cfg.CreateMap<ToiletType, ToiletTypeDTO>();
                    cfg.CreateMap<RepairType, RepairTypeDTO>();
                    cfg.CreateMap<Elevator, ElevatorDTO>();
                    cfg.CreateMap<BuildingType, BuildingTypeDTO>();
                    cfg.CreateMap<House, HouseDTO>();
                    cfg.CreateMap<ApartmentInclude, ApartmentIncludeDTO>();
                    cfg.CreateMap<ImagesInclude, ImagesIncludeDTO>();
                });

            return Mapper.Map<Apartment, ApartmentDTO>(apartment);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
