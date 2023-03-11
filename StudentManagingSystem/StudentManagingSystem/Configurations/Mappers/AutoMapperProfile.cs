using AutoMapper;
using StudentManagingSystem.Model;
using StudentManagingSystem.ViewModel;

namespace StudentManagingSystem.Configurations.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, Student>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<Student, StudentAddRequest>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<Department, Department>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<Department, DepartmentViewModel>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<User, UserViewModel>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<ClassRoom, ClassRoom>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<ClassRoom, ClassRoomViewModel>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<ClassRoom, ClassRoomAddRequest>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            
        }
    }
}
