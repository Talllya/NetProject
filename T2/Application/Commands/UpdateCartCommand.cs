using MediatR;

namespace Application.Commands
{
    public class UpdateCartCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Price { get; set; }
        public DateTime ShoppingTime { get; set; }
    }
}
