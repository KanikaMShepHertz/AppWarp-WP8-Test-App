using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppWarp_WP8_SDK_Sample
{
    class UpdateReqListener : UpdateRequestListener
    {
        private MainPage mainPage;

        public UpdateReqListener(MainPage mainPage)
        {
            // TODO: Complete member initialization
            this.mainPage = mainPage;
        }

        public UpdateReqListener()
        {
            // TODO: Complete member initialization
        }
        public void onSendUpdateDone(byte result)
        {
            Global_data.populateResponseListFromResult("onSendUpdateDone", result);

        }

        public void onSendPrivateUpdateDone(byte result)
        {
            Global_data.populateResponseListFromResult("onSendPrivateUpdateDone", result);
        }
    }
}
