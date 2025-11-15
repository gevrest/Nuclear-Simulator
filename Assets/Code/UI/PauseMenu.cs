using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public sealed class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _quitButton;

        private bool _paused = false;

        private void OnEnable()
        {
            _resumeButton.onClick.AddListener(ResumeGame);
            _menuButton.onClick.AddListener(BackToMenu);
            _quitButton.onClick.AddListener(ExitGame);
        }

        private void OnDisable()
        {
            _resumeButton.onClick.RemoveListener(ResumeGame);
            _menuButton.onClick.RemoveListener(BackToMenu);
            _quitButton.onClick.RemoveListener(ExitGame);
        }

        public void Toggle()
        {
            if (!_paused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }

        private void PauseGame()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
            _paused = true;
        }

        private void ResumeGame()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
            _paused = false;
        }

        private void BackToMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}