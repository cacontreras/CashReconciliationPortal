using CashReconciliationPortal.BLL.Interfaces;
using CashReconciliationPortal.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CashReconciliationPortal.API.Controllers
{
	[Route("api/deposits")]
	[ApiController]
	public class DepositController : ControllerBase
	{
		private readonly IDepositService _depositService;

		public DepositController(IDepositService depositService)
		{
			_depositService = depositService;
		}

		//// GET: api/deposits
		//[HttpGet]
		//public async Task<IActionResult> GetAll()
		//{
		//	var deposits = await _depositService.GetAllDepositsAsync();
		//	return Ok(deposits);
		//}

		//// GET: api/deposits/5
		//[HttpGet("{id}")]
		//public async Task<IActionResult> GetById(int id)
		//{
		//	var deposit = await _depositService.GetDepositByIdAsync(id);

		//	if (deposit == null)
		//		return NotFound($"No se encontró el depósito con el Id {id}");

		//	return Ok(deposit);
		//}

		[HttpPost("paged")]
		public async Task<IActionResult> GetPagedDeposits([FromBody] DataTableRequest request)
		{
			var response = await _depositService.GetPagedDepositsAsync(request);
			return Ok(response);
		}

		//// POST: api/deposits
		//[HttpPost]
		//public async Task<IActionResult> Register([FromBody] CreateDepositDto depositDto)
		//{
		//	string currentUserId = "Admin_User";

		//	var newDeposit = await _depositService.RegisterDepositAsync(depositDto, currentUserId);
		//	return CreatedAtAction(nameof(GetById), new { id = newDeposit.DepositId }, newDeposit);
		//}

		//// PUT: api/deposits/{id}/reconcile
		//[HttpPut("{id}/reconcile")]
		//public async Task<IActionResult> Reconcile([FromBody] ReconcileDepositDto reconcileDto)
		//{
		//	try
		//	{
		//		var updatedDeposit = await _depositService.ReconcileDepositAsync(reconcileDto);
		//		return Ok(updatedDeposit);
		//	}
		//	catch (Exception ex)
		//	{
		//		return BadRequest(new { Message = ex.Message });
		//		throw;
		//	}
		//}

		//// GET: api/deposits/{id}/audit
		//[HttpGet("{id}/audit")]
		//public async Task<IActionResult> GetDepositAuditTrail(int id)
		//{
		//	var auditHistory = await _depositService.GetAuditTrailAsync(id);

		//	return Ok(auditHistory);
		//}
	}
}
