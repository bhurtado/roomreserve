using System;

namespace ConferenceRoomReservation.Domain.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string ReserversName { get; set; }
        
        public string ReserversEmail { get; set; }

        public string ReserversContactNumber { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int RoomId { get; set; }
    }
}
