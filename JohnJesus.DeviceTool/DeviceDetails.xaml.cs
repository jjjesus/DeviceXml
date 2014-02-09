using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using JohnJesus.DeviceViewModel;

namespace JohnJesus.DeviceView
{
    /// <summary>
    /// Interaction logic for DeviceDetails.xaml
    /// </summary>
    public partial class DeviceDetails : UserControl
    {
        public DeviceDetails()
        {
            ViewModel = new DeviceDetailsViewModel();
            DataContext = ViewModel;
            InitializeComponent();
        }
        /// <summary>
        /// Gets or sets the ViewModel for this view
        /// </summary>
        public DeviceDetailsViewModel ViewModel { get; private set; }
    }
}
