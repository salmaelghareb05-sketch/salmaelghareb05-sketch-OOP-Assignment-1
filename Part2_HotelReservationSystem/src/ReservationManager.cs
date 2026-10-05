using System;
using System.Collections.Generic;
using System.Text;

namespace Part2_HotelReservationSystem
{

    public class ReservationManager
    {
        private readonly List<Reservation> _reservations = new();

        public IReadOnlyList<Reservation> Reservations =>
            _reservations.AsReadOnly();

        internal Reservation CreateReservation(
            int reservationId,
            Guest guest,
            Room room,
            DateTime checkInDate,
            DateTime checkOutDate)
        {
            if (guest == null)
                throw new ArgumentNullException(nameof(guest));

            if (room == null)
                throw new ArgumentNullException(nameof(room));

            if (checkOutDate <= checkInDate)
                throw new ArgumentException(
                    "Check-out date must be after check-in date.");

            if (room.IsUnderMaintenance)
                throw new InvalidOperationException(
                    "Cannot reserve a room under maintenance.");

            foreach (Reservation existing in _reservations)
            {
                if (existing.ReservationId == reservationId)
                    throw new InvalidOperationException(
                        "Reservation ID already exists.");

                bool isActive =
                    existing.Status != ReservationStatus.Cancelled &&
                    existing.Status != ReservationStatus.CheckedOut;

                bool sameRoom = existing.Room == room;

                bool datesOverlap =
                    checkInDate < existing.CheckOutDate &&
                    checkOutDate > existing.CheckInDate;

                if (isActive && sameRoom && datesOverlap)
                {
                    throw new InvalidOperationException(
                        "The room is already booked for this period.");
                }
            }

            Reservation reservation = new Reservation(
                reservationId,
                checkInDate,
                checkOutDate,
                room);

            _reservations.Add(reservation);

            guest.AddReservation(reservation);

            return reservation;
        }
    }




}
