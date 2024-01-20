using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Queries;

public class GetSuspectByIdQuery: IRequest<Suspect>
{
    public int SuspectId { get; }

    public GetSuspectByIdQuery(int suspectId)
    {
        SuspectId = suspectId;
    }
}