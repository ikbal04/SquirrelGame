using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SquirrelGame.Movements
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float _speed = 5;
        public void HorizontalMove(float _horizontal)
        {
            transform.Translate(Vector2.right * Time.deltaTime * _horizontal * _speed);
        }
    }
}

