using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Spawner
{
    public class TimerSpawner : MonoBehaviour
    {
        [SerializeField]
        float delay = 0f;
        [SerializeField]
        float interval = 0f;
        [SerializeField] private UnityEvent onTick;

        Coroutine _timerCoroutiner;

        private void OnEnable()
        {
            _timerCoroutiner = StartCoroutine(TimerCoroutine());
        }

        private void OnDisable()
        {
            StopCoroutine(_timerCoroutiner);
        }

        IEnumerator TimerCoroutine()
        {
            yield return new WaitForSeconds(delay);
            while (true)
            {
                Spawn();
                yield return new WaitForSeconds(interval);
            }
        }

        void Spawn()
        {
            onTick.Invoke();
        }


    }
}