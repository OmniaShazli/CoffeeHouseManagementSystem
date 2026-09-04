using CafeManagement.Core.DTOs.Payment;
using CafeManagement.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeManagement.API.Controllers
{
	[Authorize(Roles = "Admin,Customer")]
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentController : ControllerBase
	{
		private readonly IPaymentService _paymentService;

		public PaymentController(IPaymentService paymentService)
		{
			_paymentService = paymentService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var payments = await _paymentService.GetAllAsync();

			return Ok(payments);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var payment = await _paymentService.GetByIdAsync(id);

			if (payment == null)
				return NotFound();

			return Ok(payment);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreatePaymentDto dto)
		{
			await _paymentService.AddAsync(dto);

			return Ok("Payment created successfully.");
		}

		[HttpPut("{orderId}/pay")]
		public async Task<IActionResult> Pay(int orderId)
		{
			await _paymentService.PayAsync(orderId);

			return Ok("Payment completed successfully.");
		}
	}
}