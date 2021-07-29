using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using Travelers.Business.Travelers.Models.Comments;
using Travelers.Business.Travelers.Services.CommentS;
using Travelers.entities;
using Travelers.Persistence;
using Xunit;

namespace Travelers.Business.Tests
{
	public class CommentsServiceTests:IDisposable
	{
		private readonly MockRepository mockRepository;
		private readonly Mock<ICommentRepository> commentRepositoryMock;
		private readonly Mock<IMapper> mapperMock;

		private readonly CommentService SUT;
		
		public CommentsServiceTests()
		{
			mockRepository = new MockRepository(MockBehavior.Strict);
			commentRepositoryMock = mockRepository.Create<ICommentRepository>();
			mapperMock = mockRepository.Create<IMapper>();
			SUT = new CommentService(commentRepositoryMock.Object, mapperMock.Object);
		}
		public void Dispose()
		{
			mockRepository.VerifyAll();
		}


		[Fact]
		public async void When_Get_IsCalled_Except_GetFromCommentRepositoryToBeInvoked_And_MappedResponseToBeReturned()
		{
			//Arrange
			var comment = new Comment();

			 var result =new CommentModel()
			{
				Id=comment.Id,
				IdUser = Guid.NewGuid(),
				PostId = Guid.NewGuid(),
				 Content = comment.Content,
				NumberOfLikes = comment.NumberOfLikes,
			};

			 this.commentRepositoryMock
				 .Setup(c => c.GetCommentById(comment.Id))
				 .ReturnsAsync(comment);
			 this.mapperMock
				 .Setup(m => m.Map<CommentModel>(comment))
				 .Returns(result);


			//Act
			var resultFinal = await SUT.GetById(comment.Id);
			//Assert

			resultFinal.Should().BeEquivalentTo(result);
		}


		[Fact]
		public void When_GetAll_IsCalled_Expect_GetAllFromCommentRepositoryToBeInvoked_And_MappedResponseToBeReturned()
		{
			//Arrange
			var comments = new List<Comment>();
			comments.Add(new Comment()
			{
				IdUser = Guid.NewGuid(),
				PostId = Guid.NewGuid(),
				Content ="Comment1",
				NumberOfLikes =10,
			});
			comments.Add(new Comment()
			{
				IdUser = Guid.NewGuid(),
				PostId = Guid.NewGuid(),
				Content = "Comment2",
				NumberOfLikes = 20,
			});

			var result = comments.Select(c => new CommentModel()
			{
				Id = c.Id,
				IdUser = c.IdUser,
				PostId = c.PostId,
				Content = c.Content

			});

			commentRepositoryMock
				.Setup(c => c.GetAll())
				.Returns(comments);

			mapperMock
				.Setup(m => m.Map<IEnumerable<CommentModel>>(comments))
				.Returns(result);

			//Act
			var resultFinal = SUT.GetAll();

			//Assert
			result.Should().BeEquivalentTo(resultFinal);
		}

		[Fact]

		public async void When_Create_IsCalled_Expect_CreateAndSaveChangesFromCommentRepositoryToBeInvoked_And_MappedResponseToBeReturned()
		{
			//Arrange
			var comment = new Comment()
			{
				IdUser = Guid.NewGuid(),
				PostId = Guid.NewGuid(),
			};
			var commentCreated = new CreateCommentModel()
			{
				IdUser=comment.IdUser,
				PostId = comment.PostId,
				Content = "CreateComment",
				NumberOfLikes = 30,
			};
			var result = new CommentModel()
			{
				IdUser = comment.IdUser,
				PostId = comment.PostId,
				Content = comment.Content,
				NumberOfLikes = comment.NumberOfLikes,
			};

			mapperMock
				.Setup(c => c.Map<Comment>(commentCreated))
				.Returns(comment);
			commentRepositoryMock
				.Setup(c => c.Create(comment))
				.Returns(Task.CompletedTask);
			commentRepositoryMock
				.Setup(c => c.SaveChanges())
				.Returns(Task.CompletedTask);
			mapperMock
				.Setup(m => m.Map<CommentModel>(comment))
				.Returns(result);

			//Act
			var resultFinal = await SUT.Create(commentCreated);

			//Assert
			resultFinal.Should().BeEquivalentTo(resultFinal);
		}

		[Fact]
		public async void When_Delete_IsCalled_Expect_GetByIdAndDeleteAndSaveChangesFromCommentRepositoryToBeInvoked()
		{
			//Arrange
			var comment = new Comment()
			{
				IdUser = Guid.NewGuid(),
				PostId = Guid.NewGuid(),
				Content = "DeleteComment",
				NumberOfLikes = 40,
			};

			commentRepositoryMock
				.Setup(c => c.GetCommentById(comment.Id))
				.ReturnsAsync(comment);

			commentRepositoryMock
				.Setup(d => d.Delete(comment));

			commentRepositoryMock
				.Setup(s => s.SaveChanges())
				.Returns(Task.CompletedTask);
			
			//Act
			await SUT.Delete(comment.Id);
			
		}

		[Fact]
		public async void When_Update_IsCalled_Expect_GetByIdAndUpdateAndSaveChangesFromCommentRepositoryToBeInvoked()
		{
			//Arrange
			var comment = new Comment()
			{
				IdUser = Guid.NewGuid(),
				PostId = Guid.NewGuid(),
				Content = "UpdateComment",
				NumberOfLikes = 50,
			};

			var commentCreated = new CreateCommentModel()
			{
				IdUser = comment.IdUser,
				PostId = comment.PostId,
				Content = comment.Content,
				NumberOfLikes = comment.NumberOfLikes,
			};

			commentRepositoryMock
				.Setup(c => c.GetCommentById(comment.Id))
				.ReturnsAsync(comment);

			mapperMock
				.Setup(m => m.Map(commentCreated, comment))
				.Returns(comment);

			commentRepositoryMock
				.Setup(u => u.Update(comment));

			commentRepositoryMock
				.Setup(s => s.SaveChanges())
				.Returns(Task.CompletedTask);

			//Act

			await SUT.Update(comment.Id, commentCreated);

		}


	}
}
