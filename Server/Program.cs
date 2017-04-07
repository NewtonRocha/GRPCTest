using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using GPWSPOC;

namespace Server
{
	public class Program
	{
		static void Main(string[] args)
		{
			const int Port = 3000;
			Grpc.Core.Server server = new Grpc.Core.Server
			{
				Services = { PocGp.BindService(new GPWSPOCServer()) },
				Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
			};
			server.Start();

			Console.WriteLine("RouteGuide server listening on port " + Port);
			Console.WriteLine("Press any key to stop the server...");
			Console.ReadKey();

			server.ShutdownAsync().Wait();
		}
	}
}
