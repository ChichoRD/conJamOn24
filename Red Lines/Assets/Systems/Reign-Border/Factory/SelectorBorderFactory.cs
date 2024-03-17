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

        public IBorder CreateBetween(in Reign from, in Reign to) => _activeFactory?.CreateBetween(in from, in to) ?? IBorder.NullBoder;
    }
}
