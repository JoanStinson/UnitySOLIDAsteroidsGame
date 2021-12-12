using System.Collections;
using UnityEngine;

namespace JGM.Game.Utils
{
    public class DisableObjectAfterAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private void OnEnable()
        {
            _audioSource.Play();
            _spriteRenderer.enabled = true;
            StartCoroutine(Destroy());
        }

        private IEnumerator Destroy()
        {
            yield return new WaitWhile(() => _audioSource.isPlaying);
            gameObject.SetActive(false);
        }
    }
}