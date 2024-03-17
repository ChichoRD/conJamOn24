using ReignBorderSystem.Factory;
using ReignSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ReignBorderSystem.Placer
{
    internal class PlayerInputtedBorderPlacer : MonoBehaviour
    {
        [SerializeField]
        private InputActionReference _borderPlacingActionReference;

        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private BorderPlacer _borderPlacer;
        [SerializeField]
        private GameObject _borderFactoryRoot;
        private IBorderFactory _borderFactory;

        [SerializeField]
        [Min(0.0f)]
        private float _borderDetectionRadius;

        [SerializeField]
        private LayerMask _borderLayerMask;

        private void Awake()
        {
            _borderFactory = _borderFactoryRoot.GetComponentInChildren<IBorderFactory>();
            _borderPlacingActionReference.action.performed += OnBorderPlacingPerformed;
        }

        private void OnEnable()
        {
            _borderPlacingActionReference.action.Enable();
        }

        private void OnDisable()
        {
            _borderPlacingActionReference.action.Disable();
        }

        private void OnDestroy()
        {
            _borderPlacingActionReference.action.performed -= OnBorderPlacingPerformed;
        }

        private void OnBorderPlacingPerformed(InputAction.CallbackContext context)
        {
            Vector2 mousePosition = context.ReadValue<Vector2>();
            Vector2 worldPosition = _camera.ScreenToWorldPoint(mousePosition);
            Collider2D hit = Physics2D.OverlapCircle(worldPosition, _borderDetectionRadius, _borderLayerMask);
            _ = hit != null 
                && _borderPlacer.TryCreateAndPlace(hit.transform, _borderFactory);
        }
    }
}