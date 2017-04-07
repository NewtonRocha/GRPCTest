using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPWSPOC.PocGp;

namespace GPWSPOC
{
	public class GPWSPOCServer : PocGpBase
	{
		public override Task<NameResponse> Hello(NameRequest request, ServerCallContext context)
		{
			return Task.FromResult(new NameResponse() { Name = $"Hello {request.Name}" });
		}

		public override Task<IntResponse> AddingTen(IntRequest request, ServerCallContext context)
		{
			return Task.FromResult(new IntResponse() { Value = 10 + request.Value });
		}
	}
}
