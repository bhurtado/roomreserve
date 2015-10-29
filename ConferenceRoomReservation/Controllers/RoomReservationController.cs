using ConferenceRoomReservation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConferenceRoomReservation.Controllers
{
    public class RoomReservationController : Controller
    {
        private Domain.Abstracts.IReservationRepository repository;
        public RoomReservationController(Domain.Abstracts.IReservationRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public ActionResult Edit(int reserveId)
        {
            if (reserveId == 0)
                return View(new Reservation());

            
            return View(repository.GetReservationById(reserveId));
        }


        [HttpGet]
        public ActionResult Reserve()
        {
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Update(Reservation reservation)
        {
            if (true)
                return View("Edit", reservation);

            // process
            return View("Complete", reservation); ;
        }

        [HttpGet]
        public ActionResult Lookup()
        {
            return View();
        }

                        
        [HttpPost]
        public ActionResult List(Reservation reservation)
        {
            IEnumerable<Reservation> reserves = repository.GetAllReservationsForUser(null);
            return View(reserves);
        }
    }
}