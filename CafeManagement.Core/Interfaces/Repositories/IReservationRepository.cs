using CafeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeManagement.Core.Interfaces.Repositories
{
    public interface IReservationRepository : IGenericRepository<Reservation>
    {
        Task<IEnumerable<Reservation>> GetAllWithTableAsync();

        Task<IEnumerable<Reservation>> GetUserReservationsAsync(
            string userId);

        Task<Reservation?> GetByIdWithTableAsync(int id);

        Task<Reservation?> GetByIdWithTableForUserAsync(
            int id,
            string userId);

        Task<bool> HasConflictAsync(
            int tableId,
            DateOnly reservationDate,
            TimeOnly startTime,
            TimeOnly endTime);

        Task<bool> HasConflictForAnotherReservationAsync(
            int reservationId,
            int tableId,
            DateOnly reservationDate,
            TimeOnly startTime,
            TimeOnly endTime);
    }
}