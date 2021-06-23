using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserManagementSampleApp.Messages;
using UserManagementSampleApp.Models;

namespace UserManagementSampleApp.ViewModels
{
    public class UsersViewModel : ObservableRecipient, IRecipient<NewUserCreatedMessage>
    {
        private IUserService _userService;

        private List<UserSummaryModel> _users;

        public List<UserSummaryModel> Users
        {
            get { return _users; }
            set { SetProperty(ref _users, value); }
        }

        public UsersViewModel(IUserService userService)
        {
            _userService = userService;

            SelectUserCommand = new RelayCommand<UserSummaryModel>(SelectUser);
            RequestNewUserCreationCommand = new RelayCommand(RequestNewUserCreation);

            WeakReferenceMessenger.Default.Register<NewUserCreatedMessage>(this);
        }

        public ICommand SelectUserCommand { get; }

        private void SelectUser(UserSummaryModel user)
        {
            WeakReferenceMessenger.Default.Send(new UserSelectedMessage(user.Id));
        }

        public ICommand RequestNewUserCreationCommand { get; }

        private void RequestNewUserCreation()
        {
            WeakReferenceMessenger.Default.Send(new NewUserRequestMessage());
        }

        public async Task Initialise()
        {
            await GetUsers();
        }

        public async void Receive(NewUserCreatedMessage message)
        {
            await GetUsers();
        }

        private async Task GetUsers()
        {
            Users = await _userService.GetUsersSummariesAsync();
        }
    }
}
