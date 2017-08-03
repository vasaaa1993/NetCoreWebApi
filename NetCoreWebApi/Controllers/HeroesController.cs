using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Models;
using NetCoreWebApi.Services;
using Microsoft.Extensions.Logging;
using NetCoreWebApi.Logger;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<Hero>> Get()
        {
			_logger.LogInformation(LoggingEvents.GET_ITEM,"Getting all heroes");

			return await _heroService.GetAll();

        }

        // GET api/heroes/5
        [HttpGet("{id}")]
        public async Task<Hero> Get(int id)
        {
			_logger.LogInformation(LoggingEvents.GET_ITEM, $"Getting hero with id = {id}");
			return await _heroService.Get(id); ;
        }

        // POST api/heroes
        [HttpPost]
        public async void Post([FromBody]Hero hero)
        {
			_logger.LogInformation(LoggingEvents.POST_ITEM, $"Add hero with name = {hero.Name}");
			await _heroService.Add(hero);
        }

        // DELETE api/heroes/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
			_logger.LogInformation(LoggingEvents.POST_ITEM, $"Delete hero with id = {id}");
			await _heroService.Delete(id);
        }
    }
}
