using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;

namespace Web.Hubs
{
    public class SliderHub : Hub
    {
        public override Task OnConnected()
        {
            Clients.Caller.connected(Context.ConnectionId);
            return base.OnConnected();
        }

        public void Subscribe(int groupId)
        {
            Groups.Add(Context.ConnectionId, groupId.ToString());
        }

        //This allows us to send data from a static context
        public static void NextSlide(int groupId)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<SliderHub>();
            hubContext.Clients.Group(groupId.ToString()).next();
        }

        public static void PrevSlide(int groupId)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<SliderHub>();
            hubContext.Clients.Group(groupId.ToString()).previous();
        }

    }
}
