using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using Travelers.Business.Travelers.Models.Comments;
using Travelers.Business.Travelers.Models.Users;
using Travelers.Business.Travelers.Services.CommentS;
using Travelers.Business.Travelers.Services.UserS;
using Travelers.entities;
using Travelers.persistance;
using Travelers.Persistence;
using Xunit;

namespace Travelers.Business.Tests
{
	public class UsersServiceTests:IDisposable
	{
		private readonly MockRepository mockUserRepository;
		private readonly Mock<IUsersRepository> userRepositoryMock;
		private readonly Mock<IMapper> mapperUserMock;

		private readonly UsersService SUT;

		public UsersServiceTests()
		{
			mockUserRepository = new MockRepository(MockBehavior.Strict);
			userRepositoryMock = mockUserRepository.Create<IUsersRepository>();
			mapperUserMock = mockUserRepository.Create<IMapper>();
			SUT = new UsersService(userRepositoryMock.Object, mapperUserMock.Object);
		}
		public void Dispose()
		{
			mockUserRepository.VerifyAll();
		}


		[Fact]
		public async void When_Get_IsCalled_Except_GetFromUserRepositoryToBeInvoked_And_MappedResponseToBeReturned()
		{
			//Arrange
			var user = new User();

			var result = new UsersModel()
			{
				Id = user.Id,
				Username = user.Username,
				Type = user.Type,
				Email = user.Email,
				PasswordHash=user.PasswordHash,
			};

			this.userRepositoryMock
				.Setup(c => c.GetUserById(user.Id))
				.ReturnsAsync(user);
			this.mapperUserMock
				.Setup(m => m.Map<UsersModel>(user))
				.Returns(result);


			//Act
			var resultFinal = await SUT.GetUserById(user.Id);
			//Assert

			resultFinal.Should().BeEquivalentTo(result);
		}


		[Fact]
		public void When_GetAll_IsCalled_Expect_GetAllFromUserRepositoryToBeInvoked_And_MappedResponseToBeReturned()
		{
			//Arrange
			var users = new List<User>();
			users.Add(new User()
			{
				Id = Guid.NewGuid(),
				Username = "Username-GetAll",
				Type = "Type-GetAll",
				Email = "Email-GetAll",
				PasswordHash = "Password-GetAll",
			});
			users.Add(new User()
			{
				Id = Guid.NewGuid(),
				Username = "Username2-GetAll",
				Type = "Type2-GetAll",
				Email = "Email2-GetAll",
				PasswordHash = "Password2-GetAll",
			});

			var result = users.Select(u => new UsersModel()
			{
				Id = u.Id,
				Username = u.Username,
				Type = u.Type,
				Email = u.Email,
				PasswordHash = u.PasswordHash,

			});

			userRepositoryMock
				.Setup(c => c.GetAll())
				.Returns(users);

			mapperUserMock
				.Setup(m => m.Map<IEnumerable<UsersModel>>(users))
				.Returns(result);

			//Act
			var resultFinal = SUT.GetAll();

			//Assert
			result.Should().BeEquivalentTo(resultFinal);
		}

		[Fact]

		public async void When_Create_IsCalled_Expect_CreateAndSaveChangesFromUsersRepositoryToBeInvoked_And_MappedResponseToBeReturned()
		{
			//Arrange
			var user = new User()
			{
				Id = Guid.NewGuid(),
				Username = "Username-Create",
				Type = "Type-Create",
				Email = "Email-Create",
				PasswordHash = "Password-Create",
			};
			var userCreated = new CreateUsersModel()
			{
				Username = "Username2-Create",
				Type = "Type2-Create",
				Email = "Email2-Create",
				PasswordHash = "Password2-Create",
			};
			var result = new UsersModel()
			{
				Id = user.Id,
				Username = user.Username,
				Type = user.Type,
				Email = user.Email,
				PasswordHash = user.PasswordHash,
			};

			mapperUserMock
				.Setup(c => c.Map<User>(userCreated))
				.Returns(user);
			userRepositoryMock
				.Setup(c => c.Create(user))
				.Returns(Task.CompletedTask);
			userRepositoryMock
				.Setup(c => c.SaveChanges())
				.Returns(Task.CompletedTask);
			mapperUserMock
				.Setup(m => m.Map<UsersModel>(user))
				.Returns(result);

			//Act
			var resultFinal = await SUT.Create(userCreated);

			//Assert
			resultFinal.Should().BeEquivalentTo(resultFinal);
		}

		[Fact]
		public async void When_Delete_IsCalled_Expect_GetByIdAndDeleteAndSaveChangesFromCommentRepositoryToBeInvoked()
		{
			//Arrange
			var user = new User()
			{
				Id = Guid.NewGuid(),
				Username = "Username-Delete",
				Type = "Type-Delete",
				Email = "Email-Delete",
				PasswordHash = "Password-Delete",
			};

			userRepositoryMock
				.Setup(c => c.GetUserById(user.Id))
				.ReturnsAsync(user);

			userRepositoryMock
				.Setup(d => d.Delete(user));

			userRepositoryMock
				.Setup(s => s.SaveChanges())
				.Returns(Task.CompletedTask);

			//Act
			await SUT.Delete(user.Id);

		}

		[Fact]
		public async void When_Update_IsCalled_Expect_GetByIdAndUpdateAndSaveChangesFromCommentRepositoryToBeInvoked()
		{
			//Arrange
			var user = new User()
			{
				Id = Guid.NewGuid(),
				Username = "Username-Update",
				Type = "Type-Update",
				Email = "Email-Update",
				PasswordHash = "Password-Update",
			};

			var userCreated = new CreateUsersModel()
			{
				Username = user.Username,
				Type = user.Type,
				Email = user.Email,
				PasswordHash = user.PasswordHash,
			};

			userRepositoryMock
				.Setup(c => c.GetUserById(user.Id))
				.ReturnsAsync(user);

			mapperUserMock
				.Setup(m => m.Map(userCreated, user))
				.Returns(user);

			userRepositoryMock
				.Setup(u => u.Update(user));

			userRepositoryMock
				.Setup(s => s.SaveChanges())
				.Returns(Task.CompletedTask);

			//Act

			await SUT.Update(user.Id, userCreated);

		}


	}
}

