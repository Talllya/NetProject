using Application.Commands;
using AutoMapper;
using Domain.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.CommandHandlers
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, Guid>
    {
        private readonly ICartRepository repository;
        private readonly IMapper mapper;

        public CreateCartCommandHandler(ICartRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Guid> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = mapper.Map<Cart>(request);
            return await repository.AddAsync(cart);
        }
    }
}
