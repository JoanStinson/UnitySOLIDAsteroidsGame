using UnityEngine;

namespace JGM.Game.Utils
{
    public class DestroyObject : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}