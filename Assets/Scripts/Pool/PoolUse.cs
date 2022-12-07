using UnityEngine;

namespace Pool
{
    public abstract class PoolUse : MonoBehaviour
    {
        public int PoolCount;
        public bool AutoExpand;

        private void Awake()
        {
            CreatePool();
        }

        protected abstract void CreatePool();

        public abstract GameObject CreateObject();
    }
}
