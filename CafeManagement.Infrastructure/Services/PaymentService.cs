using CafeManagement.Core.DTOs.Payment;
using CafeManagement.Core.Entities;
using CafeManagement.Core.Interfaces.Repositories;
using CafeManagement.Core.Interfaces.Services;
using CafeManagement.Core.Enums;

namespace CafeManagement.Infrastructure.Services
{
	public class PaymentService : IPaymentService
	{
		private readonly IPaymentRepository _paymentRepository;
		private readonly IOrderRepository _orderRepository;

		public PaymentService(
			IPaymentRepository paymentRepository,
			IOrderRepository orderRepository)
		{
			_paymentRepository = paymentRepository;
			_orderRepository = orderRepository;
		}

		public async Task<IEnumerable<PaymentDto>> GetAllAsync()
		{
			var payments = await _paymentRepository.GetAllAsync();

			return payments.Select(p => new PaymentDto
			{
				Id = p.Id,
				Amount = p.Amount,
				PaymentMethod = p.PaymentMethod.ToString(),
				Status = p.Status.ToString(),
				PaidAt = p.PaidAt,
				OrderId = p.OrderId
			});
		}

		public async Task<PaymentDto?> GetByIdAsync(int id)
		{
			var payment = await _paymentRepository.GetByIdAsync(id);

			if (payment == null)
				return null;

			return new PaymentDto
			{
				Id = payment.Id,
				Amount = payment.Amount,
				PaymentMethod = payment.PaymentMethod.ToString(),
				Status = payment.Status.ToString(),
				PaidAt = payment.PaidAt,
				OrderId = payment.OrderId
			};
		}

		public async Task<PaymentDto?> GetByOrderIdAsync(int orderId)
		{
			var payment = await _paymentRepository.GetByOrderIdAsync(orderId);

			if (payment == null)
				return null;

			return new PaymentDto
			{
				Id = payment.Id,
				Amount = payment.Amount,
				PaymentMethod = payment.PaymentMethod.ToString(),
				Status = payment.Status.ToString(),
				PaidAt = payment.PaidAt,
				OrderId = payment.OrderId
			};
		}

		public async Task AddAsync(CreatePaymentDto dto)
		{
			var order = await _orderRepository.GetByIdAsync(dto.OrderId);

			if (order == null)
				throw new Exception("Order not found.");

			if (dto.Amount != order.TotalPrice)
				throw new Exception("Payment amount must match the order total price.");

			var existingPayment =
				await _paymentRepository.GetByOrderIdAsync(dto.OrderId);

			if (existingPayment != null)
				throw new Exception("Payment already exists for this order.");

			var payment = new Payment
			{
				OrderId = dto.OrderId,
				Amount = order.TotalPrice,
				PaymentMethod = dto.PaymentMethod,
				Status = PaymentStatus.Pending
			};

			await _paymentRepository.AddAsync(payment);

			await _paymentRepository.SaveChangesAsync();
		}

		public async Task PayAsync(int orderId)
		{
			var payment = await _paymentRepository.GetByOrderIdAsync(orderId);

			if (payment == null)
				throw new Exception("Payment not found.");

			if (payment.Status == PaymentStatus.Paid)
				throw new Exception("Payment is already completed.");

			var order = await _orderRepository.GetByIdAsync(orderId);

			if (order == null)
				throw new Exception("Order not found.");

			payment.Status = PaymentStatus.Paid;
			payment.PaidAt = DateTime.UtcNow;

			order.Status = OrderStatus.Preparing;

			_paymentRepository.Update(payment);
			_orderRepository.Update(order);

			await _paymentRepository.SaveChangesAsync();
		}
	}
}