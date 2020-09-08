using System.Threading.Tasks;
using AspNetCoreSignalR.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AspNetCoreSignalR.Controllers {
    
    //If SignalR transport is using WebSockets or ServerSentEvents and I'm using bearer tokens then is additional configuration required.
    //None of this applies when we are using cookie authentication

    public class AnnouncementController : Controller {
        private readonly IHubContext<MessageHub> _hubContext;
        public AnnouncementController (IHubContext<MessageHub> hubContext) {
            _hubContext = hubContext;
        }

        [HttpGet("/announcement")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/announcement")]
        public async Task<IActionResult> Post([FromForm] string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
            return RedirectToAction("Index");
        }
    }
}