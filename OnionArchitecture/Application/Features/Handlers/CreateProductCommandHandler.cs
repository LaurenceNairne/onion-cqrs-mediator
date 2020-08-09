using Application.Features.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product 
            {
                Barcode = command.Barcode,
                Name = command.Name,
                Rate = command.Rate,
                Description = command.Description,            
            };

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return product.Id;
        }
    }
}
