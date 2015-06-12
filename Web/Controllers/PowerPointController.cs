﻿using log4net;
using Microsoft.AspNet.SignalR;
using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Web.Hubs;

namespace Web.Controllers
{
    public class PowerPointController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void NextSlide(int id)
        {
            Log.DebugFormat("Next Slide Received for ID {0}", id);

            try
            {
            var context = GlobalHost.ConnectionManager.GetHubContext<SliderHub>();
            SliderHub.NextSlide(context.Clients);
            }
            catch(Exception ex)
            {
                Log.Error(ex);
            }

        }

        public void PrevSlide(int id)
        {
            Log.DebugFormat("Prev Slide Received for ID {0}", id);

            try
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<SliderHub>();
                SliderHub.PrevSlide(context.Clients);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}
