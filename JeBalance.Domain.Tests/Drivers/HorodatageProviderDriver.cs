using JeBalance.Domain.Services;

namespace JeBalance.Domain.Tests.Drivers;

public class HorodatageProviderDriver : IHorodatageProvider
{
    public DateTime DateTime { get; set; }

    public DateTime GetNow()
    {
        return DateTime;
    }
}