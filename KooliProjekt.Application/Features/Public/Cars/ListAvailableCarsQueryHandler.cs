using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Public.Cars
{
    public class ListAvailableCarsQueryHandler : IRequestHandler<ListAvailableCarsQuery, OperationResult<PagedResult<AvailableCar>>>
    {
        private readonly IUserProvider _userProvider;
        private readonly ApplicationDbContext _dbContext;

        public ListAvailableCarsQueryHandler(IUserProvider userProvider, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _userProvider = userProvider;
        }
        public async Task<OperationResult<PagedResult<AvailableCar>>> Handle(ListAvailableCarsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<AvailableCar>>();

            var now = DateTime.Now;

            response.Value = await _dbContext.Cars
                .Where(car => !car.Bookings.Any(booking =>
                    booking.Started <= now &&
                    booking.Finished > now))
                .OrderBy(car => car.Id)
                .Select(car => new AvailableCar
                {
                    CarId = car.Id,
                    RegistrationNumber = car.RegistrationNumber,
                    CarModelName = car.CarModel.Name
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
