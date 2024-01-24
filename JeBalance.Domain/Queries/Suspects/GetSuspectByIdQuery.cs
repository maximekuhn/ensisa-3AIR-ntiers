using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Queries.Suspects;

public class GetSuspectByIdQuery : IRequest<Suspect>
{
    public GetSuspectByIdQuery(int suspectId)
    {
        SuspectId = suspectId;
    }

    public int SuspectId { get; }
}