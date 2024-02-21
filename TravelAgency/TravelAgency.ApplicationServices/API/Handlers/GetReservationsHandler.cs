using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain;
using TravelAgency.DataAccess;

namespace TravelAgency.ApplicationServices.API.Handlers
{
    public class GetReservationsHandler : IRequestHandler<GetReservationsRequest, GetReservationsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Reservation> ReservationRepository;
        public GetReservationsHandler(IRepository<DataAccess.Entities.Reservation> ReservationRepository)
        {
            this.ReservationRepository = ReservationRepository;
        }
        public Task<GetReservationsResponse> Handle(GetReservationsRequest request, CancellationToken cancellationToken)
        {
            var Reservations = this.ReservationRepository.GetAll();
            var domainReservations = Reservations.Select(x => new Domain.Models.Reservation()
            {
                Id = x.Id,
                AdultsNumber = x.AdultsNumber,
                KidsNumber = x.KidsNumber,
                PricePaid = x.PricePaid



            });
            var response = new GetReservationsResponse()
            {
                Data = domainReservations.ToList()

            };
            return Task.FromResult(response);

        }
    }
}
