using DG.Tweening;
using Game.Management;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class PauseButtonController : MonoBehaviour {
        [SerializeField] private CanvasGroup _selfCanvas;
        [SerializeField] private CanvasGroup _pauseCanvas;
        [SerializeField] private GameStatesManager _manager;

        private Button _button;

        private void Awake() {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(PauseGame);
        }

        private void PauseGame() {
            _manager.Pause();
            _selfCanvas.DOFade(0f, 0.75f).SetUpdate(true);
            _selfCanvas.interactable = false;
            
            _pauseCanvas.DOFade(1f, 0.75f).SetUpdate(true);
            _pauseCanvas.interactable = true;
        }

        private void OnDestroy() {
            _button.onClick.RemoveAllListeners();
        }
    }
}