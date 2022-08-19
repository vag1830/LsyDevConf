using Demo.Application.Boundaries.Database;
using Demo.Application.Domain;

namespace Demo.Application.Airports.GetById
{
    public class GetByIdUseCase : IGetByIdUseCase
    {
        private readonly IAirportRepository _repository;

        public GetByIdUseCase(IAirportRepository repository)
        {
            _repository = repository;
        }

        public async Task<Airport> Execute(int id) {

            var result = await _repository.GetById(id);

            if (result == null)
            {
                throw new Exception($"Airport with Id: {id}, was not found");
            }

            return result;
        }
    }
}
