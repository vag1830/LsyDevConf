using Demo.Application.Boundaries.Database;
using Demo.Application.Domain;

namespace Demo.Application.Airports.GetAll
{
    public class GetAllUseCase : IGetAllUseCase
    {
        private readonly IAirportRepository _repository;

        public GetAllUseCase(IAirportRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Airport>> Execute()
        {
            return await _repository.GetAll();
        }
    }
}
