using CafeManagement.Core.Entities;
using CafeManagement.Core.Interfaces.Repositories;
using CafeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeManagement.Infrastructure.Repositories
{
    public class ReservationRepository
        : GenericRepository<Reservation>, IReservationRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservationRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetAllWithTableAsync()
        {
            return await _context.Reservations
                .Include(r => r.Table)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetUserReservationsAsync(
            string userId)
        {
            return await _context.Reservations
                .Include(r => r.Table)
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }

        public async Task<Reservation?> GetByIdWithTableAsync(int id)
        {
            return await _context.Reservations
                .Include(r => r.Table)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Reservation?> GetByIdWithTableForUserAsync(
            int id,
            string userId)
        {
            return await _context.Reservations
                .Include(r => r.Table)
                .FirstOrDefaultAsync(r =>
                    r.Id == id &&
                    r.UserId == userId);
        }

        public async Task<bool> HasConflictAsync(
            int tableId,
            DateOnly reservationDate,
            TimeOnly startTime,
            TimeOnly endTime)
        {
            return await _context.Reservations.AnyAsync(r =>
                r.TableId == tableId &&
                r.ReservationDate == reservationDate &&
                startTime < r.EndTime &&
                endTime > r.StartTime
            );
        }

        public async Task<bool> HasConflictForAnotherReservationAsync(
            int reservationId,
            int tableId,
            DateOnly reservationDate,
            TimeOnly startTime,
            TimeOnly endTime)
        {
            return await _context.Reservations.AnyAsync(r =>
                r.Id != reservationId &&
                r.TableId == tableId &&
                r.ReservationDate == reservationDate &&
                startTime < r.EndTime &&
                endTime > r.StartTime
            );
        }
    }
}