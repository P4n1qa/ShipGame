using System.Collections;
using Enemy.Interface;
using UnityEngine;

namespace Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int _lifeTime;
        
        private void OnEnable()
        {
            StartCoroutine(CR_TimerForLive());
        }

        private IEnumerator CR_TimerForLive()
        {
            yield return new WaitForSeconds(_lifeTime);
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<IEnemy>() != null)
            {
                other.GetComponent<IEnemy>().Injured();
            }
            gameObject.SetActive(false);
        }
        
    }
}
