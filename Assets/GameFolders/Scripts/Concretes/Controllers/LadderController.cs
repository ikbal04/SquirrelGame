using SquirrelGame.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SquirrelGame.Controllers
{
    public class LadderController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            EnterExitOnTrigger(collision, 0, true);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            EnterExitOnTrigger(collision, 1, false);
        }
        private void EnterExitOnTrigger(Collider2D collision,float gravityforce,bool isClimb)
        {
            Climb playerClimbing = collision.GetComponent<Climb>();
            if (playerClimbing != null)
            {
                playerClimbing.Rigidbody2D.gravityScale = gravityforce;
                playerClimbing.IsClimb = isClimb;
            }
        }
    }
}

