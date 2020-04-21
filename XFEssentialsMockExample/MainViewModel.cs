using Xamarin.Essentials;
using XFEssentialsMockExample.Services;

namespace XFEssentialsMockExample
{
    public class MainViewModel
    {
        readonly IConnectivityWrapper _connectivityWrapper;
        public bool Connected { get; private set; }

        public MainViewModel(IConnectivityWrapper connectivityWrapper)
        {
            _connectivityWrapper = connectivityWrapper;
            _connectivityWrapper.ConnectivityChanged += ConnectivityChanged;
        }

        void ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            Connected = e.NetworkAccess != NetworkAccess.None && e.NetworkAccess != NetworkAccess.Unknown;
        }
    }
}
