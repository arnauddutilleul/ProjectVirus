using System.Collections;
using Audio;
using Cinemachine;
using UnityEngine;

public class DetectionRocket : MonoBehaviour
{
    [SerializeField] private Animator rocket;
    [SerializeField] private Animator rocketModel;
    private static readonly int Lunch = Animator.StringToHash("Lunch");
    [SerializeField] private CinemachineVirtualCamera camera;
    [SerializeField] private Transform _rocket;
    [SerializeField] private AudioSource rocketLaunchSound;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Hero"))
        {
            other.gameObject.SetActive(false);
            Lunching();
        }
        
    }

    private void Lunching()
    {
        AudioManager.Instance.EnableSound(rocketLaunchSound);
        camera.m_Lens.OrthographicSize=10f;
        camera.Follow = _rocket;
        rocket.SetTrigger(Lunch);
        rocketModel.SetTrigger(Lunch);
        StartCoroutine("VictoryCoroutine");
    }
    
    public IEnumerator VictoryCoroutine()
    {
        yield return new WaitForSeconds(2.5f);
        GameManager.GameManager.Instance.LoadScene("Victory");
    }
    
}
