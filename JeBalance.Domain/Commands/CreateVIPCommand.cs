using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;
using MediatR;

namespace JeBalance.Domain.Commands;

public class CreateVIPCommand : IRequest<int>
{
    public CreateVIPCommand(Nom nom, Nom prenom, Adresse adresse)
    {
        Vip = new VIP(nom, prenom, adresse);
    }

    public VIP Vip { get; }
}