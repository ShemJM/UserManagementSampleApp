using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace UserManagementSampleApp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = App.Current.Services.GetRequiredService<MainViewModel>();
        }
    }
}
