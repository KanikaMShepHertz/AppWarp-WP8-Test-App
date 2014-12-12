using com.shephertz.app42.gaming.multiplayer.client;
using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client.events;
using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AppWarp_WP8_SDK_Sample
{
    public static class Global_data
    {

        //public static void InsertInNotificationsList(string callbackReceived)
        //{
        //    Deployment.Current.Dispatcher.BeginInvoke(() =>
        //       {
        //           (App.Current as App).notificationOC.Add(callbackReceived);
        //           //(App.Current as App).notificationOC.Add("ConnectionState : " + WarpClient.GetInstance().GetConnectionState().ToString());
        //       });
        //}

        public static void populateNotificationsListFromCallback(string callback)
        {
            string response = "";
            try
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    //Update the UI controls here
                    if (WarpClient.GetInstance().GetConnectionState() == 0)
                    {
                        response = callback + " called : CONNECTED";
                        (App.Current as App).notificationOC.Add(response);
                    }
                    else if (WarpClient.GetInstance().GetConnectionState() == 1)
                    {
                        response = callback + " called : CONNECTING";
                        (App.Current as App).notificationOC.Add(response);
                    }
                    else if (WarpClient.GetInstance().GetConnectionState() == 2)
                    {
                        response = callback + " called : DISCONNECTED";
                        (App.Current as App).notificationOC.Add(response);
                    }
                    else if (WarpClient.GetInstance().GetConnectionState() == 3)
                    {
                        response = callback + " called : DISCONNECTING";
                        (App.Current as App).notificationOC.Add(response);
                    }
                    else if (WarpClient.GetInstance().GetConnectionState() == 4)
                    {
                        response = callback + " called : RECOVERING";
                        (App.Current as App).notificationOC.Add(response);
                    }
                    else
                    {
                        response = callback;
                        (App.Current as App).notificationOC.Add(response);
                    }
                    navigationToNotification_class objnavigation_class = new navigationToNotification_class();
                    objnavigation_class.navigateToNotificationepage();
                });

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        public static void populateNotificationListFromResult(string callback, byte result)
        {
            string response = "";
            try
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    //Update the UI controls here
                    if (result == WarpResponseResultCode.AUTH_ERROR)
                    {
                        //response = callback + " called" + Environment.NewLine + "WarpResponseResultCode : AUTH_ERROR";
                        response = callback + " called : AUTH_ERROR";
                        (App.Current as App).notificationOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.BAD_REQUEST)
                    {
                        response = callback + " called : BAD_REQUEST";
                        (App.Current as App).notificationOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.CONNECTION_ERR)
                    {
                        response = callback + " called : CONNECTION_ERR";
                        (App.Current as App).notificationOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.CONNECTION_ERROR_RECOVERABLE)
                    {
                        response = callback + " called : CONNECTION_ERROR_RECOVERABLE";
                        (App.Current as App).notificationOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.RESOURCE_MOVED)
                    {
                        response = callback + " called : RESOURCE_MOVED";
                        (App.Current as App).notificationOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.RESOURCE_NOT_FOUND)
                    {
                        response = callback + " called : RESOURCE_NOT_FOUND";
                        (App.Current as App).notificationOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.RESULT_SIZE_ERROR)
                    {
                        response = callback + " called : RESULT_SIZE_ERROR";
                        (App.Current as App).notificationOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.SUCCESS)
                    {
                        response = callback + " called : SUCCESS";
                        (App.Current as App).notificationOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.SUCCESS_RECOVERED)
                    {
                        response = callback + " called : SUCCESS_RECOVERED";
                        (App.Current as App).notificationOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.UNKNOWN_ERROR)
                    {
                        response = callback + " called : UNKNOWN_ERROR";
                        (App.Current as App).notificationOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.USER_PAUSED_ERROR)
                    {
                        response = callback + " called : USER_PAUSED_ERROR";
                        (App.Current as App).notificationOC.Add(response);
                    }
                    else
                    {
                        response = callback;
                        (App.Current as App).notificationOC.Add(response);
                    }
                    navigationToNotification_class objnavigation_class = new navigationToNotification_class();
                    objnavigation_class.navigateToNotificationepage();
                });

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        //public static void populateResponseListFromObject(string callback,RoomEvent eventObj)
        //{
        //    string response = "";
        //    try
        //    {
        //        Deployment.Current.Dispatcher.BeginInvoke(() =>
        //        {
        //            //Update the UI controls here
        //            if (eventObj != null)
        //            {
        //                if (eventObj.getResult() == WarpResponseResultCode.AUTH_ERROR)
        //                {
        //                    response = callback + " called" + Environment.NewLine + "WarpResponseResultCode : AUTH_ERROR";
        //                    (App.Current as App).responseOC.Add(response);
        //                }
        //                else if (eventObj.getResult() == WarpResponseResultCode.BAD_REQUEST)
        //                {
        //                    response = callback + " called" + Environment.NewLine + "WarpResponseResultCode : BAD_REQUEST";
        //                    (App.Current as App).responseOC.Add(response);
        //                }
        //                else if (eventObj.getResult() == WarpResponseResultCode.CONNECTION_ERR)
        //                {
        //                    response = callback + " called" + Environment.NewLine + "WarpResponseResultCode : CONNECTION_ERR";
        //                    (App.Current as App).responseOC.Add(response);
        //                }
        //                else if (eventObj.getResult() == WarpResponseResultCode.CONNECTION_ERROR_RECOVERABLE)
        //                {
        //                    response = callback + " called" + Environment.NewLine + "WarpResponseResultCode : CONNECTION_ERROR_RECOVERABLE";
        //                    (App.Current as App).responseOC.Add(response);
        //                }
        //                else if (eventObj.getResult() == WarpResponseResultCode.RESOURCE_MOVED)
        //                {
        //                    response = callback + " called" + Environment.NewLine + "WarpResponseResultCode : RESOURCE_MOVED";
        //                    (App.Current as App).responseOC.Add(response);
        //                }
        //                else if (eventObj.getResult() == WarpResponseResultCode.RESOURCE_NOT_FOUND)
        //                {
        //                    response = callback + " called" + Environment.NewLine + "WarpResponseResultCode : RESOURCE_NOT_FOUND";
        //                    (App.Current as App).responseOC.Add(response);
        //                }
        //                else if (eventObj.getResult() == WarpResponseResultCode.RESULT_SIZE_ERROR)
        //                {
        //                    response = callback + " called" + Environment.NewLine + "WarpResponseResultCode : RESULT_SIZE_ERROR";
        //                    (App.Current as App).responseOC.Add(response);
        //                }
        //                else if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
        //                {
        //                    response = callback + " called" + Environment.NewLine + "WarpResponseResultCode : SUCCESS";
        //                    (App.Current as App).responseOC.Add(response);
        //                }
        //                else if (eventObj.getResult() == WarpResponseResultCode.SUCCESS_RECOVERED)
        //                {
        //                    response = callback + " called" + Environment.NewLine + "WarpResponseResultCode : SUCCESS_RECOVERED";
        //                    (App.Current as App).responseOC.Add(response);
        //                }
        //                else if (eventObj.getResult() == WarpResponseResultCode.UNKNOWN_ERROR)
        //                {
        //                    response = callback + " called" + Environment.NewLine + "WarpResponseResultCode : UNKNOWN_ERROR";
        //                    (App.Current as App).responseOC.Add(response);
        //                }
        //                else if (eventObj.getResult() == WarpResponseResultCode.USER_PAUSED_ERROR)
        //                {
        //                    response = callback + " called" + Environment.NewLine + "WarpResponseResultCode : USER_PAUSED_ERROR";
        //                    (App.Current as App).responseOC.Add(response);
        //                }
        //                else
        //                {
        //                    response = callback;
        //                    (App.Current as App).responseOC.Add(response);
        //                }
        //            }
        //            else
        //            {
        //                response = callback;
        //                (App.Current as App).responseOC.Add(response);
        //            }
        //        });

        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.StackTrace);
        //    }
        //}

        public static void populateResponseListFromCallback(string callback)
        {
            string response = "";
            try
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    //Update the UI controls here
                    if (WarpClient.GetInstance().GetConnectionState() == 0)
                    {
                        //response = callback + " called" + Environment.NewLine + "ConnectionState : CONNECTED";
                        response = callback + " called : CONNECTED";
                        (App.Current as App).responseOC.Add(response);
                    }
                    else if (WarpClient.GetInstance().GetConnectionState() == 1)
                    {
                        response = callback + " called : CONNECTING";
                        (App.Current as App).responseOC.Add(response);
                    }
                    else if (WarpClient.GetInstance().GetConnectionState() == 2)
                    {
                        response = callback + " called : DISCONNECTED";
                        (App.Current as App).responseOC.Add(response);
                    }
                    else if (WarpClient.GetInstance().GetConnectionState() == 3)
                    {
                        response = callback + " called : DISCONNECTING";
                        (App.Current as App).responseOC.Add(response);
                    }
                    else if (WarpClient.GetInstance().GetConnectionState() == 4)
                    {
                        response = callback + " called : RECOVERING";
                        (App.Current as App).responseOC.Add(response);
                    }
                    else
                    {
                        response = callback;
                        (App.Current as App).responseOC.Add(response);
                    }
                    navigateToResponse_class objnavigation_class = new navigateToResponse_class();
                    objnavigation_class.navigateToResponsepage();
                });

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        public static void populateResponseListFromResult(string callback, byte result)
        {
            string response = "";
            try
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    //Update the UI controls here
                    if (result == WarpResponseResultCode.AUTH_ERROR)
                    {
                        //response = callback + " called" + Environment.NewLine + "WarpResponseResultCode : AUTH_ERROR";
                        response = callback + " called : AUTH_ERROR";
                        (App.Current as App).responseOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.BAD_REQUEST)
                    {
                        response = callback + " called : BAD_REQUEST";
                        (App.Current as App).responseOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.CONNECTION_ERR)
                    {
                        response = callback + " called : CONNECTION_ERR";
                        (App.Current as App).responseOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.CONNECTION_ERROR_RECOVERABLE)
                    {
                        response = callback + " called : CONNECTION_ERROR_RECOVERABLE";
                        (App.Current as App).responseOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.RESOURCE_MOVED)
                    {
                        response = callback + " called : RESOURCE_MOVED";
                        (App.Current as App).responseOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.RESOURCE_NOT_FOUND)
                    {
                        response = callback + " called : RESOURCE_NOT_FOUND";
                        (App.Current as App).responseOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.RESULT_SIZE_ERROR)
                    {
                        response = callback + " called : RESULT_SIZE_ERROR";
                        (App.Current as App).responseOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.SUCCESS)
                    {
                        response = callback + " called : SUCCESS";
                        (App.Current as App).responseOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.SUCCESS_RECOVERED)
                    {
                        response = callback + " called : SUCCESS_RECOVERED";
                        (App.Current as App).responseOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.UNKNOWN_ERROR)
                    {
                        response = callback + " called : UNKNOWN_ERROR";
                        (App.Current as App).responseOC.Add(response);
                    }
                    else if (result == WarpResponseResultCode.USER_PAUSED_ERROR)
                    {
                        response = callback + " called : USER_PAUSED_ERROR";
                        (App.Current as App).responseOC.Add(response);
                    }
                    else
                    {
                        response = callback;
                        (App.Current as App).responseOC.Add(response);
                    }
                    navigateToResponse_class objnavigation_class = new navigateToResponse_class();
                    objnavigation_class.navigateToResponsepage();
                });

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }

    public class navigateToResponse_class
    {
        public void navigateToResponsepage()
        {
            Deployment.Current.Dispatcher.BeginInvoke(delegate
            {
                System.Uri uri = (new Uri("/ResponsesPage.xaml", UriKind.RelativeOrAbsolute));
                (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(uri);

                //NavigationService.Navigate(new Uri("/ResponsesPage.xaml", UriKind.Relative));
            });
        }
    }

    public class navigationToNotification_class
    {
        public void navigateToNotificationepage()
        {
            Deployment.Current.Dispatcher.BeginInvoke(delegate
            {
                System.Uri uri = (new Uri("/NotificationsPage.xaml", UriKind.RelativeOrAbsolute));
                (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(uri);

                //NavigationService.Navigate(new Uri("/NotificationsPage.xaml", UriKind.Relative));
            });
        }
    }
}
