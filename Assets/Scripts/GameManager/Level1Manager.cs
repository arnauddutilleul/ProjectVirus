using System.Collections;
using Audio;
using Controllers;
using PNJ;
using UnityEngine;

namespace GameManager
{
    public class Level1Manager : MonoBehaviour
    {
        [SerializeField] private GameObject poison;
        [SerializeField] private HeroController hero;
        [SerializeField] private NpcController pnj;
        [SerializeField] private GameObject dialogStart;
        [SerializeField] private GameObject dialogEnd;
        [SerializeField] private AudioSource music;
        [SerializeField] private GameObject randomSpawner;
        [SerializeField] private GameObject triggerLastRun;
        [SerializeField] private GameObject birdManager;
        private static readonly int Flee = Animator.StringToHash("Flee");

        void Start()
        {
            StartMusic();
            Invoke(nameof(StartMusic), music.time);
            AudioManager.Instance.Transition(AudioManager.Mode.Play);
            pnj.CanRun = false;
            hero.CanMove = false;
            poison.SetActive(false);
            dialogStart.SetActive(true);
        }

        private void StartMusic()
        {
            AudioManager.Instance.EnableSound(music);
        }

        public void StopBeforeLastRun()
        {
            dialogEnd.SetActive(true);
            hero.CanMove = false;
            poison.SetActive(false);
        }

        public void ResumeLastRun()
        {
            dialogEnd.SetActive(false);
            hero.CanMove = true;
            poison.SetActive(true);
            randomSpawner.SetActive(true);
            triggerLastRun.SetActive(false);
        }
        
        public IEnumerator PnjRunCoRoutine()
        {
        
            yield return new WaitForSeconds(5f);
            dialogStart.SetActive(false);
            hero.CanMove = true;
            poison.SetActive(true);
            birdManager.SetActive(true);
        }
        
        public void StartGame()
        {
            pnj.CanRun = true;
            pnj.Animator.SetTrigger(Flee);
            StartCoroutine("PnjRunCoRoutine");
        }

    }
}
