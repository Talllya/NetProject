using Application.Queries;
using AutoMapper;
using Domain.Repositories;
using MediatR;


namespace Application.QueryHandlers
{

    public class GetCartsQueryHandler : IRequestHandler<GetCartsQuery, List<CartDTO>>
    {
        private readonly ICartRepository repository;
        private readonly IMapper mapper;

        public GetCartsQueryHandler(ICartRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<List<CartDTO>> Handle(GetCartsQuery request, CancellationToken cancellationToken)
        {
            var carts = await repository.GetAllAsync();
            return mapper.Map<List<CartDTO>>(carts);
        }
    }
}
