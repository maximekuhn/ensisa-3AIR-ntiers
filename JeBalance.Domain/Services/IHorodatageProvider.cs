namespace JeBalance.Domain.Services;

public interface IHorodatageProvider
{
    DateTime GetNow();
}