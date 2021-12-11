using UnityEngine;

namespace JGM.Game.Entities.Asteroid
{
    [RequireComponent(typeof(Asteroid))]
    public class AsteroidSplitter : MonoBehaviour
    {
        [SerializeField] private Asteroid _asteroidPiecePrefab;
        [SerializeField] private int _totalAsteroidPieces = 2;

        private Asteroid _asteroid;

        private void Awake()
        {
            _asteroid = GetComponent<Asteroid>();
            _asteroid.OnAsteroidBreak += SpawnAsteroidPieces;
        }

        private void SpawnAsteroidPieces()
        {
            for (int i = 0; i < _totalAsteroidPieces; ++i)
            {
                var spawnedAsteroidPiece = Instantiate(_asteroidPiecePrefab);
                bool startAsteroidMovingUp = i % 2 == 0;
                spawnedAsteroidPiece.Initialize(startAsteroidMovingUp, _asteroid.transform.position);
            }
        }
    }
}