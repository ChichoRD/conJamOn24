using ReignSystem;
using UnityEngine;
using UnityEngine.UI;

namespace ReignBorderSystem.Factory
{
    internal class SelectorBorderFactory : MonoBehaviour, IBorderFactory
    {
        [SerializeField]
        private Button[] _buttons;

        private IBorderFactory _activeFactory;

        private void Awake()
        {
            foreach (var button in _buttons)
                button.onClick.AddListener(() => OnButtonClicked(button));
        }

        private void OnDestroy()
        {
            foreach (var button in _buttons)
                button.onClick.RemoveAllListeners();
        }

        private void OnButtonClicked(Button button)
        {
            _activeFactory = button.GetComponentInChildren<IBorderFactory>() ?? _activeFactory;
        }

        public IBorder CreateBetween(Reign from, Reign to) => _activeFactory.CreateBetween(from, to);
    }
}
