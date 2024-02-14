namespace SCI_Logger
{
	/// <summary>
	/// Primary logger system for SCI projects
	/// </summary>
	public class Logging
	{
		private static bool _isDebugEnabled = false;

		/// <summary>
		/// Version of the Logger
		/// </summary>
		public static readonly string VERSION = "v1.8b";

		/// <summary>
		/// LogLevels
		/// </summary>
		public enum LogLevel
		{
			INFO,
			WARN,
			ERROR,
			DEBUG,
		}

		/// <summary>
		/// Set Debug mode on or off
		/// </summary>
		/// <param name="setDebugEnable"></param>
		/// <returns>True if Debug is enabled</returns>
		public static bool DebugEnabled
		{
			get
			{
				return _isDebugEnabled;
			}
			set
			{
				_isDebugEnabled = value;
			}
		}

		/// <summary>
		/// Gets current time for data logging
		/// </summary>
		/// <returns></returns>
		private static string GetCurrentTime()
		{
			return DateTime.Now.ToString("HH:mm:ss");
		}

		private static void WriteInLogFile(LogLevel logLevel, string message)
		{
			
			string pathToLogFile = "latest.log";
			try
			{
				File.AppendAllText(pathToLogFile, $"[{GetCurrentTime()}] [{logLevel}]:\t{message}" + Environment.NewLine);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[Logger Error]\t{ex.Message}");
			}
		}

		/// <summary>
		/// Logs a message with loglevel
		/// </summary>
		/// <param name="logLevel"></param>
		/// <param name="message"></param>
		public static void Log(LogLevel logLevel, string message, bool WriteInFile=true)
		{
			ConsoleColor currentForegroundColor = Console.ForegroundColor;
			
			// If empty, skip logging
			if (message == string.Empty)
				return;

			switch (logLevel)
			{
				case LogLevel.DEBUG:
					if (!DebugEnabled)
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
			if (WriteInFile)
			{
				WriteInLogFile(logLevel, message);
			}
		}

		/// <summary>
		/// Print a header with a title
		/// </summary>
		/// <param name="title"></param>
		public static void PrintHeader(string title)
		{
			
			short x = (short)Console.WindowWidth;
			short titleLenght = (short)title.Length;

			ConsoleColor currentForegroundColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Cyan;

			for (int i = 0; i < (x / 2) - (titleLenght / 2) - 1; i++)
			{
				Console.Write('=');
			}

			Console.Write($" {title} ");

			for (int i = 0; i < (x / 2) - (titleLenght / 2) - 1; i++)
			{
				Console.Write('=');
			}
			Console.WriteLine();
			Console.ForegroundColor = currentForegroundColor;
		}
	}
}
