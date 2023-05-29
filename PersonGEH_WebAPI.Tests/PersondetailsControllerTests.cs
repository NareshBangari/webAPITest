using System;
using Xunit;
using AutoFixture;
using Moq;
using FluentAssertions;
using PersonGEH_WebAPI.Services;
using PersonGEH_WebAPI.Controllers;
using PersonGEH_WebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Update;

namespace PersonGEH_WebAPI.Tests
{
	public class PersondetailsControllerTests
	{
		private readonly IFixture _fixture;
		private readonly Mock<IPersonService>? _personServiceMock;
		private readonly Mock<ILogger<PersondetailsController>> loggerMock;
		private readonly PersondetailsController _sut;

		public PersondetailsControllerTests()
		{
			_fixture= new Fixture();
			_personServiceMock= _fixture.Freeze<Mock<IPersonService>>();
			loggerMock = _fixture.Freeze<Mock<ILogger<PersondetailsController>>>();
			_sut = new PersondetailsController(_personServiceMock.Object,loggerMock.Object);
		}


		[Fact]
		public async Task GetAllList_ShouldReturnOKResponce_WhenDataFound()
		{
			//Arrange
			var PersonDataMock = _fixture.Create<IEnumerable<PersonDetails>>();
			_personServiceMock!.Setup(x => x.GetAllList()).ReturnsAsync(PersonDataMock);

			//Act
			var result = await _sut.GetAllList();	

			//Assert
			result.Should().NotBeNull();
			result.Should().HaveCount(PersonDataMock.Count());
			
		}

		[Theory]
		[InlineData("location")]
		public async Task GetBylocation_ShouldReturnOKResponce_WhenDataFound(string location)
		{
			//Arrange
			
			var PersonDataMock = _fixture.Create<IEnumerable<PersonDetails>>();
			_personServiceMock!.Setup(x => x.GetAllList()).ReturnsAsync(PersonDataMock);

			//Act
			var result = await _sut.GetAllList();
			var expectedlocation = result.ToList()[0].CurrentLocation;
			
			//Assert
			result.Should().NotBeNull();
			result.Should().HaveCount(PersonDataMock.Count());
			//result.Should().Equals(location.Equals(expectedlocation));
			location.Should().BeEquivalentTo(expectedlocation);


		}


	}
}