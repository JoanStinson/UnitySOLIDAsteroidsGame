using UnityEngine;

namespace JGM.Game.Utils
{
    public static class RandomPositioner
    {
        private const float _bottomLimitSpawn = -3.85f;
        private const float _topLimitSpawn = 3.85f;
        private const float _leftLimitSpawn = 9f;
        private const float _rightLimitSpawn = 22f;

        public static Vector2 GetRandomPos()
        {
            float xRandomPos = Random.Range(_leftLimitSpawn, _rightLimitSpawn);
            float yRandomPos = Random.Range(_bottomLimitSpawn, _topLimitSpawn);
            return new Vector2(xRandomPos, yRandomPos);
        }
    }
}