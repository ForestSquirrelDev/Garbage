using Audio;
using UnityEngine;

namespace Game.Management {
    public class GameStatesManager : MonoBehaviour {
        
        private void Awake() {
            Time.timeScale = 0f;
        }

        public void StartGame() {
            Time.timeScale = 1f;
            AudioSourceSingleton.ResumeMusic();
            AudioSourceSingleton.PlayRandomSongsLooped();
        }

        public void Pause() {
            AudioSourceSingleton.PauseMusic();
            Time.timeScale = 0f;
        }
    }
}