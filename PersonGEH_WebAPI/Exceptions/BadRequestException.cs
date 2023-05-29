namespace PersonGEH_WebAPI_Unit_Testing.Exceptions
{
	public class BadRequestException : Exception
	{
		public BadRequestException(string message) : base(message) { }
	}
}