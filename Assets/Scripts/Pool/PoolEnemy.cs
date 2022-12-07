using Enemy;
using UnityEngine;
using Wave;

namespace Pool
{
    public class PoolEnemy : PoolUse
    {
        [SerializeField] private WaveController _waveController;
        [SerializeField] private EnemyController _enemyController;
        [SerializeField] private WayEnemy _wayEnemy;
        [SerializeField] private float _offset;
        [SerializeField] private float _height;

        private PoolMono<EnemyController> _poolEnemy;
        
        protected override void CreatePool()
        {
            _poolEnemy = new PoolMono<EnemyController>(_enemyController, PoolCount, transform)
            {
                AutoExpand = AutoExpand
            };
        }

        public override GameObject CreateObject()
        {
            var enemy = _poolEnemy.GetFreeElement();
            enemy.transform.position = -Camera.main.transform.forward * _offset + Vector3.up * _height;
            enemy.transform.rotation = Camera.main.transform.rotation;
            enemy.MoveSpots = _wayEnemy.Ways;
            enemy._waveController = _waveController;
            enemy.InitializeShip();
            return enemy.gameObject;
        }
    }
}
