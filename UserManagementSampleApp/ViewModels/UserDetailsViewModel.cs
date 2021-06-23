using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSampleApp.Models;

namespace UserManagementSampleApp.ViewModels
{
    public class UserDetailsViewModel : ObservableObject
    {
        private readonly IUserService _userService;

        private UserDetailsModel _user;

        public UserDetailsModel User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }


        public UserDetailsViewModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Initialise(int id)
        {
            UserDetailsModel user = await _userService.GetUserDetails(id);

            User = user;
        }
    }
}