using System.Collections;
using UnityEngine;

namespace JGM.Game.Utils
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class DisableObjectAfterAudio : MonoBehaviour
    {
        private AudioSource _audioSource;
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        private void OnEnable()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Play();
            //_spriteRenderer.GetComponent<SpriteRenderer>();
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