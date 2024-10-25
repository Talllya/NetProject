using Application.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;


namespace Application.CommandHandlers
{
    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand>
    {

        private readonly ICartRepository repository;
        private readonly IMapper mapper;

        public UpdateCartCommandHandler(ICartRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public Task Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = mapper.Map<Cart>(request);
            return repository.UpdateAsync(cart);
        }
    }
}
