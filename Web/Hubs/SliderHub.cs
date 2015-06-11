using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;

namespace Web.Hubs
{
    [HubName("slider")]
    public class SliderHub : Hub
    {
        public override Task OnConnected()
        {
            Clients.Caller.connected(Context.ConnectionId);
            return base.OnConnected();
        }

        //This allows us to send data from a static context
        public static void NextSlide(IHubConnectionContext<dynamic> clients)
        {
            clients.All.next();
        }

        public static void PrevSlide(IHubConnectionContext<dynamic> clients)
        {
            clients.All.previous();
        }

    }
}
