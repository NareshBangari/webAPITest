using PersonGEH_WebAPI_Unit_Testing.Exceptions;
using PersonGEH_WebAPI_Unit_Testing.Model;
using PersonGEH_WebAPI_Unit_Testing.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using NotImplementedException = PersonGEH_WebAPI_Unit_Testing.Exceptions.NotImplementedException;
using System;
using Microsoft.EntityFrameworkCore;

namespace PersonGEH_WebAPI_Unit_Testing.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersondetailsController : ControllerBase
	{
		private readonly IPersonService personService;
		

		public PersondetailsController(IPersonService _personService)
		{
			personService = _personService;
			
		}

		

		[HttpGet("PersonDetailsList")]
		public IEnumerable<PersonDetails> GetAllList()
		{
			var personDetailsList = personService.GetAllList();
			if (!personDetailsList.Any())
			{
				throw new NotFoundException($"PersonDetails List is empty.");
			}
			return personDetailsList;
		}

		
		[HttpPost("Add_Person")]
		public IEnumerable<PersonDetails> AddPersond(PersonDetails person)
		{
			return  personService.AddPerson(person);
			

		}

		[HttpGet("Get_Person_By_Tech")]
		public IEnumerable<PersonDetails> GetPersonByTechnology(string technologyname)
		{
			
			//_logger.LogInformation( $"Fetch Person with TechnologyName:"+ " "+ technologyname+ "from the database");
			var details = personService.GetPersonByTechnology(technologyname);
			if (details == null)
			{
				throw new NotFoundException( $"PersonDetails with given TechnologyName:"+" "+ technologyname +" is not found.");
			}
			//_logger.LogInformation($"Returning person with tencnologyname:"+" "+ technologyname);

			return details;
		}

		[HttpGet("Get_Person_By_Location")]
		public IEnumerable<PersonDetails> GetPersonByLocation(string? location)
		{
			//_logger.LogInformation( $"Fetch Person Details with given location:" +""+location+ "from the database");
			var details = personService.GetPersonByLocation(location!);
			if (details == null)
			{
				throw new NotFoundException( $"PersonDetails with given location:" +" "+location +" is not found.");
			}
			//_logger.LogInformation($"Returning person with location:"+" "+ location);

			return details;
		}

		[HttpGet("Get_Person_By_Technology_and_Location")]
		public IEnumerable<PersonDetails> GetPersonByTechnologyAndLocation(string location, string technology)
		{

			//_logger.LogInformation($"Fetch person with technologyname and Location from the database");
			var details =   personService.GetPersonByTechnologyAndLocation(location, technology);
			if (details == null)
			{
				throw new NotFoundException($"PersonDetails with given"+" "+ technology+" " +"and"+ " "+location + " "+"are not found.");
			}
			//_logger.LogInformation($"Returning person with tencnologyname:" + " "+details);

			return  details;
		}

		


	}
}