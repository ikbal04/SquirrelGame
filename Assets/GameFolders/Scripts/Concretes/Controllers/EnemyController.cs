using SquirrelGame.Animations;
using SquirrelGame.Combats;
using SquirrelGame.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SquirrelGame.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        Mover _mover;
        CharacterAnimation _characterAnimation;
        Health _health;
        Flip _flip;
        OnReachedEdge _onReachedEdge;

        bool _isOnEdge;
        float _direction;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
            _characterAnimation = GetComponent<CharacterAnimation>();
            _health = GetComponent<Health>();
            _flip = GetComponent<Flip>();
            _onReachedEdge = GetComponent<OnReachedEdge>();
            _direction = 1f;
        }
        private void OnEnable()
        {
            _health.OnDead += DeadAction;
        }
       
        private void FixedUpdate()
        {
            if (_health.IsDead) return;
            _mover.HorizontalMove(_direction);
            
        }
        private void LateUpdate()
        {
            if (_health.IsDead) return;
         if(_onReachedEdge.ReachedEdge())
            {
                _direction *= -1;
                _flip.FlipCharacter(_direction);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Damage damage = collision.collider.GetComponent<Damage>();
            if (collision.collider.GetComponent<PlayerController>() != null && collision.contacts[0].normal.y < -0.6f)
            {
                damage.HitTarget(_health);
            }
        }

        private void DeadAction()
        {
            Destroy(this.gameObject);
        }



    }

}
