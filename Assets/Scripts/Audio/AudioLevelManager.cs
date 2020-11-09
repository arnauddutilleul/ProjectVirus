using UnityEngine;

namespace Audio
{
    public class AudioLevelManager : MonoBehaviour
    {
        public void SetMasterVol(float masterVol)
        {
            GameManager.GameManager.Instance.AudioManager.SetMasterVol(masterVol);
        }
        
        public void SetSfxVol(float sfxVol)
        {
            GameManager.GameManager.Instance.AudioManager.SetSfxVol(sfxVol);
        }
        
        public void SetMenuVol(float menuVol)
        {
            GameManager.GameManager.Instance.AudioManager.SetMenuVol(menuVol);
        }
        
        public void SetMusicVol(float musicVol)
        {
            GameManager.GameManager.Instance.AudioManager.SetMusicVol(musicVol);
        }

        public void EnableSound(AudioSource sound)
        {
            GameManager.GameManager.Instance.AudioManager.EnableSound(sound);
        }
    }
}
