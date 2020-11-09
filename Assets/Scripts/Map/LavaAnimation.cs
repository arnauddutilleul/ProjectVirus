using UnityEngine;

public class LavaAnimation : MonoBehaviour
{
    private Transform lava;
    private int value;
    private void Awake()
    {
        this.lava = transform;
    }

 
    private void Fipled() {
        if (value > 0) value = -180;
        else value = 180;
        lava.rotation=Quaternion.Euler(0, value, 0);
    }
}
