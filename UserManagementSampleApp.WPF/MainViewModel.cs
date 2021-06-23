using Microsoft.Extensions.DependencyInjection;
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
using UserManagementSampleApp.ViewModels;

namespace UserManagementSampleApp.WPF
{
    public class MainViewModel : ObservableRecipient, IRecipient<UserSelectedMessage>, IRecipient<NewUserRequestMessage>
    {
        private ObservableObject _modalVM;

        public ObservableObject ModalVM
        {
            get { return _modalVM; }
            set { SetProperty(ref _modalVM, value); }
        }

        private ObservableObject _mainVm;

        public ObservableObject MainVM
        {
            get { return _mainVm; }
            set { SetProperty(ref _mainVm, value); }
        }

        public MainViewModel()
        {
            CloseModalCommand = new RelayCommand(CloseModal);
            Load();
        }

        private async void Load()
        {
            WeakReferenceMessenger.Default.Register<UserSelectedMessage>(this);
            WeakReferenceMessenger.Default.Register<NewUserRequestMessage>(this);
            var vm = App.Current.Services.GetRequiredService<UsersViewModel>();
            await vm.Initialise();
            MainVM = vm;
        }

        public async void Receive(UserSelectedMessage message)
        {
            var vm = App.Current.Services.GetRequiredService<UserDetailsViewModel>();
            await vm.Initialise(message.Value);
            ModalVM = vm;
        }

        public ICommand CloseModalCommand { get; }

        private void CloseModal()
        {
            ModalVM = null;
        }

        public void Receive(NewUserRequestMessage message)
        {
            var vm = App.Current.Services.GetRequiredService<AddUserViewModel>();

            ModalVM = vm;
        }
    }
}
