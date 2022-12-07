using UnityEngine;

namespace Player
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _rotationFriction;
        [SerializeField] private float _rotationSmoothness;
        
        private Ballistic _ballistic;

        private float _resultInput;
        private Quaternion _rotateFrom;
        private Quaternion _rotateTo;
        private void Awake()
        {
            _ballistic = GetComponent<Ballistic>();
        }

        private void Update()
        {
            Rotate();
            Shoot();
        }

        private void Shoot()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(_ballistic.CR_Shoot());
            }
        }

        private void Rotate()
        {
            _resultInput += Input.GetAxis("Mouse X") * _rotationSpeed * _rotationFriction;
            _rotateFrom = transform.rotation;
            _rotateTo = Quaternion.Euler(0f , _resultInput , 0f);

            transform.rotation = Quaternion.Lerp(_rotateFrom, _rotateTo, Time.deltaTime * _rotationSmoothness);
        }
    }
}
