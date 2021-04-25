using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SquirrelGame.Movements
{[RequireComponent(typeof(Rigidbody2D))]
    public class Jumps : MonoBehaviour
    {
        [SerializeField] float _jumpForce = 350;

        Rigidbody2D _rigidbody2D;
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public bool IsJumpAction => _rigidbody2D.velocity != Vector2.zero;

        public void JumpAction()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }
}

