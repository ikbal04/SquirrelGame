using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SquirrelGame.Controllers
{
    public class CheckPointController : MonoBehaviour
    {
        bool _isPassed = false;
        public bool IsPassed => _isPassed;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerController>() != null)
            {
                _isPassed = true;
            }
        }
    }
}

