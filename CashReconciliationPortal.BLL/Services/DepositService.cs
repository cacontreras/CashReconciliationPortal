using CashReconciliationPortal.BLL.Interfaces;
using CashReconciliationPortal.Core.DTOs;
using CashReconciliationPortal.Core.Entities;
using CashReconciliationPortal.DAL.Interfaces;

namespace CashReconciliationPortal.BLL.Services
{
	public class DepositService : IDepositService
	{
		private readonly IDepositRepository _repository;

		public DepositService(IDepositRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Deposit>> GetAllDepositsAsync()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<Deposit?> GetDepositByIdAsync(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task<Deposit> RegisterDepositAsync(CreateDepositDto depositDto, string userId)
		{
			var newDeposit = new Deposit
			{
				DepositNumber = depositDto.DepositNumber,
				StoreNumber = depositDto.StoreNumber,
				ExpectedAmount = depositDto.ExpectedAmount,
				ActualAmount = 0,
				Variance = 0,
				Status = "Pending",
				DepositDate = DateTime.UtcNow
			};

			await _repository.AddAsync(newDeposit);

			var audit = new DepositAudit
			{
				DespositId = newDeposit.DepositId,
				Action = "CREATE",
				OldValues = "{}",
				NewValues = $"{{ ExpectedAmount: {newDeposit.ExpectedAmount}, Status: '{newDeposit.Status}' }}",
				TimeStamp = DateTime.UtcNow,
				UserId = userId
			};

			await _repository.AddAuditAsync(audit);

			return newDeposit;
		}

		public async Task<Deposit> ReconcileDepositAsync(ReconcileDepositDto reconcileDto)
		{
			var deposit = await _repository.GetByIdAsync(reconcileDto.DepositId);

			if (deposit == null)
				throw new Exception($"El depósito con ID {reconcileDto.DepositId} no fue encontrado.");

			var oldValues = $"{{ ActualAmount: {deposit.ActualAmount}, Status: '{deposit.Status}' }}";

			deposit.ActualAmount = reconcileDto.ActualAmount;
			deposit.Variance = deposit.ActualAmount - deposit.ExpectedAmount;

			deposit.Status = deposit.Variance
			switch
			{
				0 => "Balanced",
				> 0 => "Overage",
				< 0 => "Shortage"
			};

			await _repository.UpdateAsync(deposit);

			var newValues = $"{{ ExpectedAmount: {deposit.ActualAmount}, Status: '{deposit.Status}' }}";

			var audit = new DepositAudit
			{
				DespositId = deposit.DepositId,
				Action = "RECONCILE",
				OldValues = oldValues,
				NewValues = newValues,
				TimeStamp = DateTime.UtcNow,
				UserId = reconcileDto.UserId
			};

			await _repository.AddAuditAsync(audit);

			return deposit;
		}

		public async Task<IEnumerable<DepositAuditDto>> GetAuditTrailAsync(int depositId)
		{
			var auditEntities = await _repository.GetAuditTrailAsync(depositId);

			return auditEntities.Select(a => new DepositAuditDto(
				DepositAuditId: a.DepositAuditId,
				DespositId: a.DespositId,
				OldValues: a.OldValues,
				NewValues: a.NewValues,
				Action: a.Action,
				TimeStamp: a.TimeStamp,
				UserId: a.UserId
			)).ToList();
		}
	}
}
