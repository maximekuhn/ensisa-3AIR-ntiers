using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.Model;

public class Denunciation : Entity
{
    public Denunciation(int id) : base(id)
    {
    }

    public Denunciation(OffenseType offenseType, string? evasionCountry) : base(0)
    {
        if (offenseType == OffenseType.TaxEvasion && evasionCountry == null)
            throw new ApplicationException("Tax evasion offense must have an evasion country");
        OffenseType = offenseType;
        EvasionCountry = evasionCountry;
        Status = DenunciationStatus.WaitingForResponse;
    }

    public OffenseType OffenseType { get; }
    public string? EvasionCountry { get; }
    public DenunciationStatus Status { get; }
}