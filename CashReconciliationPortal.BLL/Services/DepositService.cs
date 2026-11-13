using CashReconciliationPortal.BLL.Interfaces;
using CashReconciliationPortal.Core.DTOs;
using CashReconciliationPortal.Core.Entities;
using CashReconciliationPortal.DAL.Interfaces;
using CashReconciliationPortal.DAL.Repositories;

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

		//public async Task<DataTableResponse<DepositDto>> GetPagedDepositAsyncX(DataTableRequest request)
		//{
		//	var searchValue = request.Search?.Value ?? string.Empty;
		//	var skip = request.Start;
		//	var take = request.Length;

		//	var sortColumnIndex = request.Order != null && request.Order.Any() ? request.Order[0].Column : 0;

		//	var sortColumn = request.Columns != null && request.Columns.Count() > sortColumnIndex
		//		? request.Columns[sortColumnIndex].Data
		//		: "depositNumber";

		//	var sortDirection = request.Order != null && request.Order.Any() ? request.Order[0].Dir : "desc";

		//	var (totalRecords, filteredRecords, dataEntities) = await _repository.GetPagedDepositsAsync(searchValue, sortColumn, sortDirection, skip, take);

		//	var mappedData = dataEntities.Select(d => new DepositDto(
		//		d.DepositId,
		//		d.DepositNumber,
		//		d.ExpectedAmount,
		//		d.ActualAmount,
		//		d.Status
		//	)).ToList();

		//	return new DataTableResponse<DepositDto>(
		//		request.Draw,
		//		totalRecords,
		//		filteredRecords,
		//		mappedData
		//	);
		//}

		public async Task<DataTableResponse<DepositDto>> GetPagedDepositsAsync(DataTableRequest request)
		{
			// 1. Extraer los parámetros que nos envió JavaScript
			var searchValue = request.Search?.Value ?? string.Empty;
			var skip = request.Start;
			var take = request.Length;

			// Determinar qué columna pidió ordenar el usuario (si no hay, ordenamos por la primera)
			var sortColumnIndex = request.Order != null && request.Order.Any() ? request.Order[0].Column : 0;
			var sortColumn = GetSortColumn(request.Columns, sortColumnIndex, DepositsDataTableConstants.DepositNumber); //"depositNumber"

			var sortDirection = request.Order != null && request.Order.Any() ? request.Order[0].Dir : "desc";

			// 2. Llamar al Repositorio pasándole solo primitivos
			var (totalRecords, filteredRecords, dataEntities) = await _repository.GetPagedDepositsAsync(
				 searchValue, sortColumn, sortDirection, skip, take);

			// 3. Mapear las entidades de BD a tu Record DTO posicional
			// (Ajusta los nombres a como tengas definido tu Record DTO)
			var mappedData = dataEntities.Select(d => new DepositDto(
				 d.DepositId,
				 d.DepositNumber,
				 d.StoreNumber,
				 d.ExpectedAmount,
				 d.ActualAmount,
				 d.Variance,
				 d.Status,
				 d.DepositDate
			)).ToList();

			// 4. Retornar la estructura exacta que DataTables exige
			return new DataTableResponse<DepositDto>(
				 request.Draw,
				 totalRecords,
				 filteredRecords,
				 mappedData
			);
		}

		private string GetSortColumn(List<DtColumn> columns, int index, string defaultValue)
		{
			if (columns == null || index < 0 || index >= columns.Count)
				return defaultValue;

			string? data = columns[index].Data;

			return string.IsNullOrWhiteSpace(data) ? defaultValue : data;
		}
	}
}
