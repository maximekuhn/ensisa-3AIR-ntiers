using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Commands;

public class CreateDenunciationCommand: IRequest<int>
{
 
    public Denunciation Denunciation { get; }

    public CreateDenunciationCommand(OffenseType offenseType, string evasionCountry)
    {
        Denunciation = new Denunciation(offenseType, evasionCountry);
    }
}