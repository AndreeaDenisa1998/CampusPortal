using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Travelers.api;
using Travelers.Api.Tests.Extensions;
using Travelers.Business.Travelers.Models.Posts;
using Travelers.Business.Travelers.Models.Reviews;
using Travelers.Business.Travelers.Models.Users;
using Xunit;

namespace Travelers.Api.Tests.ControllersTests
{
	public class ReviewControllerTests:IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly HttpClient client;

		public ReviewControllerTests(WebApplicationFactory<Startup> fixture)
		{
			client = fixture.CreateClient();
		}

		[Fact]
		public async Task When_GetReview_Expect_ResponseShouldBeSuccessStatusCode()
		{
			var response = await client.GetAsync("api/v1/users");
			var content = await response.Content.ReadAsStringAsync();
			var users = JsonConvert.DeserializeObject<IEnumerable<UsersModel>>(content);
			var postId = await client.CreatePost(new CreatePostModel
			{
				IdUser = users.FirstOrDefault().Id,
				Content = "Content for post",
				NumberOfLikes = 320,
				Type = "type-post",
			});
			var model = new CreateReviewModel()
			{
				IdUser = users.FirstOrDefault().Id,
				PostId = postId,
				Content = "content-review",
				NumberOfLikes = 19,
				NumberOfStars = 20,
			};

			response = await client.PostAsync("api/v1/reviews", model.ToStringContent());
			response.IsSuccessStatusCode.Should().BeTrue();

			var result = await client.GetAsync(@$"api/v1/posts/{postId}/reviews");
			content = await result.Content.ReadAsStringAsync();
			var reviews = JsonConvert.DeserializeObject<List<ReviewModel>>(content);
			reviews.Should().NotBeEmpty();
			result.IsSuccessStatusCode.Should().BeTrue();

			response = await client.DeleteAsync(@$"api/v1/reviews/{reviews.First().Id}");
			response.StatusCode.Should().Be(HttpStatusCode.NoContent);

			response = await client.DeleteAsync($"api/v1/posts/{postId}");
			response.StatusCode.Should().Be(HttpStatusCode.NoContent);

		}
	}
}
