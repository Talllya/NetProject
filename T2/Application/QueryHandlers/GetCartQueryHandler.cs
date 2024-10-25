using Application.Commands;
using Application.Queries;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.QueryHandlers
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, CartDTO>
    {
        private readonly ICartRepository repository;
        private readonly IMapper mapper;

        public GetCartQueryHandler(ICartRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<CartDTO> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var cart = await  repository.GetByIdAsync(request.Id); 
            return mapper.Map<CartDTO>(cart);
        }
    }
}
