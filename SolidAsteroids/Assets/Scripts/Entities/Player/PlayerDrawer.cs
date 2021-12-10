using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerDrawer : MonoBehaviour, IAnimatedShip
{
    [field: SerializeField] public Sprite IdleSprite { get; set; }
    [field: SerializeField] public Sprite MovingUpSprite { get; set; }
    [field: SerializeField] public Sprite MovingDownSprite { get; set; }

    [SerializeField] private float _moveSpeed = 30f;

    private PlayerInput _playerInput;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _initialPosition;

    private const float _timeToMakePlayerVisibleAgain = 2f;
    private const float _bottomLimit = -3.343f;
    private const float _topLimit = 3.343f;
    private const float _xAxisPosition = -6.19f;

    private void Awake()
    {
        GetComponent<PlayerHealth>().OnPlayerRespawn += RespawnPlayer;
        _playerInput = GetComponent<PlayerInput>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        transform.position = new Vector3(_xAxisPosition, transform.position.y, transform.position.z);
        _initialPosition = transform.position;
    }

    private void Update()
    {
        var newPosition = transform.position + (Vector3.up * _playerInput.Input.Vertical * _moveSpeed * Time.deltaTime);
        newPosition.y = Mathf.Clamp(newPosition.y, _bottomLimit, _topLimit);
        transform.position = newPosition;

        if (_playerInput.Input.Vertical == 0)
        {
            _spriteRenderer.sprite = IdleSprite;
        }
        else
        {
            _spriteRenderer.sprite = _playerInput.Input.Vertical > 0 ? MovingUpSprite : MovingDownSprite;
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