using AutoMapper;
using ClassLibraryAirline.Model;

namespace MVC_Airline.Models
{
    public class MVCmapper:Profile
    {
        public MVCmapper()
        {
            CreateMap<AirlineModel, MvcModelAirline>().ReverseMap();
        }
    }
}
