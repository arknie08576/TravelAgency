using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain;
using TravelAgency.ApplicationServices.API.Domain.Models;
using TravelAgency.DataAccess;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.ApplicationServices.API.Handlers
{
    public class GetReservationsHandler : IRequestHandler<GetReservationsRequest, GetReservationsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Reservation> reservationRepository;
        private readonly IMapper mapper;
        public GetReservationsHandler(IRepository<DataAccess.Entities.Reservation> reservationRepository, IMapper mapper)
        {
            this.reservationRepository = reservationRepository;
            this.mapper = mapper;

        }
        public async Task<GetReservationsResponse> Handle(GetReservationsRequest request, CancellationToken cancellationToken)
        {
            var reservations = await this.reservationRepository.GetAll();
            var mappedReservation = this.mapper.Map<List<Domain.Models.Reservation>>(reservations);

            var response = new GetReservationsResponse()
            {
                Data = mappedReservation

            };
            return response;

        }


    }
}
