using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SquirrelGame.Combats
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int maxhealth = 3;
        [SerializeField] int currentHealth = 0;
        
        public bool IsDead => currentHealth < 1;
        public event System.Action<int> OnHealthChanged;
        public event System.Action OnDead;
        private void Awake()
        {
            currentHealth = maxhealth;
        }
        private void Start()
        {
            OnHealthChanged?.Invoke(maxhealth);
        }
        public void TakeHit(Damage damage)
        {
            if (IsDead) return;
            
                currentHealth -= damage.HitDamage;
                
            if (IsDead)
            {
                OnDead?.Invoke();
            }
            else
            {
                OnHealthChanged?.Invoke(currentHealth);
            }

        }
    }

}
