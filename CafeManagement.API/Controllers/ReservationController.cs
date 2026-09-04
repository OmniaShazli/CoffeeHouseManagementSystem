using CafeManagement.Core.DTOs.Reservation;
using CafeManagement.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CafeManagement.API.Controllers
{
    [Authorize(Roles = "Admin,Customer")]
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(
            IReservationService reservationService)
        {
            _reservationService = reservationService;
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
                var reservations =
                    await _reservationService.GetAllAsync();

                return Ok(reservations);
            }

            var userReservations =
                await _reservationService
                    .GetUserReservationsAsync(GetUserId());

            return Ok(userReservations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (User.IsInRole("Admin"))
            {
                var reservation =
                    await _reservationService.GetByIdAsync(id);

                if (reservation == null)
                {
                    return NotFound(
                        "Reservation not found.");
                }

                return Ok(reservation);
            }

            var userReservation =
                await _reservationService
                    .GetByIdForUserAsync(
                        id,
                        GetUserId());

            if (userReservation == null)
            {
                return NotFound(
                    "Reservation not found.");
            }

            return Ok(userReservation);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateReservationDto dto)
        {
            await _reservationService.AddAsync(
                dto,
                GetUserId());

            return Ok(
                "Reservation Created Successfully");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(
            UpdateReservationDto dto)
        {
            await _reservationService.UpdateAsync(dto);

            return Ok(
                "Reservation Updated Successfully");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reservationService.DeleteAsync(id);

            return Ok(
                "Reservation Deleted Successfully");
        }
    }
}