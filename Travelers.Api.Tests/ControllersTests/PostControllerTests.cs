using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Travelers.api;
using Travelers.Api.Tests.Extensions;
using Travelers.Business.Travelers.Models.Posts;
using Travelers.Business.Travelers.Models.Users;
using Xunit;

namespace Travelers.Api.Tests.ControllersTests
{
	public class PostControllerTests : IClassFixture<WebApplicationFactory<Startup>>
	{
		public PostControllerTests(WebApplicationFactory<Startup> fixture)
		{
			Client = fixture.CreateClient();
		}

		public HttpClient Client { get; }

		[Fact]
		public async void When_GetPosts_Expect_ResponseShouldBeSuccessStatusCode()
		{
			var result = await Client.GetAsync(@"/api/v1/posts");

			Assert.True(result.IsSuccessStatusCode);
		}

		[Fact]
		public async void When_CreatePost_Expect_ResponseShouldBeSuccessStatusCodeAndProvideTheId()
		{
			var response = await Client.GetAsync("api/v1/users");
			var content = await response.Content.ReadAsStringAsync();
			var users = JsonConvert.DeserializeObject<IEnumerable<UsersModel>>(content);
			var id = await Client.CreatePost(new CreatePostModel
			{
				IdUser = users.FirstOrDefault().Id,
				Content = "Content for post",
				NumberOfLikes = 320,
				Type = "type-post",
			});
			var model = new CreatePostModel
			{
				IdUser = users.FirstOrDefault().Id,
				Content = "Content for post",
				NumberOfLikes = 320,
				Type = "type-post",
			};

			var x = id.Should().NotBeEmpty();

			var post = await Client.Get<PostModel>($@"api/v1/posts/{id}");

			post.IdUser.Should().Be(model.IdUser);
			post.Content.Should().BeEquivalentTo(model.Content);
			post.NumberOfLikes.Should().Be(model.NumberOfLikes);
			post.Type.Should().BeEquivalentTo(model.Type);
			

			await Client.Put($@"api/posts/{id}", model);
			post = await Client.Get<PostModel>($@"api/v1/posts/{id}");
			post.Content.Should().BeEquivalentTo(model.Content);

			await Client.DeletePost(id);
		}

		[Fact]
		public async void Given_PostDoesNotExist_When_GetById_Expect_BadRequestResponse()
		{
			var id = "627d9a9b-e3a4-4cfa-908e";  

			var response = await Client.GetAsync($@"api/v1/posts/{id}");

			response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
		}

		[Fact]
		public async void When_GetPost_Expect_ResponseShouldBeSuccessStatusCode()
		{
			var id = "627d9a9b-e3a4-4cfa-908e-1673be981c67";
			var result = await Client.GetAsync($@"/api/v1/posts/{id}");

			Assert.True(result.IsSuccessStatusCode);
		}
	}
}
