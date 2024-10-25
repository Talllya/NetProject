using MediatR;

namespace Application.Queries
{
    public class GetCartQuery : IRequest<CartDTO>
    {
        public Guid Id { get; set; }
    }
}
