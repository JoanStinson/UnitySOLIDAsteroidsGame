using UnityEngine;

public class DisableObject : MonoBehaviour
{
    public void Disable()
    {
        gameObject.SetActive(false);
    }
}