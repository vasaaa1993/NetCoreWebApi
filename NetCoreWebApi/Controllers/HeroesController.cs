using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Models;
using NetCoreWebApi.Services;
using Microsoft.Extensions.Logging;
using NetCoreWebApi.Logger;

namespace NetCoreWebApi.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
    public class HeroesController : Controller
    {
		private IHeroService _heroService;
		private ILogger _logger; 
		public HeroesController(IHeroService heroService, ILogger<HeroesController> logger)
		{
			_heroService = heroService;
			_logger = logger;
		}
        // GET api/heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
			_logger.LogInformation(LoggingEvents.GET_ITEM,"Getting all heroes");

			return _heroService.GetAll();

        }

        // GET api/heroes/5
        [HttpGet("{id}")]
        public Hero Get(int id)
        {
			_logger.LogInformation(LoggingEvents.GET_ITEM, $"Getting hero with id = {id}");
			return _heroService.Get(id); ;
        }

        // POST api/heroes
        [HttpPost]
        public void Post([FromBody]Hero value)
        {
			_logger.LogInformation(LoggingEvents.POST_ITEM, $"Add hero with name = {value.Name}");
			_heroService.Add(value);
        }

        // DELETE api/heroes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
			_logger.LogInformation(LoggingEvents.POST_ITEM, $"Delete hero with id = {id}");
			_heroService.Delete(id);
        }
    }
}
