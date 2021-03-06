namespace FeriaVirtual.API.Helpers
{
    using AutoMapper;
    using FeriaVirtual.Database.Entities;
    using FeriaVirtual.API.Models.Users;
    using FeriaVirtual.APIModels.Product;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User -> AuthenticateResponse
            CreateMap<User, AuthenticateResponse>();

            // RegisterRequest -> User
            CreateMap<RegisterRequest, User>();

            //UpdateRequest -> User
            CreateMap<UpdateRequest, User>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));


            // Product -> ProductResponse
            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name));

        }
    }
}
