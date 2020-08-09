using Domain.Entities;
using MediatR;

namespace Application.Features.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}