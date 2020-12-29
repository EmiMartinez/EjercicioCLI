using System;
using System.Linq;
using System.IO;

namespace EjercicioCLI
{
	/// <summary>

	/// The 'Context' class

	/// </summary>

	public class Client

	{
		private string _input;
		//private string _currentDirectory;
		private string _output;

		public string Input
		{
			get { return _input; }
			set { _input = value; }
		}

		public string Output
		{
			get { return _output; }
			set { _output = value; }
		}

		/*public string CurrentDirectory
		{
			get { return _currentDirectory; }
			set { _currentDirectory = value; }
		}*/

		public string GetCommand()
		{
			return Input.Split(new char[] { ' ' }).First();
		}

		public string[] GetArguments()
		{
			//for (int i = 1; i <= Input.Length - 1; i++)
			//ElRetorno += Input[i];

			if (Input.Split(new char[] { ' ' }).Length > 1)
				return Input.Split(new char[] { ' ' }).Skip(1).ToArray();
			else return new string[] { "" };

		}

		public void NewLine()
		{
			Console.WriteLine("");
		}

		internal void ShowOutput()
		{
			if (Output != "")
			{
				Console.WriteLine(Output);
			}
		}

		internal void Welcome()
		{
			Console.WriteLine("Bienvenido al CLI. Escriba un comando.");
		}

		internal void GetDirectory()
		{
			Console.Write("$>" + Directory.GetCurrentDirectory() + " ");

		}
	}
}
