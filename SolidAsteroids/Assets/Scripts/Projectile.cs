using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 50f;

    private void Update()
    {
        transform.localPosition += Vector3.right * Time.deltaTime * _moveSpeed;
    }
}
