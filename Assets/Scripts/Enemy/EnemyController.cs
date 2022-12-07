using System.Collections;
using Enemy.Interface;
using UnityEngine;
using Wave;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyController : MonoBehaviour , IEnemy
    {
        [HideInInspector] public GameObject[] MoveSpots;
        [HideInInspector] public WaveController _waveController;

        [SerializeField] private float _speedShip;
        [SerializeField] private float _speedRotationShip;
        [SerializeField] private int _maxHealth;
        
        private Animator _animator;
        private EnemyMovement _enemyMovement;

        private int _health;

         public void Injured()
         {
             _health -= 1;
             if (_health == 0)
             {
                 StartCoroutine(CR_Death());
             }
         }

         public void InitializeShip()
         {
             _health = Random.Range(1, _maxHealth);
             _enemyMovement.CheckDistance(transform , MoveSpots);
         }

         private void Awake()
         {
             _enemyMovement = new EnemyMovement();
             _animator = GetComponent<Animator>();
         }

         private void Update()
         {
             if (MoveSpots.Length == 0) return;
             if (_health <= 0)return;
             _enemyMovement.StartControlPerson(transform ,_speedRotationShip,_speedShip , MoveSpots);
         }
         
         private IEnumerator CR_Death()
         {
             _animator.SetTrigger("Death");
             yield return new WaitForSeconds(10f);
             _waveController._countLiveShips -= 1;
             gameObject.SetActive(false);
         }
    }
}
