using Api.Core.DTOs;
using Api.Core.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Album, AlbumGetModel>().ReverseMap();
            CreateMap<Images, ImageGetModel>().ReverseMap();
            CreateMap<Images, ImageDTO>().ReverseMap();
            CreateMap<Album, AlbumDTO>().ReverseMap();
            CreateMap<AlbumFile, AlbumFileDTO>().ReverseMap();
            CreateMap<Log, ILogDTO>().ReverseMap();

            CreateMap<UserPostModel, User>().ReverseMap();
            CreateMap<ImagePostModel, Images>().ReverseMap();
            CreateMap<AlbumPostModel, Album>().ReverseMap();
            CreateMap<AlbumFilePostModel, AlbumFile>().ReverseMap();
            CreateMap<LogPostModel, Log>().ReverseMap();
        }

    }
}
