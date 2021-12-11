using JGM.Game.Entities.Player;
using System.Collections;
using UnityEngine;

namespace JGM.Game.Entities.Player
{
    [RequireComponent(typeof(PlayerHealth))]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerDrawer : MonoBehaviour
    {
        [SerializeField] private Sprite _idleSprite;
        [SerializeField] private Sprite _movingUpSprite;
        [SerializeField] private Sprite _movingDownSprite;

        private PlayerHealth _playerHealth;
        private PlayerInput _playerInput;
        private SpriteRenderer _spriteRenderer;
        private Vector3 _initialPosition;

        private const float _timeToMakePlayerVisibleAgain = 2f;
        private const float _bottomLimit = -3.343f;
        private const float _topLimit = 3.343f;
        private const float _xAxisStartPosition = -6.19f;

        private void Awake()
        {
            _playerHealth = GetComponent<PlayerHealth>();
            _playerHealth.OnPlayerRespawn += RespawnPlayer;
            _playerInput = GetComponent<PlayerInput>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            transform.position = new Vector3(_xAxisStartPosition, transform.position.y, transform.position.z);
            _initialPosition = transform.position;
        }

        private void Update()
        {
            var newPosition = transform.position + Vector3.up * _playerInput.Input.Vertical * _playerHealth.MoveSpeed * Time.deltaTime;
            newPosition.y = Mathf.Clamp(newPosition.y, _bottomLimit, _topLimit);
            transform.position = newPosition;

            if (_playerInput.Input.Vertical == 0)
            {
                _spriteRenderer.sprite = _idleSprite;
            }
            else
            {
                _spriteRenderer.sprite = _playerInput.Input.Vertical > 0 ? _movingUpSprite : _movingDownSprite;
            }
        }

        private void RespawnPlayer()
        {
            StartCoroutine(Respawn(_timeToMakePlayerVisibleAgain));
        }

        private IEnumerator Respawn(float delayInSeconds)
        {
            _spriteRenderer.enabled = false;
            _playerInput.enabled = false;
            yield return new WaitForSeconds(0.5f);
            _spriteRenderer.enabled = true;
            yield return new WaitForSeconds(delayInSeconds);
            transform.position = _initialPosition;
            _playerInput.enabled = true;
        }
    }
}