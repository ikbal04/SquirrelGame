using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SquirrelGame.Combats
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] int damage=1;
        public int HitDamage => damage;

        public void HitTarget(Health health)
        {
            health.TakeHit(this);
        }
    }
}

