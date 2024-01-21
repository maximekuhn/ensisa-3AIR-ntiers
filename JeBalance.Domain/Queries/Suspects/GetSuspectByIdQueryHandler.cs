using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Queries.Suspects;

public class GetSuspectByIdQueryHandler : IRequestHandler<GetSuspectByIdQuery, Suspect>
{
    private readonly SuspectRepository _suspectRepository;

    public GetSuspectByIdQueryHandler(SuspectRepository suspectRepository)
    {
        _suspectRepository = suspectRepository;
    }

    public async Task<Suspect> Handle(GetSuspectByIdQuery request, CancellationToken cancellationToken)
    {
        var id = request.SuspectId;
        var suspect = await _suspectRepository.GetOne(id);
        return suspect;
    }
}