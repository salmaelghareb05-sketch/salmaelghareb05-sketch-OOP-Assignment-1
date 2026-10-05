namespace Part2_HotelReservationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Room room101 = new Room(101, RoomType.Single, 100m);
            Room room202 = new Room(202, RoomType.Double, 150m);

            // Create guests
            Guest guest1 = new Guest(
                1,
                "Mona Ahmed",
                "01012345678");

            Guest guest2 = new Guest(
                2,
                "Omar Ali",
                "01198765432");

            ReservationManager manager = new ReservationManager();

            // Create reservation
            Reservation reservation1 = manager.CreateReservation(
                1001,
                guest1,
                room101,
                new DateTime(2026, 10, 5),
                new DateTime(2026, 10, 8));

            Console.WriteLine("Reservation created successfully.");
            Console.WriteLine($"Reservation ID: {reservation1.ReservationId}");
            Console.WriteLine($"Guest: {guest1.FullName}");
            Console.WriteLine($"Room: {reservation1.Room.RoomNumber}");
            Console.WriteLine($"Status: {reservation1.Status}");
            Console.WriteLine($"Total Cost: {reservation1.TotalCost}");

            // Confirm reservation
            reservation1.Confirm();

            Console.WriteLine();
            Console.WriteLine($"Status after confirmation: {reservation1.Status}");

            // Check in
            reservation1.CheckIn();

            Console.WriteLine($"Status after check-in: {reservation1.Status}");


            // Test double booking
            Console.WriteLine();
            Console.WriteLine("Testing double booking...");

            try
            {
                manager.CreateReservation(
                    1002,
                    guest2,
                    room101,
                    new DateTime(2026, 10, 6),
                    new DateTime(2026, 10, 9));
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Rejected: {ex.Message}");
            }




            // Check out
            reservation1.CheckOut();

            Console.WriteLine($"Status after check-out: {reservation1.Status}");

            // Display guest reservation history
            Console.WriteLine();
            Console.WriteLine($"Reservations for {guest1.FullName}:");

            foreach (Reservation reservation in guest1.Reservations)
            {
                Console.WriteLine(
                    $"Reservation {reservation.ReservationId} - " +
                    $"Room {reservation.Room.RoomNumber} - " +
                    $"Status: {reservation.Status} - " +
                    $"Total: {reservation.TotalCost}");
            }

            // Test maintenance
            Console.WriteLine();
            room202.StartMaintenance();

            Console.WriteLine(
                $"Room {room202.RoomNumber} under maintenance: " +
                $"{room202.IsUnderMaintenance}");

            room202.EndMaintenance();

            Console.WriteLine(
                $"Room {room202.RoomNumber} under maintenance: " +
                $"{room202.IsUnderMaintenance}");

            // Update room price
            room202.UpdateNightlyRate(200m);

            Console.WriteLine(
                $"New nightly rate for room {room202.RoomNumber}: " +
                $"{room202.NightlyRate}");

           

        }
    }
}
