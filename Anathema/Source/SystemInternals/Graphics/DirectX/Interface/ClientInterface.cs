﻿using System;

namespace Anathema.Source.SystemInternals.Graphics.DirectXHook.Interface
{
    [Serializable]
    public delegate void MessageReceivedEvent(MessageReceivedEventArgs Message);
    [Serializable]
    public delegate void DisconnectedEvent();
    [Serializable]
    public delegate void DisplayTextEvent(DisplayTextEventArgs Args);

    [Serializable]
    public class ClientInterface : MarshalByRefObject
    {
        /// <summary>
        /// The client process Id
        /// </summary>
        public int ProcessId { get; set; }

        public ClientInterface()
        {

        }

        #region Server-side Events

        /// <summary>
        /// Server event for sending debug and error information from the client to server
        /// </summary>
        public event MessageReceivedEvent RemoteMessage;

        #endregion

        #region Client-side Events

        /// <summary>
        /// Client event used to notify the hook to exit
        /// </summary>
        public event DisconnectedEvent Disconnected;

        /// <summary>
        /// Client event used to display a piece of text in-game
        /// </summary>
        public event DisplayTextEvent DisplayText;

        #endregion

        /// <summary>
        /// Tell the client process to disconnect
        /// </summary>
        public void Disconnect()
        {
            SafeInvokeDisconnected();
        }

        /// <summary>
        /// Send a message to all handlers of <see cref="ClientInterface.RemoteMessage"/>.
        /// </summary>
        /// <param name="MessageType"></param>
        /// <param name="Format"></param>
        /// <param name="Args"></param>
        public void Message(MessageType MessageType, String Format, params Object[] Args)
        {
            Message(MessageType, String.Format(Format, Args));
        }

        public void Message(MessageType MessageType, String Message)
        {
            SafeInvokeMessageRecevied(new MessageReceivedEventArgs(MessageType, Message));
        }

        /// <summary>
        /// Display text in-game for the default duration of 5 seconds
        /// </summary>
        /// <param name="Text"></param>
        public void DisplayInGameText(String Text)
        {
            DisplayInGameText(Text, new TimeSpan(0, 0, 5));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="duration"></param>
        public void DisplayInGameText(String Text, TimeSpan Duration)
        {
            if (Duration.TotalMilliseconds <= 0)
                throw new ArgumentException("Duration must be larger than 0", "duration");

            SafeInvokeDisplayText(new DisplayTextEventArgs(Text, Duration));
        }

        #region Private: Invoke message handlers

        private void SafeInvokeMessageRecevied(MessageReceivedEventArgs EventArgs)
        {
            if (RemoteMessage == null)
                return;

            MessageReceivedEvent Listener = null;

            foreach (Delegate Delegate in RemoteMessage.GetInvocationList())
            {
                try
                {
                    Listener = (MessageReceivedEvent)Delegate;
                    Listener.Invoke(EventArgs);
                }
                catch
                {
                    //Could not reach the destination, so remove it
                    //from the list
                    RemoteMessage -= Listener;
                }
            }
        }

        private void SafeInvokeDisconnected()
        {
            if (Disconnected == null)
                return;

            DisconnectedEvent Listener = null;

            foreach (Delegate Delegate in Disconnected.GetInvocationList())
            {
                try
                {
                    Listener = (DisconnectedEvent)Delegate;
                    Listener.Invoke();
                }
                catch
                {
                    Disconnected -= Listener;
                }
            }
        }

        private void SafeInvokeDisplayText(DisplayTextEventArgs DisplayTextEventArgs)
        {
            if (DisplayText == null)
                return;

            DisplayTextEvent Listener = null;

            foreach (Delegate Delegate in DisplayText.GetInvocationList())
            {
                try
                {
                    Listener = (DisplayTextEvent)Delegate;
                    Listener.Invoke(DisplayTextEventArgs);
                }
                catch
                {
                    DisplayText -= Listener;
                }
            }
        }

        #endregion

        /// <summary>
        /// Empty method to ensure we can call the client without crashing
        /// </summary>
        public void Ping() { }

    } // End class


    /// <summary>
    /// Client event proxy for marshalling event handlers
    /// </summary>
    public class ClientCaptureInterfaceEventProxy : MarshalByRefObject
    {
        /// <summary>
        /// Client event used to notify the hook to exit
        /// </summary>
        public event DisconnectedEvent Disconnected;

        /// <summary>
        /// Client event used to display in-game text
        /// </summary>
        public event DisplayTextEvent DisplayText;

        public override Object InitializeLifetimeService()
        {
            //Returning null holds the object alive
            //until it is explicitly destroyed
            return null;
        }

        public void DisconnectedProxyHandler()
        {
            Disconnected?.Invoke();
        }

        public void DisplayTextProxyHandler(DisplayTextEventArgs Args)
        {
            DisplayText?.Invoke(Args);
        }

    } // End class

} // End namespace