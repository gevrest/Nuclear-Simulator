using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public sealed class LoseMenu : MonoBehaviour
    {
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _quitButton;

        private void OnEnable()
        {
            _menuButton.onClick.AddListener(BackToMenu);
            _quitButton.onClick.AddListener(ExitGame);
        }

        private void OnDisable()
        {
            _menuButton.onClick.RemoveListener(BackToMenu);
            _quitButton.onClick.RemoveListener(ExitGame);
        }

        public void LoseGame()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
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