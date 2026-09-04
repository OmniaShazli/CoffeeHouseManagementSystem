using CafeManagement.Core.DTOs.Order;
using CafeManagement.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CafeManagement.API.Controllers
{
    [Authorize(Roles = "Admin,Customer")]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(
            IOrderService orderService)
        {
            _orderService = orderService;
        }

        private string GetUserId()
        {
            return User.FindFirstValue(
                ClaimTypes.NameIdentifier)!;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (User.IsInRole("Admin"))
            {
                var orders =
                    await _orderService.GetAllAsync();

                return Ok(orders);
            }

            var userOrders =
                await _orderService.GetUserOrdersAsync(
                    GetUserId());

            return Ok(userOrders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            int id)
        {
            var order =
                await _orderService.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound(
                    "Order not found.");
            }

            if (User.IsInRole("Admin"))
            {
                return Ok(order);
            }

            var userOrders =
                await _orderService.GetUserOrdersAsync(
                    GetUserId());

            var isOwner =
                userOrders.Any(o => o.Id == id);

            if (!isOwner)
            {
                return Forbid();
            }

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateOrderDto dto)
        {
            await _orderService.AddAsync(
                dto,
                GetUserId());

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus(
            UpdateOrderStatusDto dto)
        {
            await _orderService
                .UpdateStatusAsync(dto);

            return Ok(
                "Order Status Updated Successfully");
        }
    }
}