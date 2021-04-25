using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SquirrelGame.Movements
{
    public class Climb : MonoBehaviour
    {
        [SerializeField] float _climbSpeed = 5;

        Rigidbody2D _rigidbody2D;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public bool IsClimb { get; set; }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        public void ClimbAction(float direction)
        {
            if (IsClimb)
            {
                transform.Translate(Vector2.up * direction * Time.deltaTime * _climbSpeed);
            }
            
        }
    }

}
