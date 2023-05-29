using Moq;
using PersonGEH_WebAPI.Services;
using PersonGEH_WebAPI.Model;
using PersonGEH_WebAPI.Data;
using Xunit;
using System.Threading.Tasks;




namespace UnitTestProject
{
	public class UnitTest1
	{

		
		[Fact]
		public async Task GetAllList_shouldreturn200satus()
		{
			var personlist = new Mock<IPersonService>();

		}
	}
}