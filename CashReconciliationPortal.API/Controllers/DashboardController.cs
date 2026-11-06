using CashReconciliationPortal.BLL.Interfaces;
using CashReconciliationPortal.Core.DTOs;
using CashReconciliationPortal.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace CashReconciliationPortal.API.Controllers
{
	[Route("api/dashboard")]
	[ApiController]
	public class DashboardController : Controller
	{
		private readonly IDashboardService _service;

		public DashboardController(IDashboardService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetMetrics()
		{
			var metrics = await _service.GetMetricsAsync();
			return Ok(metrics);
		}
	}
}
