using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSampleApp.Models;

namespace UserManagementSampleApp
{
    public interface IUserService
    {
        Task<List<UserSummaryModel>> GetUsersSummariesAsync();
        Task<UserDetailsModel> GetUserDetails(int id);
        Task CreateUser(CreateUserModel createUser);
    }

    public class UserService : IUserService
    {
        public async Task CreateUser(CreateUserModel createUser)
        {
            await Task.Delay(1000);

            SomeData.Users.Add(new UserDetailsModel() { Email = createUser.Email, Surname = createUser.Surname, Forename = createUser.Forename, MobileNumber = createUser.MobileNumber });
        }

        public async Task<UserDetailsModel> GetUserDetails(int id)
        {
            await Task.Delay(1000);

            return SomeData.Users.Find(u => u.Id == id);
        }

        public async Task<List<UserSummaryModel>> GetUsersSummariesAsync()
        {
            await Task.Delay(1000);

            return SomeData.Users.Select(u => new UserSummaryModel() { Forename = u.Forename, Id = u.Id, Surname = u.Surname }).ToList();
        }
    }

    public static class SomeData
    {
        public static List<UserDetailsModel> Users { get; set; }

        public static void SeedData()
        {
            Users = new List<UserDetailsModel>()
            {
                new UserDetailsModel() { Email = "Bob@Users", Forename = "Bob", Surname = "Jones", Id = 1 },
                new UserDetailsModel() { Email = "Tim@Users", Forename = "Tim", Surname = "Smith", Id = 2 },
                new UserDetailsModel() { Email = "Cathy@Users", Forename = "Cathy", Surname = "Burton", Id = 3 },
                new UserDetailsModel() { Email = "Jane@Users", Forename = "Jane", Surname = "Doe", Id = 4 }
            };
        }
    }
}