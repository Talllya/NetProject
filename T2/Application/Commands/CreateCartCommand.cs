using MediatR;

namespace Application.Commands
{
    public class CreateCartCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Price { get; set; }
        public DateTime ShoppingTime { get; set; }
    }
}
