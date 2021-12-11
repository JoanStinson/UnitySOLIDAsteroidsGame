using UnityEngine;

namespace JGM.Game.Utils
{
    public class PlayAudioClipAtPointOnEnable : MonoBehaviour
    {
        [SerializeField]
        private AudioClip _audioClip;

        private void Start()
        {
            AudioSource.PlayClipAtPoint(_audioClip, transform.position);
        }
    }
}