using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppWarp_WP8_SDK_Sample
{
    class ChatReqListener : ChatRequestListener
    {
        private MainPage mainPage;

        public ChatReqListener(MainPage mainPage)
        {
            // TODO: Complete member initialization
            this.mainPage = mainPage;
        }

        public ChatReqListener()
        {
            // TODO: Complete member initialization
        }

        public void onSendChatDone(byte result)
        {
            Global_data.populateResponseListFromResult("onSendChatDone", result);
        }

        public void onSendPrivateChatDone(byte result)
        {
            Global_data.populateResponseListFromResult("onSendPrivateChatDone", result);
        }
    }
}
