using UnityEngine;

namespace JGM.Game.Utils
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class DisableSprite : MonoBehaviour
    {
        public void Disable()
        {
            GetComponent<SpriteRenderer>().enabled = false;   
        }
    }
}