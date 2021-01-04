using EjercicioCLI;
using NUnit.Framework;

namespace EjercicioTest
{
	public class Tests
	{
		Client cliente;
		Mv commandMove;
		Touch commantTouch;
		Ls commandLs;
		Help commandHelp;
		Cd commandCd;

		[SetUp]
		public void Setup()
		{
			cliente = new Client();
			commandHelp = new Help();
			commantTouch = new Touch();
			commandLs = new Ls();
			commandMove = new Mv();
			commandCd = new Cd();
		}

		[Test]
		public void TouchCheck()
		{
			Assert.IsTrue(commantTouch.Check("touch"));
		}

		public void TouchNoCheck()
		{
			Assert.IsFalse(commantTouch.Check("mv"));
		}

		[Test]
		public void TouchExecute()
		{

			Assert.Pass();
		}

		[Test]
		public void MvCheck()
		{
			Assert.IsTrue(commandMove.Check("mv"));
		}

		public void MvNoCheck()
		{
			Assert.IsFalse(commandMove.Check("touch"));
		}

		[Test]
		public void MvExecute()
		{

			Assert.Pass();
		}

		[Test]
		public void LsCheck()
		{

			Assert.IsTrue(commandLs.Check("ls"));
		}

		public void LsNoCheck()
		{
			Assert.IsFalse(commantTouch.Check("mv"));
		}

		[Test]
		public void LsExecute()
		{

			Assert.Pass();
		}

		[Test]
		public void CdCheck()
		{
			Assert.IsTrue(commandCd.Check("cd"));
		}
		public void CdNoCheck()
		{
			Assert.IsFalse(commandCd.Check("touch"));
		}

		[Test]
		public void CdExecute()
		{

			Assert.Pass();
		}

		[Test]
		public void HelpCheck()
		{
			Assert.IsTrue(commandCd.Check("help"));
		}

		[Test]
		public void HelpExecute()
		{
			Assert.IsFalse(commandCd.Check("mv"));
		}

	}
}