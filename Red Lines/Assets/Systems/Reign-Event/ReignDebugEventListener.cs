using ReignCollectionSystem;
using ReignSystem;
using UnityEngine;

namespace ReignEventSystem
{
    internal class ReignDebugEventListener : MonoBehaviour
    {
        private IObservableReignContainer _observable;

        private void Awake()
        {
            _observable = GetComponentInChildren<IObservableReignContainer>();
            _observable.ReignModified += OnReignModified;
        }

        private void OnDestroy()
        {
            _observable.ReignModified -= OnReignModified;
        }

        private void OnReignModified(Reign reign)
        {
            Debug.Log($"Reign modified: {reign.AsString()}");
        }
    }
}