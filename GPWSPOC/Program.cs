using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace GPWSPOC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			HostFactory.Run(x =>
			{
				x.Service<WSPOCService>(s =>
				{
					s.ConstructUsing(name => new WSPOCService());
					s.WhenStarted(tc => tc.Start());
					s.WhenStopped(tc => tc.Stop());
				});
				x.EnableServiceRecovery(r =>
				{
					r.RestartService(0);
					r.OnCrashOnly();
					r.SetResetPeriod(1);
				});
				x.RunAsLocalSystem();

				x.SetDescription("Gp Windows Services");
				x.SetDisplayName("GpService");
				x.SetServiceName("CapptaGp");
				x.StartAutomatically();
			});
		}
	}
}
