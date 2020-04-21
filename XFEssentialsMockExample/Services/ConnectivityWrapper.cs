using System;
using Xamarin.Essentials;

namespace XFEssentialsMockExample.Services
{
    public interface IConnectivityWrapper
    {
        bool IsConnectedToInternet();
        event EventHandler<ConnectivityChangedEventArgs> ConnectivityChanged;
    }

    public class ConnectivityWrapper : IConnectivityWrapper
    {
        event EventHandler<ConnectivityChangedEventArgs> IConnectivityWrapper.ConnectivityChanged
        {
            add => Connectivity.ConnectivityChanged += value;
            remove => Connectivity.ConnectivityChanged -= value;
        }

        public bool IsConnectedToInternet() => Connectivity.NetworkAccess == NetworkAccess.Internet;
    }
}
