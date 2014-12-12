using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Diagnostics;
using com.shephertz.app42.gaming.multiplayer.client;
using Coding4Fun.Toolkit.Controls;
using System.Windows.Media;

namespace AppWarp_WP8_SDK_Sample
{
    public partial class APIsPage : PhoneApplicationPage
    {
        ConListen objConListen = null;
        ZoneReqListener objZoneReqListener = null;
        RoomReqListener objRoomReqListener = null;
        LobbyReqListener objLobbyReqListener = null;
        TurnBasedRoomReqListener objTurnBasedRoomReqListener = null;
        ChatReqListener objChatReqListener = null;
        UpdateReqListener objUpdateReqListener = null;
        NotificationListener objNotificationListener = null;
        int sessionId = 0;
        string userName = null;
        string roomId = null;
        string propertyKey = null;

        public APIsPage()
        {
            InitializeComponent();
            List<APIs> source = new List<APIs>();
            //source.Add(new APIs("GetInstance"));
            source.Add(new APIs("GetSessionId"));
            source.Add(new APIs("GetApiKey"));
            source.Add(new APIs("GetPrivateKey"));
            //source.Add(new APIs("SetApiKey"));
            //source.Add(new APIs("SetPrivateKey"));
            //source.Add(new APIs("SetServer"));
            //source.Add(new APIs("SetGeo"));
            //source.Add(new APIs("AddConnectionRequestListener"));
            //source.Add(new APIs("RemoveConnectionRequestListener"));
            //source.Add(new APIs("AddZoneRequestListener"));
            //source.Add(new APIs("RemoveZoneRequestListener"));
            //source.Add(new APIs("AddLobbyRequestListener"));
            //source.Add(new APIs("RemoveLobbyRequestListener"));
            //source.Add(new APIs("AddRoomRequestListener"));
            //source.Add(new APIs("RemoveRoomRequestListener"));
            //source.Add(new APIs("AddChatRequestListener"));
            //source.Add(new APIs("AddTurnBasedRoomRequestListener"));
            //source.Add(new APIs("RemoveTurnBasedRoomRequestListener"));
            //source.Add(new APIs("RemoveChatRequestListener"));
            //source.Add(new APIs("AddUpdateRequestListener"));
            //source.Add(new APIs("RemoveUpdateRequestListener"));
            //source.Add(new APIs("AddNotificationListener"));
            //source.Add(new APIs("RemoveNotificationListener"));
            source.Add(new APIs("Connect"));
            source.Add(new APIs("Disconnect"));
            source.Add(new APIs("GetConnectionState"));
            source.Add(new APIs("RecoverConnection"));
            source.Add(new APIs("RecoverConnectionWithSessioId"));
            source.Add(new APIs("setRecoveryAllowance"));
            source.Add(new APIs("SetCustomRoomData"));
            source.Add(new APIs("SetCustomUserData"));
            source.Add(new APIs("GetOnlineUsers"));
            source.Add(new APIs("GetAllRooms"));
            source.Add(new APIs("GetLiveUserInfo"));
            source.Add(new APIs("GetLiveRoomInfo"));
            source.Add(new APIs("GetLiveLobbyInfo"));
            source.Add(new APIs("JoinLobby"));
            source.Add(new APIs("LeaveLobby"));
            source.Add(new APIs("SubscribeLobby"));
            source.Add(new APIs("UnsubscribeLobby"));
            source.Add(new APIs("CreateRoom"));
            source.Add(new APIs("CreateTurnBasedRoom"));
            source.Add(new APIs("DeleteRoom"));
            source.Add(new APIs("LeaveRoom"));
            source.Add(new APIs("JoinRoom"));
            source.Add(new APIs("SubscribeRoom"));
            source.Add(new APIs("UnsubscribeRoom"));
            source.Add(new APIs("SendChat"));
            source.Add(new APIs("sendPrivateChat"));
            source.Add(new APIs("sendUDPPrivateUpdate"));
            source.Add(new APIs("sendPrivateUpdate"));
            source.Add(new APIs("SendUDPUpdatePeers"));
            source.Add(new APIs("initUDP"));
            source.Add(new APIs("SendUpdatePeers"));
            source.Add(new APIs("startGame"));
            source.Add(new APIs("stopGame"));
            source.Add(new APIs("getMoveHistory"));
            source.Add(new APIs("LockProperties"));
            source.Add(new APIs("UnlockProperties"));
            source.Add(new APIs("UpdateRoomProperties"));
            source.Add(new APIs("JoinRoomWithProperties"));
            source.Add(new APIs("JoinRoomInRange"));
            source.Add(new APIs("GetRoomsInRange"));
            source.Add(new APIs("GetRoomWithProperties"));
            source.Add(new APIs("SetNextTurn"));
            source.Add(new APIs("sendMove"));

            List<AlphaKeyGroup<APIs>> DataSource = AlphaKeyGroup<APIs>.CreateGroups(source,
                System.Threading.Thread.CurrentThread.CurrentUICulture,
                (APIs s) => { return s.APIName; }, true);
            api_longlistselector.ItemsSource = null;
            api_longlistselector.ItemsSource = DataSource;
        }

        private void api_longlistselector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string APIname = null;
            try
            {
                APIs selectedAPI = (APIs)api_longlistselector.SelectedItem;
                APIname = selectedAPI.APIName;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            if (APIname != null)
            {
                switch (APIname)
                {
                    case "GetInstance":
                        Debug.WriteLine("GetInstance API called.");
                        break;
                    case "GetSessionId":
                        Debug.WriteLine("GetSessionId API called.");
                        int sessionId = WarpClient.GetInstance().GetSessionId();
                        Deployment.Current.Dispatcher.BeginInvoke(() =>
               {
                   (App.Current as App).responseOC.Add("sessio Id = " + sessionId);
               });
                        break;
                    case "GetApiKey":
                        Debug.WriteLine("GetApiKey API called.");
                        string apiKey = WarpClient.GetInstance().GetApiKey();
                        Deployment.Current.Dispatcher.BeginInvoke(() =>
               {
                   (App.Current as App).responseOC.Add("API key = " + apiKey);
               });
                        break;
                    case "GetPrivateKey":
                        Debug.WriteLine("GetPrivateKey API called.");
                        string secretKey = WarpClient.GetInstance().GetPrivateKey();
                        Deployment.Current.Dispatcher.BeginInvoke(() =>
               {
                   (App.Current as App).responseOC.Add("Secret key = " + secretKey);
               });
                        break;
                    case "SetApiKey":
                        Debug.WriteLine("SetApiKey API called.");
                        InputPrompt prompt21 = new InputPrompt();
                        prompt21.Completed += input_completed21;
                        prompt21.Title = "API Key";
                        prompt21.Message = "Please enter the API key";
                        prompt21.Show();
                        break;
                    case "SetPrivateKey":
                        Debug.WriteLine("SetPrivateKey API called.");
                        InputPrompt prompt22 = new InputPrompt();
                        prompt22.Completed += input_completed22;
                        prompt22.Title = "Secret Key";
                        prompt22.Message = "Please enter the Secret key";
                        prompt22.Show();
                        break;
                    case "SetServer":
                        Debug.WriteLine("SetServer API called.");
                        break;
                    case "SetGeo":
                        Debug.WriteLine("SetGeo API called.");
                        //geo_select_popup.IsOpen = true;
                        break;
                    case "AddConnectionRequestListener":
                        Debug.WriteLine("AddConnectionRequestListener API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient game = WarpClient.GetInstance();
                            objConListen = new ConListen();
                            game.AddConnectionRequestListener(objConListen);
                        }
                        break;
                    case "RemoveConnectionRequestListener":
                        Debug.WriteLine("RemoveConnectionRequestListener API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient game = WarpClient.GetInstance();
                            game.RemoveConnectionRequestListener(objConListen);
                        }
                        break;
                    case "AddZoneRequestListener":
                        Debug.WriteLine("AddZoneRequestListener API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient game = WarpClient.GetInstance();
                            objZoneReqListener = new ZoneReqListener();
                            game.AddZoneRequestListener(objZoneReqListener);
                        }
                        break;
                    case "RemoveZoneRequestListener":
                        Debug.WriteLine("RemoveZoneRequestListener API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient game = WarpClient.GetInstance();
                            game.RemoveZoneRequestListener(objZoneReqListener);
                        }
                        break;
                    case "AddLobbyRequestListener":
                        Debug.WriteLine("AddLobbyRequestListener API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient game = WarpClient.GetInstance();
                            objLobbyReqListener = new LobbyReqListener();
                            game.AddLobbyRequestListener(objLobbyReqListener);
                        }
                        break;
                    case "RemoveLobbyRequestListener":
                        Debug.WriteLine("RemoveLobbyRequestListener API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient game = WarpClient.GetInstance();
                            game.RemoveLobbyRequestListener(objLobbyReqListener);
                        }
                        break;
                    case "AddRoomRequestListener":
                        Debug.WriteLine("AddRoomRequestListener API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient game = WarpClient.GetInstance();
                            objRoomReqListener = new RoomReqListener();
                            game.AddRoomRequestListener(objRoomReqListener);
                        }
                        break;
                    case "RemoveRoomRequestListener":
                        Debug.WriteLine("RemoveRoomRequestListener API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient game = WarpClient.GetInstance();
                            game.RemoveRoomRequestListener(objRoomReqListener);
                        }
                        break;
                    case "AddChatRequestListener":
                        Debug.WriteLine("AddChatRequestListener API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient game = WarpClient.GetInstance();
                            objChatReqListener = new ChatReqListener();
                            game.AddChatRequestListener(objChatReqListener);
                        }
                        break;
                    case "AddTurnBasedRoomRequestListener":
                        Debug.WriteLine("AddTurnBasedRoomRequestListener API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient game = WarpClient.GetInstance();
                            objTurnBasedRoomReqListener = new TurnBasedRoomReqListener();
                            game.AddTurnBasedRoomRequestListener(objTurnBasedRoomReqListener);
                        }
                        break;
                    case "RemoveTurnBasedRoomRequestListener":
                        Debug.WriteLine("RemoveTurnBasedRoomRequestListener API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient game = WarpClient.GetInstance();
                            game.RemoveTurnBasedRoomRequestListener(objTurnBasedRoomReqListener);
                        }
                        break;
                    case "RemoveChatRequestListener":
                        Debug.WriteLine("RemoveChatRequestListener API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient game = WarpClient.GetInstance();
                            game.RemoveChatRequestListener(objChatReqListener);
                        }
                        break;
                    case "AddUpdateRequestListener":
                        Debug.WriteLine("AddUpdateRequestListener API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient game = WarpClient.GetInstance();
                            objUpdateReqListener = new UpdateReqListener();
                            game.AddUpdateRequestListener(objUpdateReqListener);
                        }
                        break;
                    case "RemoveUpdateRequestListener":
                        Debug.WriteLine("RemoveUpdateRequestListener API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient game = WarpClient.GetInstance();
                            game.RemoveUpdateRequestListener(objUpdateReqListener);
                        }
                        break;
                    case "AddNotificationListener":
                        Debug.WriteLine("AddNotificationListener API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient game = WarpClient.GetInstance();
                            objNotificationListener = new NotificationListener();
                            game.AddNotificationListener(objNotificationListener);
                        }
                        break;
                    case "RemoveNotificationListener":
                        Debug.WriteLine("RemoveNotificationListener API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient game = WarpClient.GetInstance();
                            game.RemoveNotificationListener(objNotificationListener);
                        }
                        break;
                    case "Connect":
                        Debug.WriteLine("Connect API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient.GetInstance().Connect(App.USER_NAME);
                        }
                        else
                        {
                            MessageBox.Show("Please click on Initialize before connecting.");
                        }
                        break;
                    case "Disconnect":
                        Debug.WriteLine("Disconnect API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient.GetInstance().Disconnect();
                        }
                        else
                        {
                            MessageBox.Show("Please click on Initialize and connect before disconnecting.");
                        }
                        break;
                    case "GetConnectionState":
                        Debug.WriteLine("GetConnectionState API called.");
                        //byte connectionState = WarpClient.GetInstance().GetConnectionState();
                        Global_data.populateResponseListFromCallback("GetConnectionState");
                        break;
                    case "RecoverConnection":
                        Debug.WriteLine("RecoverConnection API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient.GetInstance().RecoverConnection();
                        }
                        else
                        {
                            MessageBox.Show("Please click on Initialize before recover connection.");
                        }
                        break;
                    case "RecoverConnectionWithSessioId":
                        Debug.WriteLine("RecoverConnectionWithSessioId API called.");
                        InputPrompt prompt = new InputPrompt();
                        //prompt.Background = new SolidColorBrush(Colors.Green);
                        prompt.Completed += input_completed;
                        prompt.Title = "Session Id";
                        prompt.Message = "Please enter a session id";
                        prompt.Show();
                        break;
                    case "setRecoveryAllowance":
                        Debug.WriteLine("setRecoveryAllowance API called.");
                        InputPrompt prompt2 = new InputPrompt();
                        prompt2.Completed += input_completed2;
                        prompt2.Title = "Max Recovery Time";
                        prompt2.Message = "Please enter max recovery time";
                        prompt2.Show();
                        break;
                    case "SetCustomRoomData":
                        Debug.WriteLine("SetCustomRoomData API called.");
                        InputPrompt prompt5 = new InputPrompt();
                        prompt5.Completed += input_completed5;
                        prompt5.Title = "Custom Room Id";
                        prompt5.Message = "Please enter custom Room Id";
                        prompt5.Show();
                        break;
                    case "SetCustomUserData":
                        Debug.WriteLine("SetCustomUserData API called.");
                        InputPrompt prompt7 = new InputPrompt();
                        prompt7.Completed += input_completed7;
                        prompt7.Title = "User Name";
                        prompt7.Message = "Please enter a user name";
                        prompt7.Show();
                        break;
                    case "GetOnlineUsers":
                        Debug.WriteLine("GetOnlineUsers API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient.GetInstance().GetOnlineUsers();
                        }
                        break;
                    case "GetAllRooms":
                        Debug.WriteLine("GetAllRooms API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient.GetInstance().GetAllRooms();
                        }
                        break;
                    case "GetLiveUserInfo":
                        Debug.WriteLine("GetLiveUserInfo API called.");
                        InputPrompt prompt9 = new InputPrompt();
                        prompt9.Completed += input_completed9;
                        prompt9.Title = "User Name";
                        prompt9.Message = "Please enter a user name";
                        prompt9.Show();
                        break;
                    case "GetLiveRoomInfo":
                        Debug.WriteLine("GetLiveRoomInfo API called.");
                        InputPrompt prompt10 = new InputPrompt();
                        prompt10.Completed += input_completed10;
                        prompt10.Title = "Room Id";
                        prompt10.Message = "Please enter the room id.";
                        prompt10.Show();
                        break;
                    case "GetLiveLobbyInfo":
                        Debug.WriteLine("GetLiveLobbyInfo API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient.GetInstance().GetLiveLobbyInfo();
                        }
                        break;
                    case "JoinLobby":
                        Debug.WriteLine("JoinLobby API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient.GetInstance().JoinLobby();
                        }
                        break;
                    case "LeaveLobby":
                        Debug.WriteLine("LeaveLobby API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient.GetInstance().LeaveLobby();
                        }
                        break;
                    case "SubscribeLobby":
                        Debug.WriteLine("SubscribeLobby API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient.GetInstance().SubscribeLobby();
                        }
                        break;
                    case "UnsubscribeLobby":
                        Debug.WriteLine("UnsubscribeLobby API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient.GetInstance().UnsubscribeLobby();
                        }
                        break;
                    case "CreateRoom":
                        Debug.WriteLine("CreateRoom API called.");
                        InputPrompt prompt3 = new InputPrompt();
                        prompt3.Completed += input_completed3;
                        prompt3.Title = "Room name";
                        prompt3.Message = "Please enter a name for the room";
                        prompt3.Show();
                        break;
                    case "CreateTurnBasedRoom":
                        Debug.WriteLine("CreateTurnBasedRoom API called.");
                        InputPrompt prompt4 = new InputPrompt();
                        prompt4.Completed += input_completed4;
                        prompt4.Title = "Room name";
                        prompt4.Message = "Please enter a name for the room";
                        prompt4.Show();
                        break;
                    case "DeleteRoom":
                        Debug.WriteLine("DeleteRoom API called.");
                        InputPrompt prompt11 = new InputPrompt();
                        prompt11.Completed += input_completed11;
                        prompt11.Title = "Room Id";
                        prompt11.Message = "Please enter Room Id";
                        prompt11.Show();
                        break;
                    case "LeaveRoom":
                        Debug.WriteLine("LeaveRoom API called.");
                        InputPrompt prompt12 = new InputPrompt();
                        prompt12.Completed += input_completed12;
                        prompt12.Title = "Room Id";
                        prompt12.Message = "Please enter Room Id";
                        prompt12.Show();
                        break;
                    case "JoinRoom":
                        Debug.WriteLine("JoinRoom API called.");
                        InputPrompt prompt13 = new InputPrompt();
                        prompt13.Completed += input_completed13;
                        prompt13.Title = "Room Id";
                        prompt13.Message = "Please enter Room Id";
                        prompt13.Show();
                        break;
                    case "SubscribeRoom":
                        Debug.WriteLine("SubscribeRoom API called.");
                        InputPrompt prompt14 = new InputPrompt();
                        prompt14.Completed += input_completed14;
                        prompt14.Title = "Room Id";
                        prompt14.Message = "Please enter Room Id";
                        prompt14.Show();
                        break;
                    case "UnsubscribeRoom":
                        Debug.WriteLine("UnsubscribeRoom API called.");
                        InputPrompt prompt15 = new InputPrompt();
                        prompt15.Completed += input_completed15;
                        prompt15.Title = "Room Id";
                        prompt15.Message = "Please enter Room Id";
                        prompt15.Show();
                        break;
                    case "SendChat":
                        Debug.WriteLine("SendChat API called.");
                        InputPrompt prompt16 = new InputPrompt();
                        prompt16.Completed += input_completed16;
                        prompt16.Title = "Message";
                        prompt16.Message = "Please enter your message";
                        prompt16.Show();
                        break;
                    case "sendPrivateChat":
                        Debug.WriteLine("sendPrivateChat API called.");
                        InputPrompt prompt17 = new InputPrompt();
                        prompt17.Completed += input_completed17;
                        prompt17.Title = "User Name";
                        prompt17.Message = "Please enter a user name";
                        prompt17.Show();
                        break;
                    case "sendUDPPrivateUpdate":
                        Debug.WriteLine("sendUDPPrivateUpdate API called.");
                        InputPrompt prompt23 = new InputPrompt();
                        prompt23.Completed += input_completed23;
                        prompt23.Title = "User Name";
                        prompt23.Message = "Please enter a user name";
                        prompt23.Show();
                        break;
                    case "sendPrivateUpdate":
                        Debug.WriteLine("sendPrivateUpdate API called.");
                        InputPrompt prompt24 = new InputPrompt();
                        prompt24.Completed += input_completed24;
                        prompt24.Title = "User Name";
                        prompt24.Message = "Please enter a user name";
                        prompt24.Show();
                        break;
                    case "SendUDPUpdatePeers":
                        Debug.WriteLine("SendUDPUpdatePeers API called.");
                        WarpClient.GetInstance().SendUDPUpdatePeers(new byte[1234]);
                        break;
                    case "initUDP":
                        Debug.WriteLine("initUDP API called.");
                        try
                        {
                            if (WarpClient.GetInstance() != null)
                            {
                                WarpClient.GetInstance().initUDP();
                            }
                            else
                            {
                                MessageBox.Show("Please click on Initialize before initUDP.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                        break;
                    case "SendUpdatePeers":
                        Debug.WriteLine("SendUpdatePeers API called.");
                        WarpClient.GetInstance().SendUpdatePeers(new byte[1234]);
                        break;
                    case "startGame":
                        Debug.WriteLine("startGame API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            //default parameters are passed since no explicit parametrs are provided here.
                            WarpClient.GetInstance().startGame();
                        }
                        break;
                    case "stopGame":
                        Debug.WriteLine("stopGame API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient.GetInstance().stopGame();
                        }
                        break;
                    case "getMoveHistory":
                        Debug.WriteLine("getMoveHistory API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient.GetInstance().getMoveHistory();
                        }
                        break;
                    case "LockProperties":
                        Debug.WriteLine("LockProperties API called.");
                        InputPrompt prompt25 = new InputPrompt();
                        prompt25.Completed += input_completed25;
                        prompt25.Title = "Property key";
                        prompt25.Message = "Please enter a Property key";
                        prompt25.Show();
                        break;
                    case "UnlockProperties":
                        Debug.WriteLine("UnlockProperties API called.");
                        InputPrompt prompt27 = new InputPrompt();
                        prompt27.Completed += input_completed27;
                        prompt27.Title = "Property key";
                        prompt27.Message = "Please enter a Property key";
                        prompt27.Show();
                        break;
                    case "UpdateRoomProperties":
                        Debug.WriteLine("UpdateRoomProperties API called.");
                        InputPrompt prompt28 = new InputPrompt();
                        prompt28.Completed += input_completed28;
                        prompt28.Title = "Room Id";
                        prompt28.Message = "Please enter Room Id";
                        prompt28.Show();
                        break;
                    case "JoinRoomWithProperties":
                        Debug.WriteLine("JoinRoomWithProperties API called.");
                        InputPrompt prompt31 = new InputPrompt();
                        prompt31.Completed += input_completed31;
                        prompt31.Title = "Property key";
                        prompt31.Message = "Please enter a Property key";
                        prompt31.Show();
                        break;
                    case "JoinRoomInRange":
                        Debug.WriteLine("JoinRoomInRange API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient.GetInstance().JoinRoomInRange(0,4,true);
                        }
                        break;
                    case "GetRoomsInRange":
                        Debug.WriteLine("GetRoomsInRange API called.");
                        if (WarpClient.GetInstance() != null)
                        {
                            WarpClient.GetInstance().GetRoomsInRange(0,4);
                        }
                        break;
                    case "GetRoomWithProperties":
                        Debug.WriteLine("GetRoomWithProperties API called.");
                        InputPrompt prompt32 = new InputPrompt();
                        prompt32.Completed += input_completed32;
                        prompt32.Title = "Property key";
                        prompt32.Message = "Please enter a Property key";
                        prompt32.Show();
                        break;
                    case "SetNextTurn":
                        Debug.WriteLine("SetNextTurn API called.");
                        InputPrompt prompt19 = new InputPrompt();
                        prompt19.Completed += input_completed19;
                        prompt19.Title = "Next Turn User Name";
                        prompt19.Message = "Please enter a user name to set the next turn for";
                        prompt19.Show();
                        break;
                    case "sendMove":
                        Debug.WriteLine("sendMove API called.");
                        InputPrompt prompt20 = new InputPrompt();
                        prompt20.Completed += input_completed20;
                        prompt20.Title = "Move Data";
                        prompt20.Message = "Please enter your move data to be sent.";
                        prompt20.Show();
                        break;
                    default:
                        MessageBox.Show("No valid API was selected.Please select one.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("No valid API was selected.Please select one.");
            }
        }

        private void input_completed32(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                propertyKey = e.Result;
                InputPrompt prompt33 = new InputPrompt();
                prompt33.Completed += input_completed33;
                prompt33.Title = "Property value";
                prompt33.Message = "Please enter the property value for the key : " + propertyKey;
                prompt33.Show();
            }
        }

        private void input_completed33(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                Dictionary<String, Object> property = new Dictionary<string, object>();
                property.Add(propertyKey, e.Result);
                WarpClient.GetInstance().GetRoomWithProperties(property);
            }
        }

        private void input_completed31(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                propertyKey = e.Result;
                InputPrompt prompt34 = new InputPrompt();
                prompt34.Completed += input_completed34;
                prompt34.Title = "Property value";
                prompt34.Message = "Please enter the property value for the key : " + propertyKey;
                prompt34.Show();
            }
        }

        private void input_completed34(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                Dictionary<String, Object> property = new Dictionary<string, object>();
                property.Add(propertyKey, e.Result);
                WarpClient.GetInstance().JoinRoomWithProperties(property);
            }
        }

        private void input_completed28(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                roomId = e.Result;
                InputPrompt prompt29 = new InputPrompt();
                prompt29.Completed += input_completed29;
                prompt29.Title = "Property key";
                prompt29.Message = "Please enter the property key";
                prompt29.Show();
            }
        }

        private void input_completed29(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                propertyKey = e.Result;
                InputPrompt prompt30 = new InputPrompt();
                prompt30.Completed += input_completed30;
                prompt30.Title = "Property value";
                prompt30.Message = "Please enter the property value for the key : " + propertyKey;
                prompt30.Show();
            }
        }

        private void input_completed30(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                Dictionary<String, Object> property = new Dictionary<string, object>();
                property.Add(propertyKey, e.Result);
                WarpClient.GetInstance().UpdateRoomProperties(roomId, property, null);
            }
        }

        private void input_completed27(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                List<string> listOfProperties = new List<string>();
                listOfProperties.Add(e.Result);
                WarpClient.GetInstance().UnlockProperties(listOfProperties);
            }
        }

        private void input_completed25(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                propertyKey = e.Result;
                InputPrompt prompt26 = new InputPrompt();
                prompt26.Completed += input_completed26;
                prompt26.Title = "Property value";
                prompt26.Message = "Please enter the property value for the key : "+propertyKey;
                prompt26.Show();
            }
        }

        private void input_completed26(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                Dictionary<String, Object> property = new Dictionary<string, object>();
                property.Add(propertyKey, e.Result);
                WarpClient.GetInstance().LockProperties(property);
            }
        }

        private void input_completed24(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                userName = e.Result;
                byte[] update = new byte[1234];
                WarpClient.GetInstance().sendPrivateUpdate(userName, update);
            }
        }

        private void input_completed23(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                userName = e.Result;
                byte[] update = new byte[1234];
                WarpClient.GetInstance().sendUDPPrivateUpdate(userName,update);
            }
        }

        private void input_completed22(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                WarpClient.GetInstance().SetPrivateKey(e.Result);
            }
        }

        private void input_completed21(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                WarpClient.GetInstance().SetApiKey(e.Result);
            }
        }

        private void input_completed20(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                //default parameter for next turn user is passed as we have not specified any username for next move here.
                WarpClient.GetInstance().sendMove(e.Result);
            }
        }

        private void input_completed19(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                userName = e.Result;
                WarpClient.GetInstance().SetNextTurn(userName);
            }
        }

        private void input_completed17(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                userName = e.Result;
                InputPrompt prompt18 = new InputPrompt();
                prompt18.Completed += input_completed18;
                prompt18.Title = "Private Message";
                prompt18.Message = "Please enter your private message";
                prompt18.Show();
            }
        }

        private void input_completed18(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                string message = e.Result;
                WarpClient.GetInstance().sendPrivateChat(userName,message);
            }
        }

        private void input_completed16(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                string message = e.Result;
                WarpClient.GetInstance().SendChat(message);
            }
        }

        private void input_completed15(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                roomId = e.Result;
                WarpClient.GetInstance().UnsubscribeRoom(roomId);
            }
        }

        private void input_completed14(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                roomId = e.Result;
                WarpClient.GetInstance().SubscribeRoom(roomId);
            }
        }

        private void input_completed13(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                roomId = e.Result;
                WarpClient.GetInstance().JoinRoom(roomId);
            }
        }

        private void input_completed12(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                roomId = e.Result;
                WarpClient.GetInstance().LeaveRoom(roomId);
            }
        }

        private void input_completed11(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                roomId = e.Result;
                WarpClient.GetInstance().DeleteRoom(roomId);
            }
        }

        private void input_completed10(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                roomId = e.Result;
                WarpClient.GetInstance().GetLiveRoomInfo(roomId);
            }
        }

        private void input_completed9(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                userName = e.Result;
                WarpClient.GetInstance().GetLiveUserInfo(userName);
            }
        }

        private void input_completed7(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                userName = e.Result;
                InputPrompt prompt8 = new InputPrompt();
                prompt8.Completed += input_completed8;
                prompt8.Title = "Room Data";
                prompt8.Message = "Please enter the room data";
                prompt8.Show();
            }
        }

        private void input_completed8(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                string data = e.Result;
                WarpClient.GetInstance().SetCustomUserData(userName, data);
            }
        }

        private void input_completed5(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                roomId = e.Result;
                InputPrompt prompt6 = new InputPrompt();
                prompt6.Completed += input_completed6;
                prompt6.Title = "Room Data";
                prompt6.Message = "Please enter the room data";
                prompt6.Show();
            }
        }

        private void input_completed6(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                string data = e.Result;
                WarpClient.GetInstance().SetCustomRoomData(roomId,data);
            }
        }

        private void input_completed4(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                Dictionary<string, object> properties = new Dictionary<string, object>();
                properties.Add("check", "true");
                WarpClient.GetInstance().CreateTurnRoom(e.Result, App.USER_NAME, 2, properties, 10);
            }
        }

        private void input_completed3(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                Dictionary<string, object> properties = new Dictionary<string, object>();
                properties.Add("check", "true");
                //WarpClient.GetInstance().CreateRoom(e.Result, App.USER_NAME, 2, properties, 20);
                WarpClient.GetInstance().CreateRoom(e.Result, App.USER_NAME, 2, properties);
            }
        }

        private void input_completed2(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                int maxRecoveryTime = Convert.ToInt32(e.Result);
                WarpClient.setRecoveryAllowance(maxRecoveryTime);
            }
        }

        private void input_completed(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                sessionId = Convert.ToInt32(e.Result);
                InputPrompt prompt1 = new InputPrompt();
                prompt1.Completed += input_completed1;
                prompt1.Title = "User Name";
                prompt1.Message = "Please enter a user name";
                prompt1.Show();
            }
        }

        private void input_completed1(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.Result != null)
            {
                userName = e.Result;
                if (WarpClient.GetInstance() != null)
                {
                    WarpClient.GetInstance().RecoverConnectionWithSessioId(sessionId, userName);
                }
                else
                {
                    MessageBox.Show("Please click on Initialize before recover connection with session id.");
                }
            }
        }

        private void us_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void eu_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sp_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void jp_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        public void navigateToResponsePage()
        {
            NavigationService.Navigate(new Uri("/APIsPage.xaml", UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("Are you sure you want to exit the application?", "Exit", MessageBoxButton.OKCancel);
            if (m == MessageBoxResult.OK)
            {
                try
                {
                    e.Cancel = false;
                    Application.Current.Terminate();
                    //while (NavigationService.CanGoBack)
                    //    NavigationService.RemoveBackEntry();
                }
                catch (InvalidOperationException ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                }
            }
            else if (m == MessageBoxResult.Cancel)
            {
                e.Cancel = true; //Cancelling the default back option
            }
        }

    }



    public class APIs
    {
        public string APIName
        {
            get;
            set;
        }

        public APIs(string apiName)
        {
            this.APIName = apiName;
        }
    }
}