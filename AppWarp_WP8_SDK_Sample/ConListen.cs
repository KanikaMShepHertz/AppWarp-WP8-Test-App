using com.shephertz.app42.gaming.multiplayer.client;
using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AppWarp_WP8_SDK_Sample
{
    class ConListen : ConnectionRequestListener
    {
        private MainPage mainPage;

        public ConListen(MainPage mainPage)
        {
            // TODO: Complete member initialization
            this.mainPage = mainPage;
        }

        public ConListen()
        {
            // TODO: Complete member initialization
        }

        public void onConnectDone(com.shephertz.app42.gaming.multiplayer.client.events.ConnectEvent eventObj)
        {
            Global_data.populateResponseListFromCallback("onConnectDone");
        }

        public void onDisconnectDone(com.shephertz.app42.gaming.multiplayer.client.events.ConnectEvent eventObj)
        {
            Global_data.populateResponseListFromCallback("onDisconnectDone");
        }

        public void onInitUDPDone(byte resultCode)
        {
            //if (resultCode == WarpResponseResultCode.SUCCESS)
            //{
                //Global_data.populateResponseListFromCallback("onInitUDPDone called" + Environment.NewLine + "WarpResponseResultCode : SUCCESS");
            //}
            //else
            //{
            //    Global_data.populateResponseListFromCallback("onInitUDPDone called : Failed");
            //}
            Global_data.populateResponseListFromResult("onInitUDPDone", resultCode);
        }
    }
}
