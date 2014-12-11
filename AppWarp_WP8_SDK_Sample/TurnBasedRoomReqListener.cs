using com.shephertz.app42.gaming.multiplayer.client.listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppWarp_WP8_SDK_Sample
{
    class TurnBasedRoomReqListener : TurnBasedRoomListener
    {
        private MainPage mainPage;

        public TurnBasedRoomReqListener(MainPage mainPage)
        {
            // TODO: Complete member initialization
            this.mainPage = mainPage;
        }

        public TurnBasedRoomReqListener()
        {
            // TODO: Complete member initialization
        }
        public void onSendMoveDone(byte result)
        {
            Global_data.populateResponseListFromResult("onSendMoveDone", result);
        }

        public void onStartGameDone(byte result)
        {
            Global_data.populateResponseListFromResult("onStartGameDone", result);
        }

        public void onStopGameDone(byte result)
        {
            Global_data.populateResponseListFromResult("onStopGameDone", result);
        }

        public void onSetNextTurnDone(byte result)
        {
            Global_data.populateResponseListFromResult("onSetNextTurnDone", result);
        }

        public void onGetMoveHistoryDone(byte result, com.shephertz.app42.gaming.multiplayer.client.events.MoveEvent[] moves)
        {
            Global_data.populateResponseListFromResult("onGetMoveHistoryDone", result);
        }
    }
}
