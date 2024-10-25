using MediatR;

namespace Application.Commands
{
    public class DeleteCartByIdCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
