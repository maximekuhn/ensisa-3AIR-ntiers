using JeBalance.Domain.Services;

namespace JeBalance.Domain.Tests.Drivers;

public class IdOpaqueProviderDriver: IdOpaqueProvider
{
    public Guid IdOpaque { get; set; }
    
    public Guid GetOpaqueId()
    {
        return IdOpaque;
    }
}