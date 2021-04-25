using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SquirrelGame.Uis
{
    public class LoadingCanvas : MonoBehaviour
    {
        private void Start()
        {
            GameManager.Instance.LoadMenuAndUi(5);
        }
    }
}

