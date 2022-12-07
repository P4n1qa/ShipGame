using System.Collections;
using Pool;
using UnityEngine;

namespace Wave
{
    public class WaveController : MonoBehaviour
    {
        [HideInInspector]public int _countLiveShips;
        
        [SerializeField] private PoolEnemy _poolEnemy;
        
        [SerializeField] private int _maxShips;
        [SerializeField] private int _timeSpawnShip;

        private bool canLoadWave;

        private bool CountEnemySmall()
        {
            return _maxShips > _countLiveShips;
        }
        
        private void Start()
        {
            canLoadWave = true;
            StartCoroutine(CR_Reload());
        }

        private IEnumerator CR_Reload()
        {
            while (canLoadWave)
            {
                if (CountEnemySmall())
                {
                    CreateShip();
                    yield return new WaitForSeconds(_timeSpawnShip);
                }
                else
                {
                    yield return null;
                }
            }
        }

        private void CreateShip()
        {
            _countLiveShips += 1;
            _poolEnemy.CreateObject();
        }
    }
}
