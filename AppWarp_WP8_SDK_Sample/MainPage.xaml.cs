using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AppWarp_WP8_SDK_Sample.Resources;
using com.shephertz.app42.gaming.multiplayer.client;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace AppWarp_WP8_SDK_Sample
{
    public partial class MainPage : PhoneApplicationPage
    {
        //List<string> serversList;
        public MainPage()
        {
            InitializeComponent();
            apiKey_txtblock.Text = App.Api_key;
            secretKey_txtblock.Text = App.Secret_key;
            //if (serversList != null)
            //{
            //    if (serversList.Count == 0)
            //    {
            //        serversList = new List<string>();
            //        serversList.Add("US");
            //        serversList.Add("EU");
            //        serversList.Add("SP");
            //        serversList.Add("JP");
            //    }
            //}
            //server_listpicker.DataContext = serversList;
            //server_listpicker.ItemsSource = serversList;
            server_listpicker.Items.Add("US");
            server_listpicker.Items.Add("EU");
            server_listpicker.Items.Add("SP");
            server_listpicker.Items.Add("JP");

            //(App.Current as App).responseOC.Add("response 1");

            //(App.Current as App).notificationOC.Add("notification 1");
        }

        private void initialize_btn_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Initialize API called.");
            string API_key = apiKey_txtblock.Text;
            string Secret_key = secretKey_txtblock.Text;
            if (API_key != null && API_key != "" && Secret_key != null && Secret_key != "")
            {
                Byte WarpResponseResultCode = WarpClient.initialize(API_key, Secret_key);
                if (WarpResponseResultCode == 4)
                {
                    MessageBox.Show("WarpClient instance initialize request gave a BAD_REQUEST error!");
                }
                else if (WarpResponseResultCode == 0)
                {
                    MessageBox.Show("WarpClient instance initialized successfully!");
                    WarpClient game = WarpClient.GetInstance();
                    game.AddConnectionRequestListener(new ConListen(this));
                    game.AddTurnBasedRoomRequestListener(new TurnBasedRoomReqListener(this));
                    game.AddUpdateRequestListener(new UpdateReqListener(this));
                    game.AddZoneRequestListener(new ZoneReqListener(this));
                    game.AddLobbyRequestListener(new LobbyReqListener(this));
                    game.AddRoomRequestListener(new RoomReqListener(this));
                    game.AddNotificationListener(new NotificationListener(this));
                    game.AddChatRequestListener(new ChatReqListener(this));
                    if ((bool)recoveryAllowance_togglebtn.IsChecked)
                    {
                        WarpClient.setRecoveryAllowance(20);
                    }
                    string server_location = server_listpicker.SelectedItem.ToString();
                    game.SetGeo(server_location.ToLower());
                }
                else
                {
                    MessageBox.Show("WarpClient instance could not be initialized!");
                }
            }
            else
            {
                MessageBox.Show("Both field are mandatory!");
            }
        }

    }

}