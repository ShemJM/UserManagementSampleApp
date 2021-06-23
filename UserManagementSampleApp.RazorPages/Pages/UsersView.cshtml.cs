using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserManagementSampleApp.RazorPages.Pages
{
    public class UsersViewModel : PageModel
    {
        public ViewModels.UsersViewModel ViewModel { get; set; }

        public UsersViewModel(ViewModels.UsersViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public async Task OnGetAsync()
        {
            await ViewModel.Initialise();
        }
    }
}
