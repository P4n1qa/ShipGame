using System.Collections;
using Pool;
using UnityEngine;

namespace Player
{
    public class Ballistic : MonoBehaviour
    {
        [SerializeField] private PoolBullet _poolBullet;

        [SerializeField] private float _speed;
        [SerializeField] private float _cooldown;
        
        private bool canShoot = true;
        
        public IEnumerator CR_Shoot()
        {
            if (!canShoot) yield break;
            canShoot = false;
            yield return new WaitForSeconds(0.3f);
            
            GameObject bullet = _poolBullet.CreateObject();
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = transform.TransformDirection(new Vector3(0f,5f,_speed));
            
            StartCoroutine(CR_Reload());
        }
        
        private IEnumerator CR_Reload()
        {
            yield return new WaitForSeconds(_cooldown);
            canShoot = true;
        }
    }
}
