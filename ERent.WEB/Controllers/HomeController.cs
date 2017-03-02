using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERent.BLL.Interfaces;
using ERent.BLL.DTO;
using ERent.WEB.Models;
using AutoMapper;
using ERent.BLL.Infrastructure;

namespace ERent.WEB.Controllers
{
    public class HomeController : Controller
    {
        IAdvertService advertService;
        public HomeController(IAdvertService serv)
        {
            advertService = serv;
        }

		/*
		...  other controller code here ...
		*/
		
        //------------------------  DEBUG only --------------------------->>>

        // AdvertsList
        public ActionResult AdvertsList()
        {
            IEnumerable<ApartmentDTO> apartmentDtos = advertService.GetAdverts();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ApartmentDTO, ApartmentViewModel>();
                cfg.CreateMap<SalesmanDTO, SalesmanViewModel>();
                cfg.CreateMap<BalconyDTO, BalconyViewModel>();
                cfg.CreateMap<ToiletTypeDTO, ToiletTypeViewModel>();
                cfg.CreateMap<RepairTypeDTO, RepairTypeViewModel>();
                cfg.CreateMap<ElevatorDTO, ElevatorViewModel>();
                cfg.CreateMap<BuildingTypeDTO, BuildingTypeViewModel>();
                cfg.CreateMap<HouseDTO, HouseViewModel>();
                cfg.CreateMap<ApartmentIncludeDTO, ApartmentIncludeViewModel>();
                cfg.CreateMap<ImagesIncludeDTO, ImagesIncludeViewModel>();
            });

            var apartments = Mapper.Map<IEnumerable<ApartmentDTO>, List<ApartmentViewModel>>(apartmentDtos);

            return View(apartments);
        }

        // get: MakeAdvert
        public ActionResult MakeAdvert(int? id)
        {
            try
            {
                ApartmentDTO apartment = advertService.GetAdvert(id);

                Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<ApartmentDTO, ApartmentViewModel>().ForMember("SalesmanId", opt => opt.MapFrom(src => src.Id));
                        cfg.CreateMap<SalesmanDTO, SalesmanViewModel>();
                        cfg.CreateMap<BalconyDTO, BalconyViewModel>();
                        cfg.CreateMap<ToiletTypeDTO, ToiletTypeViewModel>();
                        cfg.CreateMap<RepairTypeDTO, RepairTypeViewModel>();
                        cfg.CreateMap<ElevatorDTO, ElevatorViewModel>();
                        cfg.CreateMap<BuildingTypeDTO, BuildingTypeViewModel>();
                        cfg.CreateMap<HouseDTO, HouseViewModel>();
                        cfg.CreateMap<ApartmentIncludeDTO, ApartmentIncludeViewModel>();
                        cfg.CreateMap<ImagesIncludeDTO, ImagesIncludeViewModel>();
                    });

                var advert = Mapper.Map<ApartmentDTO, ApartmentViewModel>(apartment);

                return View(advert);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // post: MakeAdvert
        [HttpPost]
        public ActionResult MakeAdvert(ApartmentViewModel apartment)
        {
            // Чтобы перехватить ошибки валидации, которые возникают на уровне BLL, здесь используется конструкция try..catch, 
            // в которой перехватываются исключения ValidationException, 
            // а соответствующие сообщения об ошибках передаются в представление.
            try
            {
                Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<ApartmentViewModel, ApartmentDTO>();
                        cfg.CreateMap<SalesmanViewModel, SalesmanDTO>();
                        cfg.CreateMap<BalconyViewModel, BalconyDTO>();
                        cfg.CreateMap<ToiletTypeViewModel, ToiletTypeDTO>();
                        cfg.CreateMap<RepairTypeViewModel, RepairTypeDTO>();
                        cfg.CreateMap<ElevatorViewModel, ElevatorDTO>();
                        cfg.CreateMap<BuildingTypeViewModel, BuildingTypeDTO>();
                        cfg.CreateMap<HouseViewModel, HouseDTO>();
                        cfg.CreateMap<ApartmentIncludeViewModel, ApartmentIncludeDTO>();
                        cfg.CreateMap<ImagesIncludeViewModel, ImagesIncludeDTO>();
                    });


                var orderDto = Mapper.Map<ApartmentViewModel, ApartmentDTO>(apartment);
                advertService.MakeAdvert(orderDto);

                return Content("<h2>Ваше объявление успешно оформлено</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(apartment);
        }

		/*
		...  other controller code here ...
		*/

        protected override void Dispose(bool disposing)
        {
            advertService.Dispose();
            base.Dispose(disposing);
        }
    }
}