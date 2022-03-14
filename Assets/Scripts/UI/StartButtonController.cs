using DG.Tweening;
using Game.Management;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class StartButtonController : MonoBehaviour {
        [SerializeField] private GameStatesManager _manager;
        [SerializeField] private CanvasGroup _selfCanvas;
        [SerializeField] private CanvasGroup _hudCanvas;

        private Button _button;

        private void Awake() {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(StartGame);
        }

        private void StartGame() {
            _manager.StartGame();
            
            _selfCanvas.interactable = false;
            _selfCanvas.DOFade(0f, 0.75f).SetUpdate(true);

            _hudCanvas.interactable = true;
            _hudCanvas.DOFade(1f, 0.75f).SetUpdate(true);
        }
    }
}