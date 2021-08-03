using AutoMapper;
using Travelers.Business.Travelers.Models.Comments;
using Travelers.Business.Travelers.Models.Notifications;
using Travelers.Business.Travelers.Models.Posts;
using Travelers.Business.Travelers.Models.Reviews;
using Travelers.Business.Travelers.Models.Users;
using Travelers.Entities;

namespace Travelers.Business.Mappings
{
	public class TravelersMappingsProfile: Profile
	{

		public TravelersMappingsProfile()
		{
			CreateMap<User, UsersModel>().ReverseMap();
			CreateMap<User, CreateUsersModel>().ReverseMap();
			CreateMap<Post, PostModel>().ReverseMap();
			CreateMap<Post, CreatePostModel>().ReverseMap();
			CreateMap<Comment, CommentModel>().ReverseMap();
			CreateMap<Comment, CreateCommentModel>().ReverseMap();
			CreateMap<Review, ReviewModel>().ReverseMap();
			CreateMap<Review, CreateReviewModel>().ReverseMap();
			CreateMap<Notification, NotificationModel>().ReverseMap();
			CreateMap<Notification, CreateNotificationModel>().ReverseMap();

			
		}
	}
}
