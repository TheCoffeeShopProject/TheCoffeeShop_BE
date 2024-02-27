
using AutoMapper;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO.Request;
using TheCoffeeCatBusinessObject.DTO.Response;

namespace TheCoffeeCatStore.Mapper
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentResponseDTO>()
                .ForMember(
                dest => dest.CommentText,
                opt => opt.MapFrom(src => src.CommentText)
                )
                .ForMember(
                dest => dest.CreateTime,
                opt => opt.MapFrom(src => src.CreateTime)
                )
                .ForMember(
                dest => dest.UpdateTime,
                opt => opt.MapFrom(src => src.UpdateTime)
                )
                .ForMember(
                dest => dest.Customer,
                opt => opt.MapFrom(src => src.Customer)
                );


            CreateMap<CommentCreateDTO, Comment>()
               .ForMember(
               dest => dest.CommentText,
               opt => opt.MapFrom(src => src.CommentText)
               )
               .ForMember(
               dest => dest.CreateTime,
               opt => opt.MapFrom(src => src.CreateTime)
               )
               .ForMember(
               dest => dest.CoffeeShop,
               opt => opt.MapFrom(src => src.CoffeeShop)
               )
               .ForMember(
               dest => dest.Customer,
               opt => opt.MapFrom(src => src.Customer)
               );

            CreateMap<CommentUpdateDTO, Comment>()

            .ForMember(
            dest => dest.CommentText,
            opt => opt.MapFrom(src => src.CommentText)
            )

            .ForMember(
            dest => dest.UpdateTime,
            opt => opt.MapFrom(src => src.UpdateTime)
            );




        }
    }
}
