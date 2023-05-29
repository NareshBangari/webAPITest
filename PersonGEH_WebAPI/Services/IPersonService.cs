using PersonGEH_WebAPI_Unit_Testing.Model;

namespace PersonGEH_WebAPI_Unit_Testing.Services
{
		
		public interface IPersonService
		{
			public  IEnumerable<PersonDetails> GetAllList();
			public IEnumerable<PersonDetails> AddPerson(PersonDetails person);
			public IEnumerable<PersonDetails> GetPersonByLocation(string location);
			public IEnumerable<PersonDetails> GetPersonByTechnology(string technologyname);

			public IEnumerable<PersonDetails> GetPersonByTechnologyAndLocation(string location, string technology);
		
	}

}

