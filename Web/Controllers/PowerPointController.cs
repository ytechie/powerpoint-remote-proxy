using Microsoft.AspNet.SignalR;
using System.Web.Http;
using System.Web.Mvc;
using Web.Hubs;

namespace Web.Controllers
{
    public class PowerPointController : Controller
    {
        public void NextSlide(int id)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<SliderHub>();
            SliderHub.NextSlide(context.Clients);
        }

        public void PrevSlide(int id)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<SliderHub>();
            SliderHub.PrevSlide(context.Clients);
        }
    }
}
