using UnityEngine;
using UnityEngine.Events;

namespace GameManager
{
    public class DetectionLastRun : MonoBehaviour
    {
        [SerializeField] private UnityEvent stopBeforeLastRun;
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.layer == LayerMask.NameToLayer("Hero"))
                stopBeforeLastRun.Invoke();
        }
    }
}
