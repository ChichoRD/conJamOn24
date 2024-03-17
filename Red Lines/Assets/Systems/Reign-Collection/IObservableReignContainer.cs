using ReignSystem;
using System;

namespace ReignCollectionSystem
{
    public interface IObservableReignContainer
    {
        event Action<Reign> ReignModified;
        event Action<Reign> ReignModificationApplied;
    }
}