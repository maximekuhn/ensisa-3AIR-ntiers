using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Commands;

public class CreateReponseCommand : IRequest<int>
{
    public CreateReponseCommand(TypeReponse typeReponse, Double? retribution)
    {
        TypeReponse = typeReponse;
        Retribution = retribution;
    }
    
    public TypeReponse TypeReponse { get; }
    public Double? Retribution { get; }
}