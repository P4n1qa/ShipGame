using UnityEngine;

namespace Pool
{
    public class PoolBullet : PoolUse
    {
        [SerializeField] private Bullet.Bullet _bullet;
        [SerializeField] private Transform _spawn;

        private PoolMono<Bullet.Bullet> _poolBullet;

        protected override void CreatePool()
        {
            _poolBullet = new PoolMono<Bullet.Bullet>(_bullet, PoolCount, transform)
            {
                AutoExpand = AutoExpand
            };
        }

        public override GameObject CreateObject()
        {
            var bullet = _poolBullet.GetFreeElement();
            bullet.transform.position = _spawn.position;
            return bullet.gameObject;
        }
    }
}
