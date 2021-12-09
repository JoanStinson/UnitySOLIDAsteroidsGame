using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerDrawer : MonoBehaviour, IAnimatedShip
{
    [field: SerializeField] public Sprite IdleSprite { get; set; }
    [field: SerializeField] public float Speed { get; set; }
    [SerializeField] public Sprite MovingUpSprite => _movingUpSprite;
    [SerializeField] public Sprite MovingDownSprite => _movingDownSprite;

    [SerializeField] private float _moveSpeed = 25f;
    /*[SerializeField] */private Sprite _idleSprite;
    /*[SerializeField] */private Sprite _movingUpSprite;
    /*[SerializeField] */private Sprite _movingDownSprite;

    private PlayerInput _playerInput;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _initialPosition;
    private const float _timeToMakePlayerVisibleAgain = 2f;

    private void Awake()
    {
        GetComponent<PlayerHealth>().OnPlayerRespawn += RespawnPlayer;
        _playerInput = GetComponent<PlayerInput>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _initialPosition = transform.position;
    }

    private void Update()
    {
        transform.position += Vector3.up * _playerInput.Vertical * _moveSpeed * Time.deltaTime;

        if (_playerInput.Vertical == 0)
        {
            _spriteRenderer.sprite = _idleSprite;
        }
        else
        {
            _spriteRenderer.sprite = _playerInput.Vertical > 0 ? _movingUpSprite : _movingDownSprite;
        }
    }

    private void RespawnPlayer()
    {
        StartCoroutine(Respawn(_timeToMakePlayerVisibleAgain));
    }

    private IEnumerator Respawn(float delayInSeconds)
    {
        _spriteRenderer.enabled = false;
        yield return new WaitForSeconds(delayInSeconds);
        transform.position = _initialPosition;
        _spriteRenderer.enabled = true;
    }
}