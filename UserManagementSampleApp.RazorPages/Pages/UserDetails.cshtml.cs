using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementSampleApp.ViewModels;

namespace UserManagementSampleApp.RazorPages.Pages
{
    public class UserDetailsModel : PageModel
    {
        public UserDetailsViewModel ViewModel { get; set; }

        public UserDetailsModel(UserDetailsViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public async Task OnGetAsync(int id)
        {
            await ViewModel.Initialise(id);
        }
    }
}
