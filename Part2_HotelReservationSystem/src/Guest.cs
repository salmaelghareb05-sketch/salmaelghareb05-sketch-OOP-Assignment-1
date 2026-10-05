using System;
using System.Collections.Generic;
using System.Text;

namespace Part2_HotelReservationSystem
{
    public class Guest
    {

        private readonly List<Reservation> _reservations = new();

        public int GuestId { get; }
        public string FullName { get; }
        public string PhoneNumber { get; }

        internal IReadOnlyList<Reservation> Reservations =>
            _reservations.AsReadOnly();

        public Guest(int guestId, string fullName, string phoneNumber)
        {
            if (guestId <= 0)
                throw new ArgumentException("Guest ID must be positive.");

            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name is required.");

            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number is required.");

            GuestId = guestId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        internal void AddReservation(Reservation reservation)
        {
            if (reservation == null)
                throw new ArgumentNullException(nameof(reservation));

            _reservations.Add(reservation);
        }
    }
}
