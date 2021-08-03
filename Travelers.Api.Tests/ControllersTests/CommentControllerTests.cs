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
using Travelers.Business.Travelers.Models.Comments;
using Travelers.Business.Travelers.Models.Posts;
using Travelers.Business.Travelers.Models.Users;
using Xunit;

namespace Travelers.Api.Tests
{
	public class CommentControllerTests:IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly HttpClient client;
		public CommentControllerTests(WebApplicationFactory<Startup> fixture)
		{
			client = fixture.CreateClient();
		}

		[Fact]
		public async Task When_GetComments_Expect_ResponseShouldBeSuccessStatusCode()
		{
			var response = await client.GetAsync("api/v1/users");
			var content = await response.Content.ReadAsStringAsync();
			var users = JsonConvert.DeserializeObject<IEnumerable<UsersModel>>(content);
			var postId = await client.CreatePost(new CreatePostModel
			{
				IdUser = users.FirstOrDefault().Id,
				Content = "Content",
				NumberOfLikes = 40,
				Type = "type",
			});
			var model = new CreateCommentModel()
			{
				IdUser = users.FirstOrDefault().Id,
				PostId = postId,
				Content = "comment",
				NumberOfLikes = 10,
			};
			
			response = await client.PostAsync("api/v1/comments", model.ToStringContent());
			response.IsSuccessStatusCode.Should().BeTrue();

			var result = await client.GetAsync(@$"api/v1/posts/{postId}/comments");
			content = await result.Content.ReadAsStringAsync();
			var comments = JsonConvert.DeserializeObject<List<CommentModel>>(content);
			comments.Should().NotBeEmpty();
			result.IsSuccessStatusCode.Should().BeTrue();

			response = await client.DeleteAsync(@$"api/v1/comments/{comments.First().Id}");
			response.StatusCode.Should().Be(HttpStatusCode.NoContent);
			
			response = await client.DeleteAsync($"api/v1/posts/{postId}");
			response.StatusCode.Should().Be(HttpStatusCode.NoContent);
		}
	}
}
