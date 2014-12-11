using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppWarp_WP8_SDK_Sample
{
    class ZoneReqListener : ZoneRequestListener
    {
        private MainPage mainPage;

        public ZoneReqListener(MainPage mainPage)
        {
            // TODO: Complete member initialization
            this.mainPage = mainPage;
        }

        public ZoneReqListener()
        {
            // TODO: Complete member initialization
        }

        public void onDeleteRoomDone(com.shephertz.app42.gaming.multiplayer.client.events.RoomEvent eventObj)
        {
            Global_data.populateResponseListFromResult("onDeleteRoomDone", eventObj.getResult());
        }

        public void onGetAllRoomsDone(com.shephertz.app42.gaming.multiplayer.client.events.AllRoomsEvent eventObj)
        {
            Global_data.populateResponseListFromResult("onGetAllRoomsDone", eventObj.getResult());
        }

        public void onCreateRoomDone(com.shephertz.app42.gaming.multiplayer.client.events.RoomEvent eventObj)
        {
            Global_data.populateResponseListFromResult("onCreateRoomDone", eventObj.getResult());
        }

        public void onGetOnlineUsersDone(com.shephertz.app42.gaming.multiplayer.client.events.AllUsersEvent eventObj)
        {
            Global_data.populateResponseListFromResult("onGetOnlineUsersDone", eventObj.getResult());
        }

        public void onGetLiveUserInfoDone(com.shephertz.app42.gaming.multiplayer.client.events.LiveUserInfoEvent eventObj)
        {
            Global_data.populateResponseListFromResult("onGetLiveUserInfoDone", eventObj.getResult());
        }

        public void onSetCustomUserDataDone(com.shephertz.app42.gaming.multiplayer.client.events.LiveUserInfoEvent eventObj)
        {
            Global_data.populateResponseListFromResult("onSetCustomUserDataDone", eventObj.getResult());
        }

        public void onGetMatchedRoomsDone(com.shephertz.app42.gaming.multiplayer.client.events.MatchedRoomsEvent matchedRoomsEvent)
        {
            Global_data.populateResponseListFromResult("onGetMatchedRoomsDone", matchedRoomsEvent.getResult());
        }
    }
}
