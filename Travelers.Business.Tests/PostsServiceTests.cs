using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using Travelers.Business.Travelers.Models.Posts;
using Travelers.Business.Travelers.Models.Users;
using Travelers.Business.Travelers.Services.PostS;
using Travelers.Business.Travelers.Services.UserS;
using Travelers.entities;
using Travelers.persistance;
using Xunit;

namespace Travelers.Business.Tests
{
	public class PostsServiceTests:IDisposable
	{
		private readonly MockRepository mockPostRepository;
		private readonly Mock<IPostRepository> postRepositoryMock;
		private readonly Mock<IMapper> mapperPostMock;

		private readonly PostsService SUT;

		public PostsServiceTests()
		{
			mockPostRepository = new MockRepository(MockBehavior.Strict);
			postRepositoryMock = mockPostRepository.Create<IPostRepository>();
			mapperPostMock = mockPostRepository.Create<IMapper>();
			SUT = new PostsService(postRepositoryMock.Object, mapperPostMock.Object);
		}
		public void Dispose()
		{
			mockPostRepository.VerifyAll();
		}


		[Fact]
		public async void When_Get_IsCalled_Except_GetFromPostRepositoryToBeInvoked_And_MappedResponseToBeReturned()
		{
			//Arrange
			var post = new Post();

			var result = new PostModel()
			{
				Id = post.Id,
				IdUser = post.IdUser,
				Content = post.Content,
				NumberOfLikes = post.NumberOfLikes,
				Type = post.Type,
			};

			this.postRepositoryMock
				.Setup(c => c.GetPostById(post.Id))
				.ReturnsAsync(post);
			this.mapperPostMock
				.Setup(m => m.Map<PostModel>(post))
				.Returns(result);


			//Act
			var resultFinal = await SUT.GetPostById(post.Id);
			//Assert

			resultFinal.Should().BeEquivalentTo(result);
		}


		[Fact]
		public void When_GetAll_IsCalled_Expect_GetAllFromPostRepositoryToBeInvoked_And_MappedResponseToBeReturned()
		{
			//Arrange
			var posts = new List<Post>();
			posts.Add(new Post()
			{
				Id = Guid.NewGuid(),
				IdUser = Guid.NewGuid(),
				Content = "Content-post",
				NumberOfLikes = 10,
				Type = "type-post",
			});
			posts.Add(new Post()
			{
				Id = Guid.NewGuid(),
				IdUser = Guid.NewGuid(),
				Content = "Content2-post",
				NumberOfLikes = 20,
				Type = "type2-post",
			});

			var result = posts.Select(p => new PostModel()
			{
				Id = p.Id,
				IdUser = p.IdUser,
				Content = p.Content,
				NumberOfLikes = p.NumberOfLikes,
				Type = p.Type,

			});

			postRepositoryMock
				.Setup(c => c.GetAll())
				.Returns(posts);

			mapperPostMock
				.Setup(m => m.Map<IEnumerable<PostModel>>(posts))
				.Returns(result);

			//Act
			var resultFinal = SUT.GetAll();

			//Assert
			result.Should().BeEquivalentTo(resultFinal);
		}

		[Fact]

		public async void When_Create_IsCalled_Expect_CreateAndSaveChangesFromPostRepositoryToBeInvoked_And_MappedResponseToBeReturned()
		{
			//Arrange
			var post = new Post()
			{
				Id = Guid.NewGuid(),
				IdUser = Guid.NewGuid(),
				Content = "Content-post-create",
				NumberOfLikes = 30,
				Type = "type-post-create",
			};
			var postCreated = new CreatePostModel()
			{
				IdUser = Guid.NewGuid(),
				Content = "Content2-post-create",
				NumberOfLikes = 40,
				Type = "type2-post-create",
			};
			var result = new PostModel()
			{
				Id = post.Id,
				IdUser = post.IdUser,
				Content = post.Content,
				NumberOfLikes = post.NumberOfLikes,
				Type = post.Type,
			};

			mapperPostMock
				.Setup(c => c.Map<Post>(postCreated))
				.Returns(post);
			postRepositoryMock
				.Setup(c => c.Create(post))
				.Returns(Task.CompletedTask);
			postRepositoryMock
				.Setup(c => c.SaveChanges())
				.Returns(Task.CompletedTask);
			mapperPostMock
				.Setup(m => m.Map<PostModel>(post))
				.Returns(result);

			//Act
			var resultFinal = await SUT.Create(postCreated);

			//Assert
			resultFinal.Should().BeEquivalentTo(resultFinal);
		}

		[Fact]
		public async void When_Delete_IsCalled_Expect_GetByIdAndDeleteAndSaveChangesFromPostRepositoryToBeInvoked()
		{
			//Arrange
			var post = new Post()
			{
				Id = Guid.NewGuid(),
				IdUser = Guid.NewGuid(),
				Content = "Content-post-delete",
				NumberOfLikes = 30,
				Type = "type-post-delete",
			};

			postRepositoryMock
				.Setup(c => c.GetPostById(post.Id))
				.ReturnsAsync(post);

			postRepositoryMock
				.Setup(d => d.Delete(post));

			postRepositoryMock
				.Setup(s => s.SaveChanges())
				.Returns(Task.CompletedTask);

			//Act
			await SUT.Delete(post.Id);

		}

		[Fact]
		public async void When_Update_IsCalled_Expect_GetByIdAndUpdateAndSaveChangesFromPostRepositoryToBeInvoked()
		{
			//Arrange
			var post = new Post()
			{
				Id = Guid.NewGuid(),
				IdUser = Guid.NewGuid(),
				Content = "Content-post-update",
				NumberOfLikes = 90,
				Type = "type-post-update",
			};

			var postCreated = new CreatePostModel()
			{
				IdUser = post.IdUser,
				Content = post.Content,
				NumberOfLikes = post.NumberOfLikes,
				Type = post.Type,
			};

			postRepositoryMock
				.Setup(c => c.GetPostById(post.Id))
				.ReturnsAsync(post);

			mapperPostMock
				.Setup(m => m.Map(postCreated, post))
				.Returns(post);

			postRepositoryMock
				.Setup(u => u.Update(post));

			postRepositoryMock
				.Setup(s => s.SaveChanges())
				.Returns(Task.CompletedTask);

			//Act

			await SUT.Update(post.Id, postCreated);

		}


	}
}
