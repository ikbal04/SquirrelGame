using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SquirrelGame.Uis
{
    public class MenuPanel : MonoBehaviour
    {
       public void BaşlatButtonClick()
        {
            GameManager.Instance.LoadScene(1);
            
        }
        public void ÇıkışButtonClick()
        {
            GameManager.Instance.ExitGame();
        }
    }
}

