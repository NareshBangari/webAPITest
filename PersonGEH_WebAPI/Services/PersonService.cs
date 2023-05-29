using PersonGEH_WebAPI_Unit_Testing.Data;
using PersonGEH_WebAPI_Unit_Testing.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PersonGEH_WebAPI_Unit_Testing.Controllers;

namespace PersonGEH_WebAPI_Unit_Testing.Services
{
	public class PersonService : IPersonService
	{

		private readonly DbContextClass _dbContext;
		public PersonService(DbContextClass dbContext)
		{
			_dbContext = dbContext;
		}
		
		public  IEnumerable<PersonDetails> GetAllList()
		{
			return  _dbContext.PersonDetalisTest.Include(c => c.TechnicalExperiences).ToList();
		}

		public IEnumerable<PersonDetails> AddPerson(PersonDetails person)
		{
			var result = _dbContext.PersonDetalisTest.Add(person);
			_dbContext.SaveChanges();
			//return new List<PersonDetails> { person };
			return Enumerable.Empty<PersonDetails>();
			


		}

		private PersonDetails Ok(EntityEntry<PersonDetails> result)
		{
			throw new NotImplementedException();
		}


		public IEnumerable<PersonDetails> GetPersonByLocation(string location)
		{
			IQueryable<PersonDetails> query = _dbContext.PersonDetalisTest.Include(c => c.TechnicalExperiences);

			query = query.Where(p => p.CurrentLocation == location).Include(c => c.TechnicalExperiences);
			var details = query;
			return details.ToList()!;

		}

		
		public  IEnumerable<PersonDetails> GetPersonByTechnology(string technologyname)
		{
			IQueryable<PersonDetails> query = _dbContext.PersonDetalisTest;

			query = query.Where(p => p.TechnicalExperiences!.Any(t => t.TechnologyName == technologyname)).Include(c => c.TechnicalExperiences);
			var details = query;
			return details.ToList();
			

		}
		


		public IEnumerable<PersonDetails> GetPersonByTechnologyAndLocation(string location, string technology)
		{
			IQueryable<PersonDetails> query = _dbContext.PersonDetalisTest.Include(c => c.TechnicalExperiences);
				
				query = query.Where(p => p.CurrentLocation == location && p.TechnicalExperiences!.Any(t => t.TechnologyName == technology)).Include(c => c.TechnicalExperiences);
			//var details = query.ToList();
			var details = query.ToList();
			return details;
			   


		}





	}


}

		









	



