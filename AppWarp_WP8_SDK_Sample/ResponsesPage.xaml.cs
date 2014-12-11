using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;

namespace AppWarp_WP8_SDK_Sample
{
    public partial class ResponsesPage : PhoneApplicationPage
    {
        public ResponsesPage()
        {
            InitializeComponent();
            responses_longlistselector.ItemsSource = null;
            ObservableCollection<string> reversedResponseOC = new ObservableCollection<string>((App.Current as App).responseOC.Reverse());
            responses_longlistselector.ItemsSource = reversedResponseOC;

        }
    }
}