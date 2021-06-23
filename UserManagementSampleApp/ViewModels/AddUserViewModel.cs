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
    public class AddUserViewModel : ObservableObject
    {
        private readonly IUserService _userService;

        public AddUserViewModel(IUserService userService)
        {
            _userService = userService;
            CreateUserCommand = new RelayCommand(CreateUser);
        }

        private string _forename;

        public string Forename
        {
            get { return _forename; }
            set { SetProperty(ref _forename, value); }
        }

        private string _surname;

        public string Surname
        {
            get { return _surname; }
            set { SetProperty(ref _surname, value); }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _mobileNumber;

        public string MobileNumber
        {
            get { return _mobileNumber; }
            set { SetProperty(ref _mobileNumber, value); }
        }

        public ICommand CreateUserCommand { get; }

        private async void CreateUser()
        {
            var createUser = new CreateUserModel() { Email = Email, Forename = Forename, MobileNumber = MobileNumber, Surname = Surname };

            await _userService.CreateUser(createUser);

            WeakReferenceMessenger.Default.Send(new NewUserCreatedMessage());
        }
    }
}
