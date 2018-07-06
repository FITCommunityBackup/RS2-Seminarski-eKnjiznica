using eKnjiznica.Commons.ViewModels.Auctions;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.Mobile.Services
{
    public class AuctionClient
    {
        private readonly string _platform;
        private readonly HubConnection _connection;
        private readonly IHubProxy _proxy;

        public event EventHandler<AuctionVM> OnMessageReceived;

        public AuctionClient()
        {
            var connectionUrl = Constants.ServiceBaseUrl;
            _connection = new HubConnection(connectionUrl);
            _proxy = _connection.CreateHubProxy("AuctionHub");
        }

        public async Task Connect()
        {
            await _connection.Start();

            _proxy.On<AuctionVM>("OnNewBid", auction=> {
                OnMessageReceived(this, auction);
            });
        }

    }
}
