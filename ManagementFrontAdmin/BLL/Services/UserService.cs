using BLL.DTOs;
using BLL.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var response = await _httpClient.GetAsync("api/user");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(jsonString);

            return users!;
        }

        public async Task<User> GetUserByEmailPass(string email, string password)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/user/email_pass?email={Uri.EscapeDataString(email)}&password={Uri.EscapeDataString(password)}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<User>(jsonString);

                    return user;
                }else if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null!;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Request failed with status code {response.StatusCode} and reason: {response.ReasonPhrase}. Response content: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
                throw new ApplicationException("An error occured while fetching the user by email password.", ex);
            }
        }

        public Task<User> InsertUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
