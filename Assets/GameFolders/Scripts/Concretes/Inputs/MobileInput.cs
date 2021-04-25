using SquirrelGame.Abstracts.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SquirrelGame.Inputs
{
    public class MobileInput : IPlayerInput
    {//bunlar mobile inputları değil interfacelerin kullanımını göstermek için yaptı.
        public float Horizontal => Input.GetAxis("Horizontal");
        public float Vertical => Input.GetAxis("Vertical");
        public bool IsJumpButtonDown => Input.GetButtonDown("Jump");
    }
}
