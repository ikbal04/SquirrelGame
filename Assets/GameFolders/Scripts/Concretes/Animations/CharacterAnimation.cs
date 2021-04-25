using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SquirrelGame.Animations
{[RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void MoveAnimation(float _horizontal)
        { 
            float mathfValue = Mathf.Abs(_horizontal);
            if (_animator.GetFloat("moveSpeed") == mathfValue) return;
            _animator.SetFloat("moveSpeed",mathfValue );
        }
        public void JumpAnimation(bool isJump)
        {
            if (isJump == _animator.GetBool("isJump")) return;
            _animator.SetBool("isJump", isJump);
        }
        public void ClimbAnimation(bool isClimb)
        {
            if (isClimb == _animator.GetBool("isClimp")) return;
            _animator.SetBool("isClimp", isClimb);
        }
    }

}
