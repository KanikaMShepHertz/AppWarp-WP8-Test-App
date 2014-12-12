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
    public partial class NotificationsPage : PhoneApplicationPage
    {
        public NotificationsPage()
        {
            InitializeComponent();
            //notifications_longlistselector.ItemsSource = (App.Current as App).notificationOC;
            notifications_longlistselector.ItemsSource = null;
            ObservableCollection<string> reversedNotificationOC = new ObservableCollection<string>((App.Current as App).notificationOC.Reverse());
            notifications_longlistselector.ItemsSource = reversedNotificationOC;
        }
    }
}