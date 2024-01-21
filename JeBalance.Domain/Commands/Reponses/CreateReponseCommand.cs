using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Commands.Reponses;

public class CreateReponseCommand : IRequest<int>
{
    public CreateReponseCommand(TypeReponse typeReponse, double? retribution, Guid denonciationId)
    {
        Reponse = new Reponse(typeReponse, retribution);
        DenonciationId = denonciationId;
        TypeReponse = typeReponse;
        Retribution = retribution;
    }

    public Reponse Reponse { get; }
    public TypeReponse TypeReponse { get; }
    public double? Retribution { get; }
    public Guid DenonciationId { get; }
}