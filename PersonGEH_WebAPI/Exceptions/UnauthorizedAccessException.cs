namespace PersonGEH_WebAPI_Unit_Testing.Exceptions
{
	public class UnauthorizedAccessException : Exception
	{
		public UnauthorizedAccessException(string message) : base(message) { }
	}
}