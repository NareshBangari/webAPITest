using Moq;
using PersonGEH_WebAPI_Unit_Testing.Controllers;
using PersonGEH_WebAPI_Unit_Testing.Data;
using PersonGEH_WebAPI_Unit_Testing.Model;
using PersonGEH_WebAPI_Unit_Testing.Services;

namespace UnitTestProject
{
	public class UnitTestController
	{
		private readonly Mock<IPersonService> personService;


		public UnitTestController()
		{
			personService = new Mock<IPersonService>();
		}

		[Fact]
		public void GetAllPersonsList_GetAllList_returnPersonsdataList()
		{
			//arrange
			var personsList = GetPersonsData();
			personService.Setup(x => x.GetAllList()) //services method
				.Returns(personsList);
			var personsController = new PersondetailsController(personService.Object);

			//act
			var personsResult = personsController.GetAllList();// controller method

			//assert
			Assert.NotNull(personsResult);
			Assert.Equal(GetPersonsData().Count(), personsResult.Count());
			Assert.Equal(GetPersonsData().ToString(), personsResult.ToString());
			Assert.True(personsList.Equals(personsResult));
		}

		[Fact]
		public void AddPersonDetails_AddPerson_retrunOkOnPost()
		{
			//arrange
			var personsList = GetPersonsData();
			personService.Setup(x => x.AddPerson(personsList[0]))
				.Returns(personsList);
			var personsController = new PersondetailsController(personService.Object);

			//act
			var personsResult = personsController.AddPersond(personsList[0]);
			var expectedlocationName = personsResult.ToList()[0].Name;


			//assert
			Assert.NotNull(personsResult);
			Assert.Equal(personsList[0].Name, expectedlocationName);
			Assert.Equal(personsList[0].Name, expectedlocationName);

			//Assert.True(personsList[0].ProductId == productResult.ProductId);
		}




		[Theory]
		[InlineData("New York")]
		public void CheckPesonExistOrNotBylocation_GetPersonByLocation_PersonsList(string location)
		{
			//arrange
			var personsList = GetPersonsData();
			personService.Setup(x => x.GetPersonByLocation(location))
			.Returns(personsList);
			var personsController = new PersondetailsController(personService.Object);

			//act
			var personsResult = personsController.GetPersonByLocation(location);
			var expectedlocationName = personsResult.ToList()[0].CurrentLocation;
			

			//assert
			Assert.Equal(location, expectedlocationName);
			Assert.Equal(2, personsResult.Count());
			Assert.Contains(personsResult, p => p.Name == "John Doe"); // Check if John Doe is in the result
			Assert.Contains(personsResult, p => p.Name == "Jane Smith");
		}

		

		[Theory]
		[InlineData("C#")]
		public void CheckPesonExistOrNotByTechnology_GetPersonByTechnology_PersonsList(string technology)
		{
			//arrange
			var personsList = GetPersonsData();
			personService.Setup(x => x.GetPersonByTechnology(technology))
			.Returns(personsList);
			var personsController = new PersondetailsController(personService.Object);

			//act
			var personsResult = personsController.GetPersonByTechnology(technology);
			var expectedtechName = personsResult.ToList()[0].TechnicalExperiences![0].TechnologyName;
			var expectedtechName1 = personsResult.ToList()[1].TechnicalExperiences![0].TechnologyName;
			//assert
			Assert.Equal(technology, expectedtechName);
			Assert.Equal(technology, expectedtechName1);
			Assert.Equal(2, personsResult.Count());
			Assert.Contains(personsResult, p => p.Name == "John Doe"); // Check if John Doe is in the result
																	   //Assert.Contains(personsResult, p => p.Name == "Jane Smith");
		}

		[Theory]
		[InlineData("New York", "C#")]
		public void CheckPesonExistOrNot_GetPersonByTechnologyAndLocation_PersonsList(string location, string technology)
		{
			//arrange
			var personsList = GetPersonsData();
			personService.Setup(x => x.GetPersonByTechnologyAndLocation(location,technology))
				.Returns(personsList);
			var personsController = new PersondetailsController(personService.Object);

			//act
			var personsResult = personsController.GetPersonByTechnologyAndLocation(location,technology);
			var expectedlocationName = personsResult.ToList()[0].CurrentLocation;
			var expectedtechName = personsResult.ToList()[0].TechnicalExperiences![0].TechnologyName;

			//assert
			Assert.Equal(location, expectedlocationName);
			Assert.Equal(technology, expectedtechName);
			Assert.Equal(2, personsResult.Count());
			Assert.Contains(personsResult, p => p.Name == "John Doe"); // Check if John Doe is in the result
																	   //Assert.Contains(personsResult, p => p.Name == "Jane Smith");
		}
		
		private List<PersonDetails> GetPersonsData()
		{
			
			 var persons = new List<PersonDetails>
        {
				new PersonDetails
				{
					Name = "John Doe",
					Gender = true,
					DateOfBirth = new DateTime(1990, 1, 1),
					EmailId = "john@example.com",
					CurrentLocation = "New York",
					TechnicalExperiences = new List<TechnicalExperience>
					{
						new TechnicalExperience
						{
							TechnologyName = "C#",
							CompanyName = "ABC Corp",
							WorkedFrom = new DateTime(2018, 1, 1),
							WorkedTo = new DateTime(2020, 12, 31)
						},
						new TechnicalExperience
						{
							TechnologyName = "Java",
							CompanyName = "XYZ Inc",
							WorkedFrom = new DateTime(2015, 1, 1),
							WorkedTo = new DateTime(2017, 12, 31)
						}
					}
				},
				new PersonDetails
				{
					Name = "Jane Smith",
					Gender = false,
					DateOfBirth = new DateTime(1992, 5, 10),
					EmailId = "jane@example.com",
					CurrentLocation = "New York",
					TechnicalExperiences = new List<TechnicalExperience>
					{
						new TechnicalExperience
						{
							TechnologyName = "C#",
							CompanyName = "DEF Corp",
							WorkedFrom = new DateTime(2020, 1, 1),
							WorkedTo = new DateTime(2022, 12, 31)
						},
						new TechnicalExperience
						{
							TechnologyName = "Python",
							CompanyName = "PQR Ltd",
							WorkedFrom = new DateTime(2019, 1, 1),
							WorkedTo = new DateTime(2020, 12, 31)
						}
					}
				},
            
			};
			return persons;
		}
	}
}