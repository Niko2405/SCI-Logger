namespace SCI_Logger
{
	public class Logging
	{
		public static bool IsDebugEnabled = false;

		private static string GetCurrentTime()
		{
			return DateTime.Now.ToString("HH:mm");
		}
		private static void WriteInLogFile(string level, string message)
		{
			
			string pathToLogFile = "./latest.log";
			try
			{
				if (!File.Exists(pathToLogFile))
				{
					File.WriteAllText(pathToLogFile, $"[{level}:{GetCurrentTime()}]\t{message}\n");
					return;
				}
				else
				{
					File.AppendAllText(pathToLogFile, $"[{level}:{GetCurrentTime()}]\t{message}\n");
				}
			}
			catch (Exception ex)
			{
				Error(ex.Message);
			}
		}
		
		public static void Info(string message)
		{
			ConsoleColor currentForegroundColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Green;

			Console.WriteLine($"[Info:{GetCurrentTime()}]\t\t{message}");

			Console.ForegroundColor = currentForegroundColor;
			WriteInLogFile("Info", message);
		}
		public static void Error(string message)
		{
			ConsoleColor currentForegroundColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Red;

			Console.WriteLine($"[Error:{GetCurrentTime()}]\t\t{message}");

			Console.ForegroundColor = currentForegroundColor;
			WriteInLogFile("Error", message);
		}
		public static void Warn(string message)
		{
			ConsoleColor currentForegroundColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Yellow;

			Console.WriteLine($"[Warning:{GetCurrentTime()}]\t\t{message}");

			Console.ForegroundColor = currentForegroundColor;
			WriteInLogFile("Warn", message);
		}
		public static void Debug(string message)
		{
			if (IsDebugEnabled)
			{
				ConsoleColor currentForegroundColor = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Cyan;

				Console.WriteLine($"[Debug:{GetCurrentTime()}]\t\t{message}");

				Console.ForegroundColor = currentForegroundColor;
				WriteInLogFile("Debug", message);
			}
		}
		public static void PrintHeader(string title)
		{
			ConsoleColor currentForegroundColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Cyan;

			for (int i = 0; i < 50; i++)
			{
				Console.Write('=');
			}

			Console.Write($" {title} ");

			for (int i = 0; i < 50; i++)
			{
				Console.Write('=');
			}
			Console.WriteLine();
			Console.ForegroundColor = currentForegroundColor;
		}
	}
}
