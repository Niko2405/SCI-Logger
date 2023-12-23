namespace SCI_Logger
{
	public class Logging
	{
		public static bool IsDebugEnabled = false;
		public static void Info(string message)
		{
			ConsoleColor currentForegroundColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Green;

			Console.WriteLine($"[Info]\t\t{message}");

			Console.ForegroundColor = currentForegroundColor;
		}
		public static void Error(string message)
		{
			ConsoleColor currentForegroundColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Red;

			Console.WriteLine($"[Error]\t\t{message}");

			Console.ForegroundColor = currentForegroundColor;
		}
		public static void Warn(string message)
		{
			ConsoleColor currentForegroundColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Yellow;

			Console.WriteLine($"[Warning]\t{message}");

			Console.ForegroundColor = currentForegroundColor;
		}
		public static void Debug(string message)
		{
			if (IsDebugEnabled)
			{
				ConsoleColor currentForegroundColor = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Cyan;

				Console.WriteLine($"[Debug]\t\t{message}");

				Console.ForegroundColor = currentForegroundColor;
			}
		}
	}
}
