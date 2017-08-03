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
	public class WeaponsController : Controller
	{
		private WeaponsService _weaponoService;
		private ILogger _logger;
		public WeaponsController(WeaponsService weaponoService, ILogger<WeaponsController> logger)
		{
			_weaponoService = weaponoService;
			_logger = logger;
		}

		// GET api/weapons
		[HttpGet]
		public async Task<IEnumerable<Weapon>> Get()
		{
			_logger.LogInformation(LoggingEvents.GET_ITEM, "Getting all weapons");

			return await _weaponoService.GetAll();

		}

		// GET api/weapons/5
		[HttpGet("{id}")]
		public async Task<Weapon> Get(int id)
		{
			_logger.LogInformation(LoggingEvents.GET_ITEM, $"Getting weapon with id = {id}");
			return await _weaponoService.Get(id); ;
		}

		// POST api/weapons
		[HttpPost]
		public async void Post([FromBody]Weapon weapon)
		{
			_logger.LogInformation(LoggingEvents.POST_ITEM, $"Add weapon with name = {weapon}");
			await _weaponoService.Add(weapon);
		}

		// DELETE api/weapons/5
		[HttpDelete("{id}")]
		public async void Delete(int id)
		{
			_logger.LogInformation(LoggingEvents.POST_ITEM, $"Delete weapon with id = {id}");
			await _weaponoService.Delete(id);
		}
	}
}
