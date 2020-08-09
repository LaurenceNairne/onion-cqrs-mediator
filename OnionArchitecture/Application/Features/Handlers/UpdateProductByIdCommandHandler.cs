using Application.Features.Commands;
using Application.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers
{
    public class UpdateProductByIdCommandHandler : IRequestHandler<UpdateProductByIdCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductByIdCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateProductByIdCommand command, CancellationToken cancellationToken)
        {
            var product = _context.Products.Where(a => a.Id == command.Id).FirstOrDefault();

            if (product == null)
                return default;

            else
            {
                product.Barcode = command.Barcode;
                product.Name = command.Name;
                product.Rate = command.Rate;
                product.Description = command.Description;

                await _context.SaveChangesAsync();

                return product.Id;
            }
        }
    }
}
