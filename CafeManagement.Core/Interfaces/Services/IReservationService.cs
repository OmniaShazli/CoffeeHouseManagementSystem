using CafeManagement.Core.DTOs.Reservation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeManagement.Core.Interfaces.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationDto>> GetAllAsync();

        Task<IEnumerable<ReservationDto>> GetUserReservationsAsync(
            string userId);

        Task<ReservationDto?> GetByIdAsync(int id);

        Task<ReservationDto?> GetByIdForUserAsync(
            int id,
            string userId);

        Task AddAsync(
            CreateReservationDto dto,
            string userId);

        Task UpdateAsync(
            UpdateReservationDto dto);

        Task DeleteAsync(int id);
    }
}