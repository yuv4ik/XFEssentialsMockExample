using Moq;
using XFEssentialsMockExample.Services;
using Xunit;
using Xamarin.Essentials;
using System.Collections.Generic;

namespace XFEssentialsMockExample.UnitTests
{
    public class MainViewModelTests
    {
        [Theory]
        [InlineData(NetworkAccess.None)]
        [InlineData(NetworkAccess.Unknown)]
        public void Test_ShouldBeDisconnected(NetworkAccess networkAccess)
        {
            // Arrange
            var mockedConnectivityWrapper = new Mock<IConnectivityWrapper>();
            
            var vm = new MainViewModel(mockedConnectivityWrapper.Object);

            // Act
            mockedConnectivityWrapper.Raise(
                x => x.ConnectivityChanged += null,
                new ConnectivityChangedEventArgs(networkAccess, new List<ConnectionProfile> { }));

            // Assert
            Assert.False(vm.Connected);
        }

        [Theory]
        [InlineData(NetworkAccess.Local)]
        [InlineData(NetworkAccess.Internet)]
        [InlineData(NetworkAccess.ConstrainedInternet)]
        public void Test_ShouldBeConnected(NetworkAccess networkAccess)
        {
            // Arrange
            var mockedConnectivityWrapper = new Mock<IConnectivityWrapper>();

            var vm = new MainViewModel(mockedConnectivityWrapper.Object);

            // Act
            mockedConnectivityWrapper.Raise(
                x => x.ConnectivityChanged += null,
                new ConnectivityChangedEventArgs(networkAccess, new List<ConnectionProfile> { }));

            // Assert
            Assert.True(vm.Connected);
        }
    }
}
