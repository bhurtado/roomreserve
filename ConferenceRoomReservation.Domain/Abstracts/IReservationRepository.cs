using ConferenceRoomReservation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceRoomReservation.Domain.Abstracts
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAllReservationsForUser(string reserverId);

        Reservation GetReservationById(int id);

        void SaveReservation(Reservation reservation);
    }
}
