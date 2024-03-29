using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Queries.Denonciations;

public class GetDenonciationsNonTraiteesQueryHandler : IRequestHandler<GetDenonciationsNonTraiteesQuery, (
    IEnumerable<Denonciation> Results, int Total)>
{
    private readonly DenonciationRepository _denonciationRepository;

    public GetDenonciationsNonTraiteesQueryHandler(DenonciationRepository denonciationRepository)
    {
        _denonciationRepository = denonciationRepository;
    }

    public async Task<(IEnumerable<Denonciation> Results, int Total)> Handle(GetDenonciationsNonTraiteesQuery request,
        CancellationToken cancellationToken)
    {
        var pagination = request.Pagination;
        var findDenonciationsNonTraiteesSpecification = new FindDenonciationsNonTraiteesSpecification();
        var (denonciations, total) = await _denonciationRepository.GetSortedDenonciationsNonTraitees(pagination.Limit,
            pagination.Offset,
            findDenonciationsNonTraiteesSpecification);
        return (denonciations, total);
    }
}