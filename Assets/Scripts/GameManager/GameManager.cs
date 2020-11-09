using System;
using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManager
{
    public class GameManager : SingletonMb<GameManager>
    {
        [SerializeField] private AudioManager audioManager;
        private int _nbrPlayed;
        public AudioManager AudioManager => audioManager;
        
        protected override void Initialize()
        {
        }
        protected override void Cleanup()
        {
        }

        public void NewGame()
        {
            LoadScene("Level1");
        }

        public void GameOver()
        {
            LoadScene("GameOver");
        }

        public void MainMenu()
        {
            LoadScene("MainMenu");
        }
        
        public void LoadSavedLevel ()
        {
            throw new NotImplementedException();
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}