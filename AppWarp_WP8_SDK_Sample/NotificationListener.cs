using com.shephertz.app42.gaming.multiplayer.client.events;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace AppWarp_WP8_SDK_Sample
{
    class NotificationListener : NotifyListener
    {
        private MainPage mainPage;

        public NotificationListener(MainPage mainPage)
        {
            // TODO: Complete member initialization
            this.mainPage = mainPage;
        }

        public NotificationListener()
        {
            // TODO: Complete member initialization
        }

        public void onRoomCreated(RoomData eventObj)
        {
            Global_data.populateNotificationsListFromCallback("onRoomCreated");
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (eventObj != null)
                (App.Current as App).notificationOC.Add("Room " + eventObj.getId() + " with name " + eventObj.getName() + " was created.");

                //if (eventObj.getId() != null)
                //{
                //    (App.Current as App).notificationOC.Add("Room Id : " + eventObj.getId());
                //}
                //if (eventObj.getRoomOwner() != null)
                //{
                //    (App.Current as App).notificationOC.Add("Owner : " + eventObj.getRoomOwner());
                //}
                //(App.Current as App).notificationOC.Add("Max users : " + eventObj.getMaxUsers().ToString());
                //if (eventObj.getName() != null)
                //{
                //    (App.Current as App).notificationOC.Add("Room Name : " + eventObj.getName());
                //}
            });
        }

        public void onRoomDestroyed(RoomData eventObj)
        {
            Global_data.populateNotificationsListFromCallback("onRoomDestroyed");
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (eventObj != null)
                (App.Current as App).notificationOC.Add("Room " + eventObj.getId() + " with name " + eventObj.getName() + " was destroyed.");
                //if (eventObj.getId() != null)
                //{
                //    (App.Current as App).notificationOC.Add("Room Id : " + eventObj.getId());
                //}
                //if (eventObj.getRoomOwner() != null)
                //{
                //    (App.Current as App).notificationOC.Add("Owner : " + eventObj.getRoomOwner());
                //}
                //(App.Current as App).notificationOC.Add("Max users : " + eventObj.getMaxUsers().ToString());
                //if (eventObj.getName() != null)
                //{
                //    (App.Current as App).notificationOC.Add("Room Name : " + eventObj.getName());
                //}
            });
        }

        public void onUserLeftRoom(RoomData eventObj, string username)
        {
            Global_data.populateNotificationsListFromCallback("onUserLeftRoom");
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                (App.Current as App).notificationOC.Add("user " + username + " left room.");

                //if (eventObj.getId() != null)
                //{
                //    (App.Current as App).notificationOC.Add("Room Id : " + eventObj.getId());
                //}
                //if (eventObj.getRoomOwner() != null)
                //{
                //    (App.Current as App).notificationOC.Add("Owner : " + eventObj.getRoomOwner());
                //}
                //(App.Current as App).notificationOC.Add("Max users : " + eventObj.getMaxUsers().ToString());
                //if (eventObj.getName() != null)
                //{
                //    (App.Current as App).notificationOC.Add("Room Name : " + eventObj.getName());
                //}
                //if (username != null)
                //{
                //    (App.Current as App).notificationOC.Add("user Name : " + username);
                //}
            });
        }

        public void onUserJoinedRoom(com.shephertz.app42.gaming.multiplayer.client.events.RoomData eventObj, string username)
        {
            Global_data.populateNotificationsListFromCallback("onUserJoinedRoom");
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                (App.Current as App).notificationOC.Add("user " + username + " joined room.");

                //if (eventObj.getId() != null)
                //{
                //    (App.Current as App).responseOC.Add("Room Id : " + eventObj.getId());
                //}
                //if (eventObj.getRoomOwner() != null)
                //{
                //    (App.Current as App).responseOC.Add("Owner : " + eventObj.getRoomOwner());
                //}
                //(App.Current as App).responseOC.Add("Max users : " + eventObj.getMaxUsers().ToString());
                //if (eventObj.getName() != null)
                //{
                //    (App.Current as App).responseOC.Add("Room Name : " + eventObj.getName());
                //}
                //if (username != null)
                //{
                //    (App.Current as App).responseOC.Add("user Name : " + username);
                //}
            });
        }

        public void onUserLeftLobby(com.shephertz.app42.gaming.multiplayer.client.events.LobbyData eventObj, string username)
        {
            Global_data.populateNotificationsListFromCallback("onUserLeftLobby");
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                (App.Current as App).notificationOC.Add("user " + username + " left Lobby.");

                //if (eventObj.getId() != null)
                //{
                //    (App.Current as App).responseOC.Add("Room Id : " + eventObj.getId());
                //}
                //if (eventObj.getRoomOwner() != null)
                //{
                //    (App.Current as App).responseOC.Add("Owner : " + eventObj.getRoomOwner());
                //}
                //(App.Current as App).responseOC.Add("Max users : " + eventObj.getMaxUsers().ToString());
                //if (eventObj.getName() != null)
                //{
                //    (App.Current as App).responseOC.Add("Room Name : " + eventObj.getName());
                //}
                //    (App.Current as App).responseOC.Add("isPrimary : " + eventObj.isPrimary().ToString());
                //if (username != null)
                //{
                //    (App.Current as App).responseOC.Add("user Name : " + username);
                //}
            });
        }

        public void onUserJoinedLobby(com.shephertz.app42.gaming.multiplayer.client.events.LobbyData eventObj, string username)
        {
            Global_data.populateNotificationsListFromCallback("onUserJoinedLobby");
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                (App.Current as App).notificationOC.Add("user " + username + " joined Lobby.");

                //if (eventObj.getId() != null)
                //{
                //    (App.Current as App).responseOC.Add("Room Id : " + eventObj.getId());
                //}
                //if (eventObj.getRoomOwner() != null)
                //{
                //    (App.Current as App).responseOC.Add("Owner : " + eventObj.getRoomOwner());
                //}
                //(App.Current as App).responseOC.Add("Max users : " + eventObj.getMaxUsers().ToString());
                //if (eventObj.getName() != null)
                //{
                //    (App.Current as App).responseOC.Add("Room Name : " + eventObj.getName());
                //}
                //(App.Current as App).responseOC.Add("isPrimary : " + eventObj.isPrimary().ToString());
                //if (username != null)
                //{
                //    (App.Current as App).responseOC.Add("user Name : " + username);
                //}
            });
        }

        public void onChatReceived(com.shephertz.app42.gaming.multiplayer.client.events.ChatEvent eventObj)
        {
            Global_data.populateNotificationsListFromCallback("onChatReceived");
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (eventObj != null)
                    (App.Current as App).notificationOC.Add(eventObj.getSender() + " says " + eventObj.getMessage());

                //if (eventObj.getSender() != null)
                //{
                //    (App.Current as App).responseOC.Add("Sender : " + eventObj.getSender());
                //}
                //if (eventObj.getMessage() != null)
                //{
                //    (App.Current as App).responseOC.Add("Message : " + eventObj.getMessage());
                //}
                //if (eventObj.getLocationId() != null)
                //{
                //    (App.Current as App).responseOC.Add("Location Id : " + eventObj.getLocationId());
                //}
                //(App.Current as App).responseOC.Add("isLocatioLobby : " + eventObj.isLocationLobby().ToString());
            });
        }

        public void onUpdatePeersReceived(com.shephertz.app42.gaming.multiplayer.client.events.UpdateEvent eventObj)
        {
            Global_data.populateNotificationsListFromCallback("onUpdatePeersReceived");
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (eventObj.getUpdate() != null)
                {
                    (App.Current as App).notificationOC.Add("Update sent : " + eventObj.getUpdate().ToString());
                }
                //(App.Current as App).notificationOC.Add("Is Udp : " + eventObj.getIsUdp().ToString());
            });
        }

        public void onUserChangeRoomProperty(com.shephertz.app42.gaming.multiplayer.client.events.RoomData roomData, string sender, Dictionary<string, object> properties, Dictionary<string, string> lockedPropertiesTable)
        {
            Global_data.populateNotificationsListFromCallback("onUserChangeRoomProperty");
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (properties != null)
                {
                    for (int i = 0; i < properties.Count(); i++)
                    {
                        (App.Current as App).notificationOC.Add(sender + " changed " + properties.ElementAt(i).Key + ":" + properties.ElementAt(i).Value + " property.");
                    }
                }
            });
        }

        public void onPrivateChatReceived(string sender, string message)
        {
            Global_data.populateNotificationsListFromCallback("onPrivateChatReceived");
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (sender != null && message != null)
                {
                    (App.Current as App).notificationOC.Add(sender + " says " + message);
                }
            });
        }

        public void onMoveCompleted(com.shephertz.app42.gaming.multiplayer.client.events.MoveEvent moveEvent)
        {
            Global_data.populateNotificationsListFromCallback("onMoveCompleted");
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (moveEvent != null)
                {
                    (App.Current as App).notificationOC.Add(moveEvent.getSender() + " sent move to" + moveEvent.getNextTurn());
                }
            });
        }

        public void onUserPaused(string locid, bool isLobby, string username)
        {
            Global_data.populateNotificationsListFromCallback("onUserPaused");
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (username != null)
                {
                    (App.Current as App).notificationOC.Add(username+" paused");
                }
            });
        }

        public void onUserResumed(string locid, bool isLobby, string username)
        {
            Global_data.populateNotificationsListFromCallback("onUserResumed");
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (username != null)
                {
                    (App.Current as App).notificationOC.Add(username + " is back");
                }
            });
        }

        public void onGameStarted(string sender, string roomId, string nextTurn)
        {
            Global_data.populateNotificationsListFromCallback("onGameStarted");
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (sender != null)
                {
                    (App.Current as App).notificationOC.Add(sender + " started the game.");
                }
            });
        }

        public void onGameStopped(string sender, string roomId)
        {
            Global_data.populateNotificationsListFromCallback("onGameStopped");
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (sender != null)
                {
                    (App.Current as App).notificationOC.Add(sender + " stopped the game.");
                }
            });
        }

        public void onPrivateUpdateReceived(string sender, byte[] update, bool fromUdp)
        {
            Global_data.populateNotificationsListFromCallback("onPrivateUpdateReceived");
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (sender != null)
                {
                    (App.Current as App).notificationOC.Add(sender + " sent the update " + update.ToString());
                }
            });
        }

        public void onNextTurnRequest(string lastTurn)
        {
            Global_data.populateNotificationsListFromCallback("onNextTurnRequest");
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (lastTurn != null)
                {
                    (App.Current as App).notificationOC.Add(lastTurn + " requested for the next turn");
                }
            });
        }
    }
}
