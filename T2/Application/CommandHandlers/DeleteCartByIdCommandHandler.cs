using Application.Commands;
using Domain.Repositories;
using MediatR;


namespace Application.CommandHandlers
{
    public class DeleteCartByIdCommandHandler : IRequestHandler<DeleteCartByIdCommand>
    {
        private readonly ICartRepository repository;

        public DeleteCartByIdCommandHandler(ICartRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(DeleteCartByIdCommand request, CancellationToken cancellationToken)
        {
            await repository.DeleteAsync(request.Id);
        }
    }
}
