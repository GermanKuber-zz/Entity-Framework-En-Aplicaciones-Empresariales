using Market.Core.Enum;

namespace Market.Core.Interfaces
{
    public interface IStateObject
    {
        ObjectState State { get; }
    }
}
