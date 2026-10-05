using System;
using System.Collections.Generic;
using System.Text;

namespace Part2_HotelReservationSystem
{
    public class Reservation
    {
        public int ReservationId { get; }
        public DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }

        internal Room Room { get; }

        public ReservationStatus Status { get; private set; }

        public decimal TotalCost
        {
            get
            {
                int nights = (CheckOutDate - CheckInDate).Days;
                return nights * Room.NightlyRate;
            }
        }

        internal Reservation(
            int reservationId,
            DateTime checkInDate,
            DateTime checkOutDate,
            Room room)
        {
            if (reservationId <= 0)
                throw new ArgumentException("Reservation ID must be positive.");

            if (checkOutDate <= checkInDate)
                throw new ArgumentException(
                    "Check-out date must be after check-in date.");

            if (room == null)
                throw new ArgumentNullException(nameof(room));

            if (room.IsUnderMaintenance)
                throw new InvalidOperationException(
                    "Cannot make a reservation for a room under maintenance.");

            ReservationId = reservationId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Room = room;
            Status = ReservationStatus.Pending;
        }

        public void Confirm()
        {
            if (Status != ReservationStatus.Pending)
                throw new InvalidOperationException(
                    "Only pending reservations can be confirmed.");

            Status = ReservationStatus.Confirmed;
        }

        public void CheckIn()
        {
            if (Status != ReservationStatus.Confirmed)
                throw new InvalidOperationException(
                    "Only confirmed reservations can be checked in.");

            Status = ReservationStatus.CheckedIn;
        }

        public void CheckOut()
        {
            if (Status != ReservationStatus.CheckedIn)
                throw new InvalidOperationException(
                    "Only checked-in reservations can be checked out.");

            Status = ReservationStatus.CheckedOut;
        }

        public void Cancel()
        {
            if (Status != ReservationStatus.Pending &&
                Status != ReservationStatus.Confirmed)
            {
                throw new InvalidOperationException(
                    "Only pending or confirmed reservations can be cancelled.");
            }

            Status = ReservationStatus.Cancelled;
        }
    }
}
