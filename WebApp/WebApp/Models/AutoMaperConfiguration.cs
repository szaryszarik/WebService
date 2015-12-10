using AutoMapper;

namespace WebApp.Models
{
    public static class AutoMaperConfiguration
    {
        public static void Congifure()
        {
            Mapper.CreateMap<Employee, EmployersDetailsDto>()
                .ForMember(dest => dest.EmployersDetailsDtoId, opt => opt.MapFrom(src => src.EmployeeId));
            Mapper.CreateMap<EmployersDetailsDto, Employee>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(sc => sc.EmployersDetailsDtoId));
            Mapper.CreateMap<WorkNote, WorkNotesDto>()
                .ForMember(d => d.WorkNoteId, o => o.MapFrom(s => s.WorkNoteId));
            Mapper.CreateMap<WorkNotesDto, WorkNote>();
        }
    }
}