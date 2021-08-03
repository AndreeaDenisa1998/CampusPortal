using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Travelers.Business.Travelers.Models.Posts;

namespace Travelers.Api.Tests.Extensions
{
	internal static class HttpClientExtensions
	{
		public static async Task<Guid> CreatePost(this HttpClient client, CreatePostModel model)
		{
			var response = await client.Post(@"api/v1/posts", model);
			return Guid.Parse(response.Headers.Location.ToString());
		}

		public static async Task<HttpResponseMessage> DeletePost(this HttpClient client, Guid id) =>
			await client.DeleteAsync(@$"api/posts/{id}");
		
		public static Task<HttpResponseMessage> Post(this HttpClient client, string url, object data)
        {
            return client.PostAsync(url, data.ToStringContent());
        }

        public static Task<HttpResponseMessage> Put(this HttpClient client, string url, object data)
        {
            return client.PutAsync(url, data.ToStringContent());
        }

        public static async Task<T> Get<T>(this HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
