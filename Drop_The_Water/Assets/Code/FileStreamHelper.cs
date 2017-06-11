using System;
using UnityEngine;
using System.IO;

namespace FileHelper
{
	public class FileStreamHelper
	{
		private static string _tmp = "";

		public FileStreamHelper ()
		{

		}

		// 파일을 만들어서(이미 있으면 덮어씌움) 문자열을 한 줄씩 입력
		public static void writeStringToFile( string str, string filename )
		{
			#if !WEB_BUILD
			string path = pathForDocumentsFile( filename );
			FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);

			StreamWriter sw = new StreamWriter(file);
			sw.WriteLine( str );

			sw.Close();
			file.Close();
			#endif
		}

		// 파일을 추가로 만들어 문자열 한 줄씩 입력
		public static void writeStringToFileAppend( string str, string filename )
		{
			#if !WEB_BUILD
			string path = pathForDocumentsFile( filename );
			FileStream file = new FileStream (path, FileMode.Append, FileAccess.Write);

			StreamWriter sw = new StreamWriter( file );
			sw.WriteLine( str );

			sw.Close();
			file.Close();
			#endif 
		}

		// 파일을 열어 한 행씩 읽음 (string)
		public static string readStringFromFile( string filename)
		{
			#if !WEB_BUILD
			string path = pathForDocumentsFile(filename );

			if (File.Exists(path))
			{
				FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
				StreamReader sr = new StreamReader( file );

				string str = null;
				string total = "";
				while((str = sr.ReadLine()) != null)
					total += str + "\n";

				sr.Close();
				file.Close();

				return total;
			}
			else
			{
				return null;
			}
			#else
			return null;
			#endif 
		}

		// 파일 경로 구함 (안드로이드)
		public static string pathForDocumentsFile(string filename)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				string path = Application.persistentDataPath;
				path = path.Substring(0, path.LastIndexOf('/'));
				path = path + "/files";
				return Path.Combine(path, filename);
			}

			else
			{
				string path = Application.dataPath;
				//string path = "";
				path = path.Substring(0, path.LastIndexOf('/'));
				path = path + "/files";
				return Path.Combine(path, filename);
			}
		}

		public static void log(string log)
		{
			if (log.Equals (_tmp))
				return;
			else
				_tmp = log;

			log = System.DateTime.Now.ToString ("yyyy:MM:dd:hh:mm:ss :: ") + log;

			Debug.Log (log);

			//log = readStringFromFile ("log") + "\n" + log;

			writeStringToFileAppend (log, "log");
		}

		public static void log(int obj)
		{
			log (obj.ToString ());
		}
	}
}