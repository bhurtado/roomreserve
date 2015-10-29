using System;
using System.Collections.Generic;
using Ninject;
using System.Web.Mvc;
using Moq;

namespace ConferenceRoomReservation.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private List<Domain.Models.Reservation> mockReservations = new List<Domain.Models.Reservation>
        {
            new Domain.Models.Reservation {Id = 1, ReserversContactNumber = "6156", ReserversEmail = "Whale.com", ReserversName = "The Whale", RoomId = 1, StartTime = new DateTime(2015, 11, 23, 13, 00, 00), EndTime = new DateTime(2015, 11, 23, 14, 00, 00)},
            new Domain.Models.Reservation {Id = 2, ReserversContactNumber = "5000", ReserversEmail = "TigerShark.com", ReserversName = "Tiger Shark", RoomId = 99, StartTime = new DateTime(2015, 11, 21, 10, 00, 00), EndTime = new DateTime(2015, 11, 21, 11, 00, 00)},
            new Domain.Models.Reservation {Id = 3, ReserversContactNumber = "5151", ReserversEmail = "Oyster.com", ReserversName = "Oy,Ster", RoomId = 88, StartTime = new DateTime(2015, 11, 22, 12, 30, 00), EndTime = new DateTime(2015, 11, 21, 13, 00, 00)}
        };

        private void AddBindings()
        {
            Mock<Domain.Abstracts.IReservationRepository> mock = new Mock<Domain.Abstracts.IReservationRepository>();
            mock.Setup(m => m.GetAllReservationsForUser(null)).Returns(mockReservations);
            for (int i = 1; i <= mockReservations.Count; i++)
            {
                mock.Setup(m => m.GetReservationById(i)).Returns(mockReservations.Find(x => x.Id == i));
            }
            
            
            kernel.Bind<Domain.Abstracts.IReservationRepository>().ToConstant(mock.Object);
        }
    }
}
