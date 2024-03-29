﻿using AutoMapper;
using WebDiary.BLL.Models;
using WebDiary.Models;

namespace WebDiary.Services
{
    public class EventViewModelMappingProfile : Profile
    {
        public EventViewModelMappingProfile() 
        {
            CreateMap<UserViewModel, UserDTO>();
            CreateMap<UserDTO, UserViewModel>();

            CreateMap<EditUserViewModel, UserDTO>();
            CreateMap<UserDTO, EditUserViewModel>();

            CreateMap<GroupViewModel, GroupDTO>();
            CreateMap<GroupDTO, GroupViewModel>();

            CreateMap<EventViewModel, EventDTO>();
            CreateMap<EventDTO, EventViewModel>()
                .ForMember(d => d.DonedByEmail, o => o.MapFrom(s => s.DonedBy.Email));

            CreateMap<CommentViewModel, CommentDTO>();
            CreateMap<CommentDTO, CommentViewModel>()
                .ForMember(d => d.Email, o => o.MapFrom(s => s.User.Email))
                .ForMember(d => d.ParentCommentEmail, o => o.MapFrom(s => s.ParentComment.User.Email));

            CreateMap<FriendsViewModel, FriendsDTO>();
            CreateMap<FriendsDTO, FriendsViewModel>()
                .ForMember(d => d.FriendUserName, o => o.MapFrom(s => s.Friend.UserName));
        }
    }
}