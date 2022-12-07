using UnityEngine;

namespace Enemy
{
    public class EnemyMovement
    {
        private int _currentState;
        
        public void CheckDistance(Transform transform ,GameObject[] moveSpots)
        {
            _currentState = 0;
            
            float closestSpot = Vector3.Distance(transform.position, moveSpots[_currentState].transform.position);
            
            int state = 0;
            
            foreach (var spot in moveSpots)
            {
                if (Vector3.Distance(transform.position, spot.transform.position) < closestSpot)
                {
                    closestSpot = Vector3.Distance(transform.position, spot.transform.position);
                    _currentState = state;
                }
                state += 1;
            }
        }
        
        public void StartControlPerson(Transform transform , float speedRotation ,float speed ,GameObject[] moveSpots)
        {
            Move(transform,speed,moveSpots);
            Rotation(transform,speedRotation,moveSpots);
        }
        
        private void Rotation(Transform transform , float speedRotation , GameObject[] moveSpots)
        {
            Vector3 direction = moveSpots[_currentState].transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation,rotation,speedRotation * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(transform.forward);
        }
        
        private void Move (Transform transform , float speed , GameObject[] moveSpots)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveSpots[_currentState].transform.position ,
                speed * Time.deltaTime);
            if (!(Vector3.Distance(transform.position, moveSpots[_currentState].transform.position) < 0.2f)) return;
            _currentState += 1;
            if (_currentState > moveSpots.Length - 1)
            {
                _currentState = 0;
            }
        }
    }
}