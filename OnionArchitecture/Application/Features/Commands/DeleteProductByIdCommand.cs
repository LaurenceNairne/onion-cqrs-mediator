using MediatR;

namespace Application.Features.Commands
{
    public class DeleteProductByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
