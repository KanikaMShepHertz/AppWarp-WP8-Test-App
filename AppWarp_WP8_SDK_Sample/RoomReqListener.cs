using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;

namespace AppWarp_WP8_SDK_Sample
{
    class RoomReqListener : RoomRequestListener
    {
        private MainPage mainPage;

        public RoomReqListener(MainPage mainPage)
        {
            // TODO: Complete member initialization
            this.mainPage = mainPage;
        }

        public RoomReqListener()
        {
            // TODO: Complete member initialization
        }

        public void onSubscribeRoomDone(com.shephertz.app42.gaming.multiplayer.client.events.RoomEvent eventObj)
        {
            if (eventObj != null)
            {
                Global_data.populateResponseListFromResult("onSubscribeRoomDone", eventObj.getResult());
                if (eventObj.getData() != null)
                {
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                        {
                            if (eventObj.getData().getId() != null)
                            {
                                (App.Current as App).responseOC.Add("Room Id : " + eventObj.getData().getId());
                            }
                            if (eventObj.getData().getRoomOwner() != null)
                            {
                                (App.Current as App).responseOC.Add("Owner : " + eventObj.getData().getRoomOwner());
                            }
                            (App.Current as App).responseOC.Add("Max users : " + eventObj.getData().getMaxUsers().ToString());
                            if (eventObj.getData().getName() != null)
                            {
                                (App.Current as App).responseOC.Add("Room Name : " + eventObj.getData().getName());
                            }
                        });
                }
            }
        }

        public void onUnSubscribeRoomDone(com.shephertz.app42.gaming.multiplayer.client.events.RoomEvent eventObj)
        {
            if (eventObj != null)
            {
                Global_data.populateResponseListFromResult("onUnSubscribeRoomDone", eventObj.getResult());
                if (eventObj.getData() != null)
                {
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        if (eventObj.getData().getId() != null)
                        {
                            (App.Current as App).responseOC.Add("Room Id : " + eventObj.getData().getId());
                        }
                        if (eventObj.getData().getRoomOwner() != null)
                        {
                            (App.Current as App).responseOC.Add("Owner : " + eventObj.getData().getRoomOwner());
                        }
                        (App.Current as App).responseOC.Add("Max users : " + eventObj.getData().getMaxUsers().ToString());
                        if (eventObj.getData().getName() != null)
                        {
                            (App.Current as App).responseOC.Add("Room Name : " + eventObj.getData().getName());
                        }
                    });
                }
            }
        }

        public void onJoinRoomDone(com.shephertz.app42.gaming.multiplayer.client.events.RoomEvent eventObj)
        {
            if (eventObj != null)
            {
                Global_data.populateResponseListFromResult("onJoinRoomDone", eventObj.getResult());
                if (eventObj.getData() != null)
                {
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        if (eventObj.getData().getId() != null)
                        {
                            (App.Current as App).responseOC.Add("Room Id : " + eventObj.getData().getId());
                        }
                        if (eventObj.getData().getRoomOwner() != null)
                        {
                            (App.Current as App).responseOC.Add("Owner : " + eventObj.getData().getRoomOwner());
                        }
                        (App.Current as App).responseOC.Add("Max users : " + eventObj.getData().getMaxUsers().ToString());
                        if (eventObj.getData().getName() != null)
                        {
                            (App.Current as App).responseOC.Add("Room Name : " + eventObj.getData().getName());
                        }
                    });
                }
            }
        }

        public void onLeaveRoomDone(com.shephertz.app42.gaming.multiplayer.client.events.RoomEvent eventObj)
        {
            if (eventObj != null)
            {
                Global_data.populateResponseListFromResult("onLeaveRoomDone", eventObj.getResult());
                if (eventObj.getData() != null)
                {
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        if (eventObj.getData().getId() != null)
                        {
                            (App.Current as App).responseOC.Add("Room Id : " + eventObj.getData().getId());
                        }
                        if (eventObj.getData().getRoomOwner() != null)
                        {
                            (App.Current as App).responseOC.Add("Owner : " + eventObj.getData().getRoomOwner());
                        }
                        (App.Current as App).responseOC.Add("Max users : " + eventObj.getData().getMaxUsers().ToString());
                        if (eventObj.getData().getName() != null)
                        {
                            (App.Current as App).responseOC.Add("Room Name : " + eventObj.getData().getName());
                        }
                    });
                }
            }
        }

        public void onGetLiveRoomInfoDone(com.shephertz.app42.gaming.multiplayer.client.events.LiveRoomInfoEvent eventObj)
        {
            try
            {
                if (eventObj != null)
                {
                    Global_data.populateResponseListFromResult("onGetLiveRoomInfoDone", eventObj.getResult());
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        if (eventObj.getJoinedUsers() != null)
                        {
                            (App.Current as App).responseOC.Add("JoinedUsers :");
                            for (int i = 0; i < eventObj.getJoinedUsers().Count(); i++)
                            {
                                (App.Current as App).responseOC.Add(eventObj.getJoinedUsers()[i]);
                            }
                        }

                        if (eventObj.getCustomData() != null)
                        {
                            (App.Current as App).responseOC.Add("CustomData : " + eventObj.getCustomData());
                        }

                        if (eventObj.getProperties() != null)
                        {
                            (App.Current as App).responseOC.Add("Properties :");
                            for (int k = 0; k < eventObj.getProperties().Count(); k++)
                            {
                                (App.Current as App).responseOC.Add(eventObj.getProperties().ElementAt(k).Key + " " + eventObj.getProperties().ElementAt(k).Value.ToString());
                            }
                        }

                        if (eventObj.getLockedProperties() != null)
                        {
                            (App.Current as App).responseOC.Add("LockedProperties :");
                            for (int l = 0; l < eventObj.getLockedProperties().Count(); l++)
                            {
                                (App.Current as App).responseOC.Add(eventObj.getLockedProperties().ElementAt(l).Key + " " + eventObj.getLockedProperties().ElementAt(l).Value.ToString());
                            }
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        public void onSetCustomRoomDataDone(com.shephertz.app42.gaming.multiplayer.client.events.LiveRoomInfoEvent eventObj)
        {
            if (eventObj != null)
            {
                try
                {
                    Global_data.populateResponseListFromResult("onSetCustomRoomDataDone", eventObj.getResult());
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        if (eventObj.getJoinedUsers() != null)
                        {
                            (App.Current as App).responseOC.Add("JoinedUsers :");
                            for (int i = 0; i < eventObj.getJoinedUsers().Count(); i++)
                            {
                                (App.Current as App).responseOC.Add(eventObj.getJoinedUsers()[i]);
                            }
                        }

                        if (eventObj.getCustomData() != null)
                        {
                            (App.Current as App).responseOC.Add("CustomData : " + eventObj.getCustomData());
                        }

                        if (eventObj.getProperties() != null)
                        {
                            (App.Current as App).responseOC.Add("Properties :");
                            for (int k = 0; k < eventObj.getProperties().Count(); k++)
                            {
                                (App.Current as App).responseOC.Add(eventObj.getProperties().ElementAt(k).Key + " " + eventObj.getProperties().ElementAt(k).Value.ToString());
                            }
                        }

                        if (eventObj.getLockedProperties() != null)
                        {
                            (App.Current as App).responseOC.Add("LockedProperties :");
                            for (int l = 0; l < eventObj.getLockedProperties().Count(); l++)
                            {
                                (App.Current as App).responseOC.Add(eventObj.getLockedProperties().ElementAt(l).Key + " " + eventObj.getLockedProperties().ElementAt(l).Value.ToString());
                            }
                        }
                    });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
        }

        public void onUpdatePropertyDone(com.shephertz.app42.gaming.multiplayer.client.events.LiveRoomInfoEvent lifeLiveRoomInfoEvent)
        {
            if (lifeLiveRoomInfoEvent != null)
            {
                try
                {
                    Global_data.populateResponseListFromResult("onUpdatePropertyDone", lifeLiveRoomInfoEvent.getResult());
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        if (lifeLiveRoomInfoEvent.getJoinedUsers() != null)
                        {
                            (App.Current as App).responseOC.Add("JoinedUsers :");
                            for (int i = 0; i < lifeLiveRoomInfoEvent.getJoinedUsers().Count(); i++)
                            {
                                (App.Current as App).responseOC.Add(lifeLiveRoomInfoEvent.getJoinedUsers()[i]);
                            }
                        }

                        if (lifeLiveRoomInfoEvent.getCustomData() != null)
                        {
                            (App.Current as App).responseOC.Add("CustomData : " + lifeLiveRoomInfoEvent.getCustomData());
                        }

                        if (lifeLiveRoomInfoEvent.getProperties() != null)
                        {
                            (App.Current as App).responseOC.Add("Properties :");
                            for (int k = 0; k < lifeLiveRoomInfoEvent.getProperties().Count(); k++)
                            {
                                (App.Current as App).responseOC.Add(lifeLiveRoomInfoEvent.getProperties().ElementAt(k).Key + " " + lifeLiveRoomInfoEvent.getProperties().ElementAt(k).Value.ToString());
                            }
                        }

                        if (lifeLiveRoomInfoEvent.getLockedProperties() != null)
                        {
                            (App.Current as App).responseOC.Add("LockedProperties :");
                            for (int l = 0; l < lifeLiveRoomInfoEvent.getLockedProperties().Count(); l++)
                            {
                                (App.Current as App).responseOC.Add(lifeLiveRoomInfoEvent.getLockedProperties().ElementAt(l).Key + " " + lifeLiveRoomInfoEvent.getLockedProperties().ElementAt(l).Value.ToString());
                            }
                        }
                    });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
        }

        public void onLockPropertiesDone(byte result)
        {
            Global_data.populateResponseListFromResult("onLockPropertiesDone", result);
        }

        public void onUnlockPropertiesDone(byte result)
        {
            Global_data.populateResponseListFromResult("onUnlockPropertiesDone", result);
        }
    }
}
