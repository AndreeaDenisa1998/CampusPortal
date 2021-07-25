﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Travelers.Business.Travelers.Models.Comments;
using Travelers.Business.Travelers.Models.Notifications;
using Travelers.Business.Travelers.Models.Posts;
using Travelers.Business.Travelers.Models.Reviews;
using Travelers.Business.Travelers.Models.Users;
using Travelers.entities;

namespace Travelers.Business.Mappings
{
	public class TravelersMappingsProfile: Profile
	{

		public TravelersMappingsProfile()
		{
			CreateMap<User, UsersModel>().ReverseMap();
			CreateMap<User, CreateUsersModel>().ReverseMap();
			CreateMap<Post, PostModel>().ReverseMap();
			CreateMap<Comment, CommentModel>().ReverseMap();
			CreateMap<Review, ReviewModel>().ReverseMap();
			CreateMap<Notification, NotificationModel>().ReverseMap();
		}


	}
}