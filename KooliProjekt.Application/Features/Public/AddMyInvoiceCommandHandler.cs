using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Public
{
    public class AddMyInvoiceCommandHandler : IRequestHandler<AddMyInvoiceCommand, OperationResult<int?>>, ITransactional
    {
        private readonly IUserProvider _userProvider;
        private readonly ApplicationDbContext _dbContext;

        public AddMyInvoiceCommandHandler(IUserProvider userProvider, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _userProvider = userProvider;
        }

        public async Task<OperationResult<int?>> Handle(AddMyInvoiceCommand request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<int?>();
            var userId = _userProvider.UserId();

            if (userId == null)
            {
                response.AddError("User not found");
                return response;
            }

            var invoice = new Invoice
            {
                InvoiceDate = request.InvoiceDate,
                Duedate = request.Duedate,
                UserId = userId.Value,
                IsPaid = false
            };

            _dbContext.Invoices.Add(invoice);
            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = invoice.Id;
            return response;
        }
    }
}
