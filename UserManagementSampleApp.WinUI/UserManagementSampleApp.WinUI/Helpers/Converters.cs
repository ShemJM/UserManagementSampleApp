using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UserManagementSampleApp.WinUI.Helpers
{
    public static class Converters
    {
        public static Visibility ConvertNotNullToVisibility(object obj)
            => obj is not null ? Visibility.Visible : Visibility.Collapsed;
    }
}
