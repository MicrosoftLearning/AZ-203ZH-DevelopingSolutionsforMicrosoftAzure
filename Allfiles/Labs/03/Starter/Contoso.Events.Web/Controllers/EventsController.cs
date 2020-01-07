using Contoso.Events.Data;
using Contoso.Events.Models;
using Contoso.Events.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;

namespace Contoso.Events.Management.Controllers
{
    [Route("[controller]")]
    public class EventsController : Controller
    {
        [HttpGet]
        [Route("{page:int?}", Name = "EventList")]
        public IActionResult Index([FromServices] EventsContext eventsContext, [FromServices] IOptions<ApplicationSettings> appSettings, int? page)
        {
            var pagedEvents = Enumerable.Empty<Event>();

            EventsGridViewModel viewModel = new EventsGridViewModel
            {
                CurrentPage = 0,
                PageSize = 0,
                TotalRows = 0,
                Events = pagedEvents
            };

            return View(viewModel);
        }

        [HttpGet]
        [Route("detail/{key}", Name = "EventDetail")]
        public IActionResult Detail([FromServices] EventsContext eventsContext, string key)
        {
            var matchedEvent = default(Event);

            EventDetailViewModel viewModel = new EventDetailViewModel
            {
                Event = matchedEvent
            };

            return View(viewModel);
        }
    }
}
