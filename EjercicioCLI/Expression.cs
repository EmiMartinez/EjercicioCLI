
using System;
using System.IO;


namespace EjercicioCLI
{
	/// <summary>

	/// Clase abstracta para el command

	/// </summary>

	abstract class Expression

	{
		public void Interpreter(Client context)
		{
			if (this.Check(context.GetCommand()))
			{
				context.Output = this.Execute(context.GetArguments());
				return;
			}


		}

		internal abstract string Execute(string[] arguments);
		public abstract bool Check(string command);

	}

	/// <summary>

	/// Crea un nuevo archivo

	/// </summary>

	class Touch : Expression

	{
		public override bool Check(string command)
		{
			if (command == "touch") return true; else return false;
		}

		internal override string Execute(string[] arguments)
		{
			try
			{
				File.Create(arguments[0]).Dispose();
				return "Archivo " + arguments[0] + "generado correctamente.";
			}
			catch (Exception e)
			{
				return "Error al crear el archivo.";
			}
		}
	}

	/// <summary>

	/// Cambia de nombre un archivo o mueve un archivo de directorio

	/// </summary>

	class Mv : Expression

	{
		public override bool Check(string command)
		{
			if (command == "mv") return true; else return false;
		}

		internal override string Execute(string[] arguments)
		{
			try
			{
				if (arguments.Length < 2) return "Parametros incorrectos";


				System.IO.File.Move(arguments[0], arguments[1]);
				return "Movimiento de archivos realizado correctamente";
			}
			catch (Exception ex)
			{
				return "Error al realizar la modificación del archivo.";
			}
		}
	}

	/// <summary>

	/// Muestra los archivos/carpetas que se encuentran en el directorio

	/// </summary>

	class Ls : Expression

	{
		public override bool Check(string command)
		{
			if (command == "ls") return true; else return false;
		}

		internal override string Execute(string[] arguments)
		{
			if (arguments[0].ToUpper() == "-R")
			{
				this.DirectoryPrint("./");
			}
			else
			{
				//string[] allfiles = Directory.GetFiles("./", "*.*", SearchOption.AllDirectories);
				Console.WriteLine();
				string[] files = Directory.GetFiles("./");
				Console.WriteLine(String.Join(Environment.NewLine, files));

				Console.WriteLine();
				string[] dirs = Directory.GetDirectories("./");
				Console.WriteLine(String.Join(Environment.NewLine, dirs));
			}

			return "Proceso de directorios completado";
		}


		public void DirectoryPrint(string path)
		{
			try
			{
				Console.WriteLine(path);

				foreach (string file in Directory.GetFiles(path))
				{
					Console.WriteLine(file);
				}

				foreach (string directory in Directory.GetDirectories(path))
				{
					//Función recursiva
					DirectoryPrint(directory);
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

	}

	/// <summary>

	/// Permite navegar entre los diferentes directorios

	/// </summary>

	class Cd : Expression

	{
		public override bool Check(string command)
		{
			if (command == "cd") return true; else return false;
		}

		internal override string Execute(string[] arguments)
		{
			try
			{
				if (arguments[0] != "") Directory.SetCurrentDirectory(arguments[0]);
				return "";
			}
			catch (DirectoryNotFoundException e)
			{
				return "El directorio especificada no existe.";
			}

		}
	}

	/// <summary>

	/// Permite ver un listado y que hace cada uno

	/// </summary>

	class Help : Expression

	{
		public override bool Check(string command)
		{
			if (command == "help") return true; else return false;
		}

		internal override string Execute(string[] arguments)
		{
			Console.WriteLine();
			Console.WriteLine("touch[nombre de archivo] : Crea un archivo nuevo con el siguiente nombre y extensión.");
			Console.WriteLine("mv[archivo1][archivo2] : Cambia de nombre un archivo.");
			Console.WriteLine("mv[path1][path2] : Mueve un archivo de directorio.");
			Console.WriteLine("ls: Muestra los archivos / carpetas que se encuentran en el directorio.");
			Console.WriteLine("ls -R: Muestra el contenido de todos los subdirectorios de forma recursiva.");
			Console.WriteLine("cd[path]: Permite navegar entre los diferentes directorios.");
			Console.WriteLine("help[comando]: Permite ver un listado y que hace cada uno.");
			return "";
		}
	}
	class Exit : Expression
	{
		public override bool Check(string command)
		{
			if (command == "exit") return true; else return false;
		}

		internal override string Execute(string[] arguments)
		{
			//solo test
			Environment.Exit(0);
			return "";
		}
	}
}
