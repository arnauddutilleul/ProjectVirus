using Audio;
using UnityEngine;

namespace GameManager
{
    public class EndScreenManager : MonoBehaviour
    {
        [SerializeField] private bool victory;
        [SerializeField] private AudioSource audioVictory;
        [SerializeField] private AudioSource audioDefeat;
        
        
        void Start()
        {
            AudioSource source;
            AudioManager.Mode mode;
            
            if (victory)
            {
                source = audioVictory;
                mode = AudioManager.Mode.Win;
            }
            else
            {
                source = audioDefeat;
                mode = AudioManager.Mode.Lose;
            }
            AudioManager.Instance.EnableSound(source);
            AudioManager.Instance.Transition(mode);
            
            Invoke(nameof(backToMainMenu), 8);
        }

        public void backToMainMenu()
        {
            GameManager.Instance.LoadScene("MainMenu");
            //GameManager.Destroy();
        }
    }
}
