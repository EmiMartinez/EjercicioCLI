using System;
using System.Collections.Generic;



namespace EjercicioCLI
{
	public class MainApp
	{
		static void Main()
		{
			//se agregan los commands disponibles
			List<Expression> expressionList = new List<Expression>();
			expressionList.Add(new Touch());
			expressionList.Add(new Mv());
			expressionList.Add(new Ls());
			expressionList.Add(new Cd());
			expressionList.Add(new Help());
			expressionList.Add(new Exit());

			Client client = new Client();
			client.Welcome();
			while (true)
			{
				client.GetDirectory();
				client.Input = Console.ReadLine();
	
				//tambien puedo usar Tdictionary....
				foreach (Expression exp in expressionList)
				{
					exp.Interpreter(client);
				}
				client.NewLine();
				client.ShowOutput();


			}
		}
	}


}

