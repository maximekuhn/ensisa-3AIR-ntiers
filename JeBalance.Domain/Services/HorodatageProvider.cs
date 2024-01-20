namespace JeBalance.Domain.Services;

public class HorodatageProvider : IHorodatageProvider
{
    public DateTime GetNow()
    {
        return DateTime.Now;
    }
}