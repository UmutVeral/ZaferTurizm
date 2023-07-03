using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Validators;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public class TicketService : CrudService<TicketDto, TicketSummary, Ticket>, ITicketService
    {
        public TicketService(TourDbContext context, GenericValidator<Ticket> validator)
            : base(context, validator)
        {
        }

        protected override Expression<Func<Ticket, TicketDto>> DtoMapper =>
            entity => new TicketDto()
            {
                Id=entity.Id,
                BusTripId = entity.BusTripId,
                Price = entity.Price,
                SeatNumber = entity.SeatNumber,
                PassengerFirstName = entity.Passenger.FirstName,
                PassengerLastName=entity.Passenger.LastName,
                PassengerIdentityNumber=entity.Passenger.LastName,
                
                

            };

        protected override Expression<Func<Ticket, TicketSummary>> SummaryMapper =>
            entity => new TicketSummary()
            {
                Id=entity.Id,
                BusTripId=entity.BusTripId,
                SeatNumber=entity.SeatNumber,
                Price=entity.Price,
                PassengerFirstName = entity.Passenger.FirstName,
                PassengerLastName=entity.Passenger.LastName,
                PassengerIdentityNumber=entity.Passenger.IdentityNumber,
                
            };

        protected override Ticket MapToEntity(TicketDto entity)
        {
            return new Ticket()
            {
                Id=entity.Id,
                BusTripId = entity.BusTripId,
                PassengerId=entity.PassengerId,
                SeatNumber = entity.SeatNumber,
                Price = entity.Price,
                


            };
        }

        public override CommandResult Create(TicketDto model)
        {
            try
            {
                var passenger = _dbContext.Passengers
                    .FirstOrDefault(pass => pass.FirstName == model.PassengerFirstName &&
                                            pass.LastName == model.PassengerLastName &&
                                            pass.IdentityNumber == model.PassengerIdentityNumber);

                if (passenger == null)
                {
                    passenger = new Passenger()
                    {
                        FirstName = model.PassengerFirstName,
                        LastName = model.PassengerLastName,
                        IdentityNumber = model.PassengerIdentityNumber,
                        Gender = Gender.None
                    };

                    _dbContext.Passengers.Add(passenger);
                    _dbContext.SaveChanges();
                }

                var ticketQuery = _dbContext.Tickets.FirstOrDefault(x => x.SeatNumber == model.SeatNumber && x.BusTripId == model.BusTripId);
                if (ticketQuery != null)
                {
                    return CommandResult.Failure("Koltuk daha önce satılmıştır !!");
                }

                var ticket = new Ticket()
                {
                    BusTripId = model.BusTripId,
                    PassengerId = passenger.Id,
                    Price = model.Price,
                    SeatNumber = model.SeatNumber,
                   
                    

                };

                _dbContext.Tickets.Add(ticket);
                _dbContext.SaveChanges();

                return CommandResult.Success("Bilet başarıyla kaydedildi. Bileti yazdırmak için alttaki Yazdır Butonuna Basınız.");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure();
            }

        }
        


    }
}
