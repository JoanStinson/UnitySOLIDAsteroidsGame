using UnityEngine;

namespace JGM.Game.Utils
{
    public class DisableObject : MonoBehaviour
    {
        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}