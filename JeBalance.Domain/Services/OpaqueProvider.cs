

namespace JeBalance.Domain.Services;

public class OpaqueProvider: IdOpaqueProvider
{

    public Guid GetOpaqueId()
    {
        return Guid.NewGuid();
    }
}