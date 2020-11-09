using GameManager;
using UnityEngine;
using UnityEngine.Audio;

namespace Audio
{
    public class AudioManager : SingletonMb<AudioManager> {

        public AudioMixerSnapshot pauseSnapshot;
        public AudioMixerSnapshot playSnapshot;
        public AudioMixerSnapshot loseSnapshot;
        public AudioMixerSnapshot winSnapshot;
        public AudioMixerSnapshot mainMenuSnapshot;
        [SerializeField] private AudioMixer masterMixer;

        public float defaultTransitionTime = 0.2f;

        public enum Mode {Pause, Play, Win, Lose, Main};

        protected override void Cleanup()
        {
        }

        protected override void Initialize()
        {
        }

        public void Transition(Mode newMode) {
            switch (newMode) {
                case Mode.Pause:
                    pauseSnapshot.TransitionTo (defaultTransitionTime);
                    break;
                case Mode.Play:
                    playSnapshot.TransitionTo (defaultTransitionTime);
                    break;
                case Mode.Lose:
                    loseSnapshot.TransitionTo (defaultTransitionTime);
                    break;
                case Mode.Win:
                    winSnapshot.TransitionTo (defaultTransitionTime);
                    break;
                case Mode.Main:
                    mainMenuSnapshot.TransitionTo(defaultTransitionTime);
                    break;
                default:
                    break;
            }
        }

        public void SetMasterVol(float masterVol)
        {
            masterMixer.SetFloat("masterVol", Mathf.Log10(masterVol) * 20);
        }
        
        public void SetSfxVol(float sfxVol)
        {
            masterMixer.SetFloat("sfxVol", Mathf.Log10(sfxVol) * 20);
        }
        
        public void SetMenuVol(float menuVol)
        {
            masterMixer.SetFloat("menuVol", Mathf.Log10(menuVol) * 20);
        }
        
        public void SetMusicVol(float musicVol)
        {
            masterMixer.SetFloat("musicVol", Mathf.Log10(musicVol) * 20);
        }

        public void EnableSound(AudioSource sound)
        {
            sound.Play();
        }
    }
}