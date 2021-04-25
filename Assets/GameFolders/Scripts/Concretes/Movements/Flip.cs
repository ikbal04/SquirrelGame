using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SquirrelGame.Movements
{
    public class Flip : MonoBehaviour
    {
        public void FlipCharacter(float _horizontal)
        {
            if (_horizontal != 0)
            {
                float mathfValue = Mathf.Sign(_horizontal);
                if (transform.localScale.x == mathfValue) return;
                transform.localScale = new Vector2(mathfValue, 1);
            }
            
        }
    }
}

