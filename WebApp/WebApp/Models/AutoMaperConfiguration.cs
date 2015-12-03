using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public static class AutoMaperConfiguration
    {
        public static void Congifure()
        {
            Mapper.CreateMap<Employee, EmployersDetailsDto>()
                .ForMember(dest => dest.EmployersDetailsDtoId, opt => opt.MapFrom(src => src.EmployeeId));
        }
    }
}