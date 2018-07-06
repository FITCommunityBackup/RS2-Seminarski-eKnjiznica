using eKnjiznica.Commons.ViewModels.Auctions;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eKnjiznica.API.Signalr
{
    [HubName("AuctionHub")]
    public class AuctionHub : Hub
    {
        private static IHubConnectionContext<dynamic> GetClients()
        {
            return GlobalHost.ConnectionManager.GetHubContext<AuctionHub>().Clients;
        }


        public static void OnNewBid(AuctionVM auctionVM)
        {
            IHubConnectionContext<dynamic> clients = GlobalHost.ConnectionManager.GetHubContext<AuctionHub>().Clients;
            clients.All.OnNewBid(auctionVM);
        }
    }
}