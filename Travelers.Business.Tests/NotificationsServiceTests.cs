using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Campus.Persistence;
using FluentAssertions;
using Moq;
using Travelers.Business.Travelers.Models.Notifications;
using Travelers.Business.Travelers.Models.Users;
using Travelers.Business.Travelers.Services.NotificationS;
using Travelers.Business.Travelers.Services.UserS;
using Travelers.entities;
using Travelers.persistance;
using Xunit;

namespace Travelers.Business.Tests
{
	public class NotificationsServiceTests:IDisposable
	{
		private readonly MockRepository mockNotificationRepository;
		private readonly Mock<INotificationRepository> notificationRepositoryMock;
		private readonly Mock<IMapper> mapperNotificationMock;

		private readonly NotificationService SUT;

		public NotificationsServiceTests()
		{
			mockNotificationRepository = new MockRepository(MockBehavior.Strict);
			notificationRepositoryMock = mockNotificationRepository.Create<INotificationRepository>();
			mapperNotificationMock = mockNotificationRepository.Create<IMapper>();
			SUT = new NotificationService(notificationRepositoryMock.Object, mapperNotificationMock.Object);
		}
		public void Dispose()
		{
			mockNotificationRepository.VerifyAll();
		}


		[Fact]
		public async void When_Get_IsCalled_Except_GetFromNotificationRepositoryToBeInvoked_And_MappedResponseToBeReturned()
		{
			//Arrange
			var notification = new Notification();

			var result = new NotificationModel()
			{
				Id = notification.Id,
				IdUser = notification.IdUser,
				PostId = notification.PostId,
				Content = notification.Content,
				
			};

			this.notificationRepositoryMock
				.Setup(c => c.GetNotificationById(notification.Id))
				.ReturnsAsync(notification);
			this.mapperNotificationMock
				.Setup(m => m.Map<NotificationModel>(notification))
				.Returns(result);


			//Act
			var resultFinal = await SUT.GetById(notification.Id);
			//Assert

			resultFinal.Should().BeEquivalentTo(result);
		}


		[Fact]
		public void When_GetAll_IsCalled_Expect_GetAllFromNotificationRepositoryToBeInvoked_And_MappedResponseToBeReturned()
		{
			//Arrange
			var notifications = new List<Notification>();
			notifications.Add(new Notification()
			{
				Id = Guid.NewGuid(),
				IdUser = Guid.NewGuid(),
				PostId = Guid.NewGuid(),
				Content = "Content-getAll",
			});
			notifications.Add(new Notification()
			{
				Id = Guid.NewGuid(),
				IdUser = Guid.NewGuid(),
				PostId = Guid.NewGuid(),
				Content = "Content2-getAll",
			});

			var result = notifications.Select(n => new NotificationModel()
			{
				Id = n.Id,
				IdUser = n.IdUser,
				PostId = n.PostId,
				Content = n.Content,

			});

			notificationRepositoryMock
				.Setup(c => c.GetAll())
				.Returns(notifications);

			mapperNotificationMock
				.Setup(m => m.Map<IEnumerable<NotificationModel>>(notifications))
				.Returns(result);

			//Act
			var resultFinal = SUT.GetAll();

			//Assert
			result.Should().BeEquivalentTo(resultFinal);
		}

		[Fact]

		public async void When_Create_IsCalled_Expect_CreateAndSaveChangesFromNotificationRepositoryToBeInvoked_And_MappedResponseToBeReturned()
		{
			//Arrange
			var notification = new Notification()
			{
				Id = Guid.NewGuid(),
				IdUser = Guid.NewGuid(),
				PostId = Guid.NewGuid(),
				Content = "Content-create",
			};
			var userCreated = new CreateNotificationModel()
			{
				IdUser = Guid.NewGuid(),
				PostId = Guid.NewGuid(),
				Content = "Content2-create",
			};
			var result = new NotificationModel()
			{
				Id = notification.Id,
				IdUser = notification.IdUser,
				PostId = notification.PostId,
				Content = notification.Content,
				
			};

			mapperNotificationMock
				.Setup(c => c.Map<Notification>(userCreated))
				.Returns(notification);
			notificationRepositoryMock
				.Setup(c => c.Create(notification))
				.Returns(Task.CompletedTask);
			notificationRepositoryMock
				.Setup(c => c.SaveChanges())
				.Returns(Task.CompletedTask);
			mapperNotificationMock
				.Setup(m => m.Map<NotificationModel>(notification))
				.Returns(result);

			//Act
			var resultFinal = await SUT.Create(userCreated);

			//Assert
			resultFinal.Should().BeEquivalentTo(resultFinal);
		}

		[Fact]
		public async void When_Delete_IsCalled_Expect_GetByIdAndDeleteAndSaveChangesFromNotificationRepositoryToBeInvoked()
		{
			//Arrange
			var notification = new Notification()
			{
				Id = Guid.NewGuid(),
				IdUser = Guid.NewGuid(),
				PostId = Guid.NewGuid(),
				Content = "Content-delete",
			};

			notificationRepositoryMock
				.Setup(c => c.GetNotificationById(notification.Id))
				.ReturnsAsync(notification);

			notificationRepositoryMock
				.Setup(d => d.Delete(notification));

			notificationRepositoryMock
				.Setup(s => s.SaveChanges())
				.Returns(Task.CompletedTask);

			//Act
			await SUT.Delete(notification.Id);

		}

		[Fact]
		public async void When_Update_IsCalled_Expect_GetByIdAndUpdateAndSaveChangesFromNotificationRepositoryToBeInvoked()
		{
			//Arrange
			var notification = new Notification()
			{
				Id = Guid.NewGuid(),
				IdUser = Guid.NewGuid(),
				PostId = Guid.NewGuid(),
				Content = "Content-update",
			};

			var notificationCreated = new CreateNotificationModel()
			{
				IdUser = notification.IdUser,
				PostId = notification.PostId,
				Content = notification.Content,
			};

			notificationRepositoryMock
				.Setup(c => c.GetNotificationById(notification.Id))
				.ReturnsAsync(notification);

			mapperNotificationMock
				.Setup(m => m.Map(notificationCreated, notification))
				.Returns(notification);

			notificationRepositoryMock
				.Setup(u => u.Update(notification));

			notificationRepositoryMock
				.Setup(s => s.SaveChanges())
				.Returns(Task.CompletedTask);

			//Act

			await SUT.Update(notification.Id, notificationCreated);

		}


	}
}
