using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppWarp_WP8_SDK_Sample
{
    class LobbyReqListener : LobbyRequestListener
    {
        private MainPage mainPage;

        public LobbyReqListener(MainPage mainPage)
        {
            // TODO: Complete member initialization
            this.mainPage = mainPage;
        }

        public LobbyReqListener()
        {
            // TODO: Complete member initialization
        }
        public void onJoinLobbyDone(com.shephertz.app42.gaming.multiplayer.client.events.LobbyEvent eventObj)
        {
            Global_data.populateResponseListFromResult("onJoinLobbyDone", eventObj.getResult());
        }

        public void onLeaveLobbyDone(com.shephertz.app42.gaming.multiplayer.client.events.LobbyEvent eventObj)
        {
            Global_data.populateResponseListFromResult("onLeaveLobbyDone", eventObj.getResult());
        }

        public void onSubscribeLobbyDone(com.shephertz.app42.gaming.multiplayer.client.events.LobbyEvent eventObj)
        {
            Global_data.populateResponseListFromResult("onSubscribeLobbyDone", eventObj.getResult());
        }

        public void onUnSubscribeLobbyDone(com.shephertz.app42.gaming.multiplayer.client.events.LobbyEvent eventObj)
        {
            Global_data.populateResponseListFromResult("onUnSubscribeLobbyDone", eventObj.getResult());
        }

        public void onGetLiveLobbyInfoDone(com.shephertz.app42.gaming.multiplayer.client.events.LiveRoomInfoEvent eventObj)
        {
            Global_data.populateResponseListFromResult("onGetLiveLobbyInfoDone", eventObj.getResult());
        }
    }
}
