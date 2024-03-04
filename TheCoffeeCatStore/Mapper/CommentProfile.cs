
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
                dest => dest.CustomerID,
                opt => opt.MapFrom(src => src.CustomerID)
                );


            CreateMap<Comment, CommentCreateDTO> ()
               .ForMember(
               dest => dest.CommentText,
               opt => opt.MapFrom(src => src.CommentText)
               )
               .ForMember(
               dest => dest.CreateTime,
               opt => opt.MapFrom(src => src.CreateTime)
               )
               .ForMember(
               dest => dest.CoffeeID,
               opt => opt.MapFrom(src => src.CoffeeID)
               )
               .ForMember(
               dest => dest.CustomerID,
               opt => opt.MapFrom(src => src.CustomerID)
               );

            CreateMap<Comment,CommentUpdateDTO> ()

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
