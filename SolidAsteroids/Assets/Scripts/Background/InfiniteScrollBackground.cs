using UnityEngine;

namespace JGM.Game.Background
{
    public class InfiniteScrollBackground : MonoBehaviour
    {
        [SerializeField]
        private float _scrollSpeed = -100f;

        private float _rightEdge;
        private float _leftEdge;

        private void Awake()
        {
            float width = GetComponent<RectTransform>().rect.width;
            _rightEdge = width - 2;
            _leftEdge = -width;
        }

        private void Update()
        {
            transform.localPosition = new Vector3(transform.localPosition.x + _scrollSpeed * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);

            if (transform.localPosition.x <= _leftEdge)
            {
                transform.localPosition = new Vector3(_rightEdge, transform.localPosition.y, transform.localPosition.z);
            }
        }
    }
}