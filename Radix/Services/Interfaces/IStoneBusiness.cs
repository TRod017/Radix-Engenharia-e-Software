using Entity;
using GatewayApiClient.DataContracts.EnumTypes;

namespace Services.Interfaces
{
    public interface IStoneBusiness
    {
        string CartaoDeCredito(Pedido pedido);
    }
}
