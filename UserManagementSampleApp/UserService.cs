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
        }

        public async Task<UserDetailsModel> GetUserDetails(int id)
        {
            await Task.Delay(1000);

            return new UserDetailsModel() { Id = id, Forename = "Test", Surname = "User", Email = "Test@Users.com", MobileNumber = "419" };
        }

        public async Task<List<UserSummaryModel>> GetUsersSummariesAsync()
        {
            await Task.Delay(1000);

            return new List<UserSummaryModel>()
            {
                new UserSummaryModel(){ Forename = "Bob", Surname = "Jones", Id = 1},
                new UserSummaryModel(){ Forename = "Tim", Surname = "Smith", Id = 2},
                new UserSummaryModel(){ Forename = "Cathy", Surname = "Burton", Id = 3},
                new UserSummaryModel(){ Forename = "Jane", Surname = "Doe", Id = 4}
            };
        }
    }
}
