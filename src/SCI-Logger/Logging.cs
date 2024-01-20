using System.Diagnostics;
using System.Reflection;
using static SCI_Logger.Logging;

namespace SCI_Logger
{
	public class Logging
	{
		public static bool IsDebugEnabled = false;
		public static readonly string VERSION = "v1.3e";

		public enum LogLevel
		{
			DEBUG,
			INFO,
			WARN,
			ERROR
		}
		private static string GetCurrentTime()
		{
			return DateTime.Now.ToString("HH:mm:ss");
		}
		private static void WriteInLogFile(LogLevel logLevel, string message)
		{
			
			string pathToLogFile = "./latest.log";
			try
			{
				if (!File.Exists(pathToLogFile))
				{
					File.WriteAllText(pathToLogFile, $"[{GetCurrentTime()}] [{logLevel}]:\t{message}");
					return;
				}
				else
				{
					File.AppendAllText(pathToLogFile, $"[{GetCurrentTime()}] [{logLevel}]:\t{message}");
				}
			}
			catch (Exception ex)
			{
				Log(LogLevel.ERROR, ex.Message);
			}
		}
		

		public static void Log(LogLevel logLevel, string message)
		{
			ConsoleColor currentForegroundColor = Console.ForegroundColor;
			
			// If empty, skip logging
			if (message == string.Empty)
			{
				return;
			}

			switch (logLevel)
			{
				case LogLevel.DEBUG:
					if (!IsDebugEnabled)
						return;
					Console.ForegroundColor = ConsoleColor.Cyan;
					break;
				case LogLevel.INFO:
					Console.ForegroundColor = ConsoleColor.Green;
					break;
				case LogLevel.WARN:
					Console.ForegroundColor = ConsoleColor.Yellow;
					break;
				case LogLevel.ERROR:
					Console.ForegroundColor = ConsoleColor.Red;
					break;
				default:
					break;
			}
			Console.WriteLine($"[{GetCurrentTime()}] [{logLevel}]:\t{message}");
			Console.ForegroundColor = currentForegroundColor;
			WriteInLogFile(logLevel, message);
		}

		/// <summary>
		/// Log an info message
		/// </summary>
		/// <param name="message"></param>
		[Obsolete("Methode is deprecated. Use Log instead.")]
		public static void Info(string message)
		{
			if (message == string.Empty)
			{
				return;
			}
			ConsoleColor currentForegroundColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Green;

			Console.WriteLine($"[Info:{GetCurrentTime()}]\t\t{message}");

			Console.ForegroundColor = currentForegroundColor;
			WriteInLogFile(LogLevel.INFO, message);
		}

		/// <summary>
		/// Log an error message
		/// </summary>
		/// <param name="message"></param>
		[Obsolete("Methode is deprecated. Use Log instead.")]
		public static void Error(string message)
		{
			if (message == string.Empty)
			{
				return;
			}
			ConsoleColor currentForegroundColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Red;

			Console.WriteLine($"[Error:{GetCurrentTime()}]\t\t{message}");

			Console.ForegroundColor = currentForegroundColor;
			WriteInLogFile(LogLevel.ERROR, message);
		}

		/// <summary>
		/// Log a warn message
		/// </summary>
		/// <param name="message"></param>
		[Obsolete("Methode is deprecated. Use Log instead.")]
		public static void Warn(string message)
		{
			if (message == string.Empty)
			{
				return;
			}
			ConsoleColor currentForegroundColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Yellow;

			Console.WriteLine($"[Warning:{GetCurrentTime()}]\t\t{message}");

			Console.ForegroundColor = currentForegroundColor;
			WriteInLogFile(LogLevel.WARN, message);
		}

		/// <summary>
		/// Log a debug message
		/// </summary>
		/// <param name="message"></param>
		[Obsolete("Methode is deprecated. Use Log instead.")]
		public static void Debug(string message)
		{
			if (message == string.Empty)
			{
				return;
			}
			if (IsDebugEnabled)
			{
				ConsoleColor currentForegroundColor = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Cyan;

				Console.WriteLine($"[Debug:{GetCurrentTime()}]\t\t{message}");

				Console.ForegroundColor = currentForegroundColor;
				WriteInLogFile(LogLevel.DEBUG, message);
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
