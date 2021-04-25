using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SquirrelGame.Controllers
{
    public class HouseController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player!=null)
            {
                GameManager.Instance.LoadScene();
            }
        }
    }

}
