using CafeManagement.Core.DTOs.Reservation;
using CafeManagement.Core.Entities;
using CafeManagement.Core.Interfaces.Repositories;
using CafeManagement.Core.Interfaces.Services;
using CafeManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeManagement.Infrastructure.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ITableRepository _tableRepository;

        public ReservationService(
            IReservationRepository reservationRepository,
            ITableRepository tableRepository)
        {
            _reservationRepository = reservationRepository;
            _tableRepository = tableRepository;
        }

        public async Task<IEnumerable<ReservationDto>> GetAllAsync()
        {
            var reservations =
                await _reservationRepository.GetAllWithTableAsync();

            return reservations.Select(r => new ReservationDto
            {
                Id = r.Id,
                ReservationDate = r.ReservationDate,
                StartTime = r.StartTime,
                EndTime = r.EndTime,
                NumberOfGuests = r.NumberOfGuests,
                Status = r.Status.ToString(),
                TableId = r.TableId,
                TableNumber = r.Table.TableNumber
            });
        }

        public async Task<IEnumerable<ReservationDto>> GetUserReservationsAsync(
            string userId)
        {
            var reservations =
                await _reservationRepository
                    .GetUserReservationsAsync(userId);

            return reservations.Select(r => new ReservationDto
            {
                Id = r.Id,
                ReservationDate = r.ReservationDate,
                StartTime = r.StartTime,
                EndTime = r.EndTime,
                NumberOfGuests = r.NumberOfGuests,
                Status = r.Status.ToString(),
                TableId = r.TableId,
                TableNumber = r.Table.TableNumber
            });
        }

        public async Task<ReservationDto?> GetByIdAsync(int id)
        {
            var reservation =
                await _reservationRepository.GetByIdWithTableAsync(id);

            if (reservation == null)
                return null;

            return new ReservationDto
            {
                Id = reservation.Id,
                ReservationDate = reservation.ReservationDate,
                StartTime = reservation.StartTime,
                EndTime = reservation.EndTime,
                NumberOfGuests = reservation.NumberOfGuests,
                Status = reservation.Status.ToString(),
                TableId = reservation.TableId,
                TableNumber = reservation.Table.TableNumber
            };
        }

        public async Task<ReservationDto?> GetByIdForUserAsync(
            int id,
            string userId)
        {
            var reservation =
                await _reservationRepository
                    .GetByIdWithTableForUserAsync(id, userId);

            if (reservation == null)
                return null;

            return new ReservationDto
            {
                Id = reservation.Id,
                ReservationDate = reservation.ReservationDate,
                StartTime = reservation.StartTime,
                EndTime = reservation.EndTime,
                NumberOfGuests = reservation.NumberOfGuests,
                Status = reservation.Status.ToString(),
                TableId = reservation.TableId,
                TableNumber = reservation.Table.TableNumber
            };
        }

        public async Task AddAsync(
            CreateReservationDto dto,
            string userId)
        {
            var table =
                await _tableRepository.GetByIdAsync(dto.TableId);

            if (table == null)
            {
                throw new Exception("Table not found.");
            }

            if (dto.NumberOfGuests > table.Capacity)
            {
                throw new Exception(
                    "Number of guests exceeds table capacity.");
            }

            if (dto.StartTime >= dto.EndTime)
            {
                throw new Exception(
                    "End time must be after start time.");
            }

            if (dto.ReservationDate <
                DateOnly.FromDateTime(DateTime.Today))
            {
                throw new Exception(
                    "Reservation date cannot be in the past.");
            }

            var hasConflict =
                await _reservationRepository.HasConflictAsync(
                    dto.TableId,
                    dto.ReservationDate,
                    dto.StartTime,
                    dto.EndTime);

            if (hasConflict)
            {
                throw new Exception(
                    "This table is already reserved at this time.");
            }

            var reservation = new Reservation
            {
                ReservationDate = dto.ReservationDate,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                NumberOfGuests = dto.NumberOfGuests,
                TableId = dto.TableId,

                UserId = userId,

                Status = ReservationStatus.Pending,

                CreatedAt = DateTime.UtcNow
            };

            await _reservationRepository.AddAsync(reservation);

            await _reservationRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateReservationDto dto)
        {
            var reservation =
                await _reservationRepository.GetByIdAsync(dto.Id);

            if (reservation == null)
            {
                throw new Exception("Reservation not found.");
            }

            var table =
                await _tableRepository.GetByIdAsync(dto.TableId);

            if (table == null)
            {
                throw new Exception("Table not found.");
            }

            if (dto.NumberOfGuests > table.Capacity)
            {
                throw new Exception(
                    "Number of guests exceeds table capacity.");
            }

            if (dto.StartTime >= dto.EndTime)
            {
                throw new Exception(
                    "End time must be after start time.");
            }

            if (dto.ReservationDate <
                DateOnly.FromDateTime(DateTime.Today))
            {
                throw new Exception(
                    "Reservation date cannot be in the past.");
            }

            var hasConflict =
                await _reservationRepository
                    .HasConflictForAnotherReservationAsync(
                        dto.Id,
                        dto.TableId,
                        dto.ReservationDate,
                        dto.StartTime,
                        dto.EndTime);

            if (hasConflict)
            {
                throw new Exception(
                    "This table is already reserved at this time.");
            }

            reservation.ReservationDate =
                dto.ReservationDate;

            reservation.StartTime =
                dto.StartTime;

            reservation.EndTime =
                dto.EndTime;

            reservation.NumberOfGuests =
                dto.NumberOfGuests;

            reservation.TableId =
                dto.TableId;

            reservation.Status =
                dto.Status;

            _reservationRepository.Update(reservation);

            await _reservationRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reservation =
                await _reservationRepository.GetByIdAsync(id);

            if (reservation == null)
            {
                throw new Exception("Reservation not found.");
            }

            _reservationRepository.Delete(reservation);

            await _reservationRepository.SaveChangesAsync();
        }
    }
}