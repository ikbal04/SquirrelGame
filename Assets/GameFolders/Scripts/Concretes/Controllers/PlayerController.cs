using SquirrelGame.Abstracts.Inputs;
using SquirrelGame.Animations;
using SquirrelGame.Combats;
using SquirrelGame.Inputs;
using SquirrelGame.Movements;
using SquirrelGame.Uis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SquirrelGame.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        float _horizontal;
        float _vertical;
        bool _isJump;

        IPlayerInput _input;
        CharacterAnimation _characterAnimation;
        Jumps _jump;
        Mover _mover;
        Flip _flip;
        OnGround _onGround;
        Climb _climb;
        Health _health;
        
        private void Awake()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
            _jump = GetComponent<Jumps>();
            _mover = GetComponent<Mover>();
            _flip = GetComponent<Flip>();
            _onGround = GetComponent<OnGround>();
            _climb = GetComponent<Climb>();
            _health = GetComponent<Health>();
            _input = new PcInput();
        }
        private void OnEnable()
        {
            GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();
            if (gameCanvas!=null)
            {
                _health.OnDead += gameCanvas.ShowGameOverPanel;
                DisplayHealth displayHealth = gameCanvas.GetComponentInChildren<DisplayHealth>();
                _health.OnHealthChanged += displayHealth.WriteHealth;
               
            }
        }
        private void Update()
        {
            if (_health.IsDead) return;


            _horizontal = _input.Horizontal;
            _vertical = _input.Vertical;

            if (_input.IsJumpButtonDown&&_onGround.IsOnGround&&!_climb.IsClimb)
            {
                _isJump = true;
               
            }

            _characterAnimation.MoveAnimation(_horizontal);
            _characterAnimation.JumpAnimation(!_onGround.IsOnGround&&_jump.IsJumpAction);
            _characterAnimation.ClimbAnimation(_climb.IsClimb);
        }
        private void FixedUpdate()
        {
            _climb.ClimbAction(_vertical);
            _mover.HorizontalMove(_horizontal);
            _flip.FlipCharacter(_horizontal);
            if (_isJump)
            {
                _jump.JumpAction();
                _isJump = false;
            }
           
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Damage damage = collision.collider.GetComponent<Damage>();
            if (
                collision.collider.GetComponent<EnemyController>() != null &&
                collision.contacts[0].normal.x > 0.6f ||
                collision.contacts[0].normal.x < -0.6f
                )
            {
                damage.HitTarget(_health);
                return;
            }
            if (damage != null && collision.collider.GetComponent<EnemyController>()==null)
            {
                damage.HitTarget(_health);
            }
        }
    }

}
