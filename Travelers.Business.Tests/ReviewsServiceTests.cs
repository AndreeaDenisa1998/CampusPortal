using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Campus.Persistence;
using FluentAssertions;
using Moq;
using Travelers.Business.Travelers.Models.Reviews;
using Travelers.Business.Travelers.Models.Users;
using Travelers.Business.Travelers.Services.ReviewS;
using Travelers.Business.Travelers.Services.UserS;
using Travelers.entities;
using Travelers.persistance;
using Xunit;

namespace Travelers.Business.Tests
{
	public class ReviewsServiceTests:IDisposable
	{
		private readonly MockRepository mockReviewRepository;
		private readonly Mock<IReviewRepository> reviewRepositoryMock;
		private readonly Mock<IMapper> mapperReviewMock;

		private readonly ReviewService SUT;

		public ReviewsServiceTests()
		{
			mockReviewRepository = new MockRepository(MockBehavior.Strict);
			reviewRepositoryMock = mockReviewRepository.Create<IReviewRepository>();
			mapperReviewMock = mockReviewRepository.Create<IMapper>();
			SUT = new ReviewService(reviewRepositoryMock.Object, mapperReviewMock.Object);
		}
		public void Dispose()
		{
			mockReviewRepository.VerifyAll();
		}


		[Fact]
		public async void When_Get_IsCalled_Except_GetFromReviewRepositoryToBeInvoked_And_MappedResponseToBeReturned()
		{
			//Arrange
			var review = new Review();

			var result = new ReviewModel()
			{
				Id = review.Id,
				IdUser = review.IdUser,
				PostId = review.PostId,
				NumberOfLikes = review.NumberOfLikes,
				NumberOfStars = review.NumberOfStars,
				Content = review.Content,
			};

			this.reviewRepositoryMock
				.Setup(c => c.GetReviewById(review.Id))
				.ReturnsAsync(review);
			this.mapperReviewMock
				.Setup(m => m.Map<ReviewModel>(review))
				.Returns(result);


			//Act
			var resultFinal = await SUT.GetById(review.Id);
			//Assert

			resultFinal.Should().BeEquivalentTo(result);
		}


		[Fact]
		public void When_GetAll_IsCalled_Expect_GetAllFromReviewRepositoryToBeInvoked_And_MappedResponseToBeReturned()
		{
			//Arrange
			var reviews = new List<Review>();
			reviews.Add(new Review()
			{
				Id = Guid.NewGuid(),
				IdUser = Guid.NewGuid(),
				PostId = Guid.NewGuid(),
				NumberOfLikes = 10,
				NumberOfStars = 11,
				Content = "Content-GetAll",
			});
			reviews.Add(new Review()
			{
				Id = Guid.NewGuid(),
				IdUser = Guid.NewGuid(),
				PostId = Guid.NewGuid(),
				NumberOfLikes = 20,
				NumberOfStars = 21,
				Content = "Content2-GetAll",
			});

			var result = reviews.Select(r => new ReviewModel()
			{
				Id = r.Id,
				IdUser = r.IdUser,
				PostId = r.PostId,
				NumberOfLikes = r.NumberOfLikes,
				NumberOfStars = r.NumberOfStars,
				Content = r.Content,

			});

			reviewRepositoryMock
				.Setup(c => c.GetAll())
				.Returns(reviews);

			mapperReviewMock
				.Setup(m => m.Map<IEnumerable<ReviewModel>>(reviews))
				.Returns(result);

			//Act
			var resultFinal = SUT.GetAll();

			//Assert
			result.Should().BeEquivalentTo(resultFinal);
		}

		[Fact]

		public async void When_Create_IsCalled_Expect_CreateAndSaveChangesFromReviewRepositoryToBeInvoked_And_MappedResponseToBeReturned()
		{
			//Arrange
			var review = new Review()
			{
				Id = Guid.NewGuid(),
				IdUser = Guid.NewGuid(),
				PostId = Guid.NewGuid(),
				NumberOfLikes = 2110,
				NumberOfStars = 2133,
				Content = "Content-Create",
			};
			var reviewCreated = new CreateReviewModel()
			{
				IdUser = Guid.NewGuid(),
				PostId = Guid.NewGuid(),
				NumberOfLikes = 2440,
				NumberOfStars = 2331,
				Content = "Content2-create",
			};
			var result = new ReviewModel()
			{
				Id = review.Id,
				IdUser = review.IdUser,
				PostId = review.PostId,
				NumberOfLikes = review.NumberOfLikes,
				NumberOfStars = review.NumberOfStars,
				Content = review.Content,
			};

			mapperReviewMock
				.Setup(c => c.Map<Review>(reviewCreated))
				.Returns(review);
			reviewRepositoryMock
				.Setup(c => c.Create(review))
				.Returns(Task.CompletedTask);
			reviewRepositoryMock
				.Setup(c => c.SaveChanges())
				.Returns(Task.CompletedTask);
			mapperReviewMock
				.Setup(m => m.Map<ReviewModel>(review))
				.Returns(result);

			//Act
			var resultFinal = await SUT.Create(reviewCreated);

			//Assert
			resultFinal.Should().BeEquivalentTo(resultFinal);
		}

		[Fact]
		public async void When_Delete_IsCalled_Expect_GetByIdAndDeleteAndSaveChangesFromReviewRepositoryToBeInvoked()
		{
			//Arrange
			var review = new Review()
			{
				IdUser = Guid.NewGuid(),
				PostId = Guid.NewGuid(),
				NumberOfLikes = 2440,
				NumberOfStars = 2331,
				Content = "Content-delete",
			};

			reviewRepositoryMock
				.Setup(c => c.GetReviewById(review.Id))
				.ReturnsAsync(review);

			reviewRepositoryMock
				.Setup(d => d.Delete(review));

			reviewRepositoryMock
				.Setup(s => s.SaveChanges())
				.Returns(Task.CompletedTask);

			//Act
			await SUT.Delete(review.Id);

		}

		[Fact]
		public async void When_Update_IsCalled_Expect_GetByIdAndUpdateAndSaveChangesFromReviewRepositoryToBeInvoked()
		{
			//Arrange
			var review = new Review()
			{

				IdUser = Guid.NewGuid(),
				PostId = Guid.NewGuid(),
				NumberOfLikes = 24940,
				NumberOfStars = 233441,
				Content = "Content-update",
			};

			var reviewCreated = new CreateReviewModel()
			{
				IdUser = review.IdUser,
				PostId = review.PostId,
				NumberOfLikes = review.NumberOfLikes,
				NumberOfStars = review.NumberOfStars,
				Content = review.Content,
			};

			reviewRepositoryMock
				.Setup(c => c.GetReviewById(review.Id))
				.ReturnsAsync(review);

			mapperReviewMock
				.Setup(m => m.Map(reviewCreated, review))
				.Returns(review);

			reviewRepositoryMock
				.Setup(u => u.Update(review));

			reviewRepositoryMock
				.Setup(s => s.SaveChanges())
				.Returns(Task.CompletedTask);

			//Act

			await SUT.Update(review.Id, reviewCreated);

		}


	}
}
