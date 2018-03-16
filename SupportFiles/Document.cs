using System;
using System.IO;

namespace SupportFiles
{
	/// <summary>
	/// Set of methods that help interaction with files (all exceptions are handled)
	/// </summary>
	public class Document
	{
		/// <summary>
		/// Reads the entire file to an array
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static string[] ReadFromFile(string path)
		{
			try
			{
				return File.ReadAllLines(path);
			}
			catch (Exception)
			{
				return new string[0];
			}
		}
		
		/// <summary>
		/// Returns a specific line from the file
		/// </summary>
		/// <param name="path"></param>
		/// <param name="line"></param>
		/// <returns></returns>
		public static string ReadSpecificLineFromFile(string path, int line)
		{
			if (!File.Exists(path))
			{
				return string.Empty;
			}

			using (var stream = new StreamReader(path))
			{
				for (var i = 0; i < line; i++)
					stream.ReadLine();
				return stream.ReadLine();
			}
		}

		/// <summary>
		/// Rewrites the entire file with the argument newFileContent
		/// </summary>
		/// <param name="path"></param>
		/// <param name="newFileContent"></param>
		/// <returns>Returns false if fails to save</returns>
		public static bool WriteToFile(string path, string[] newFileContent)
		{
			try
			{
				File.WriteAllLines(path, newFileContent);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Appends the string to the end of the file
		/// </summary>
		/// <param name="path"></param>
		/// <param name="stringToSave"></param>
		/// <returns>Returns false if fails to save</returns>
		public static bool AppendToFile(string path, string stringToSave)
		{
			try
			{
				File.AppendAllText(path, stringToSave);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Concats the log message with a time stamp and writes to a file
		/// </summary>
		/// /// <param name="path"></param>
		/// <param name="logMessage"></param>
		/// <returns>Returns false if fails to save</returns>
		public static bool WriteToLogFile(string path, string logMessage)
		{
			var fullMessage = $"{DateTime.UtcNow} : {logMessage}{Environment.NewLine}";

			return AppendToFile(path, fullMessage);
		}

		/// <summary>
		/// Concats a formated log message with a time stamp and writes to a file
		/// </summary>
		/// <param name="path"></param>
		/// <param name="logMessage"></param>
		/// <param name="para"></param>
		/// <returns>Returns false if fails to save</returns>
		public static bool WriteToLogFile(string path, string logMessage, params object[] para)
		{
			var fullMessage = $"{DateTime.UtcNow} : {string.Format(logMessage, para)}{Environment.NewLine}";

			return AppendToFile(path, fullMessage);
		}
	}
}