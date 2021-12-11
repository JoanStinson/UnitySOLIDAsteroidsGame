using System.Collections;
using UnityEngine;

namespace JGM.Game.Utils
{
    [RequireComponent(typeof(AudioSource))]
    public class DestroyObjectAfterAudio : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Play();
            StartCoroutine(Destroy());
        }

        private IEnumerator Destroy()
        {
            yield return new WaitWhile(() => _audioSource.isPlaying);
            Destroy(gameObject);
        }
    }
}