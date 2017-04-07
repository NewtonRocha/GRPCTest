using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPWSPOC
{
	public class WSPOCService
	{
		Process server;

		public void Start()
		{
			Channel channel = new Channel("127.0.0.1:3000", ChannelCredentials.Insecure);
			var client = new PocGp.PocGpClient(channel);

			this.server = Process.Start(@"..\..\..\Server\bin\Debug\Server.exe");

			while (true)
			{
				Console.Clear();
				Console.WriteLine("Digite seu nome: ");
				var name = Console.ReadLine();

				var nameResponse = client.Hello(new NameRequest() { Name = name });

				Console.WriteLine(nameResponse.Name);

				Console.WriteLine("Digite sua Idade: ");
				var age = Console.ReadLine();

				int intAge;

				int.TryParse(age, out intAge);

				var ageResponse = client.AddingTen(new IntRequest() { Value = intAge });

				Console.WriteLine($"Daqui a 10 anos você terá {ageResponse.Value} Anos");

				Console.ReadKey();
			}

			channel.ShutdownAsync().Wait();
		}

		public void Stop() { this.server.Kill(); }
	}
}
