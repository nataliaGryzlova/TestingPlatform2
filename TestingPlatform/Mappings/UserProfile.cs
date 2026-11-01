using AutoMapper;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Requests.User;
using TestingPlatform.Responses.User;

namespace TestingPlatform.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, UserResponse>();
        CreateMap<CreateUserRequest, UserDto>();
        CreateMap<UpdateUserRequest, UserDto>();
    }
}