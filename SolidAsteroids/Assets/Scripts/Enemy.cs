using UnityEngine;

public class Enemy : MonoBehaviour, IEntity
{
    public int Damage => 100;

    [SerializeField] private float _moveSpeed = 2f;

    private void Update()
    {
        transform.localPosition -= Vector3.right * Time.deltaTime * _moveSpeed;
    }
}