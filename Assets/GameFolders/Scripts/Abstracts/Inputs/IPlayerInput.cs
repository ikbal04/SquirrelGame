using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SquirrelGame.Abstracts.Inputs
{
    public interface IPlayerInput 
    {// Interfacelerde axes modiferler(public.private,protectted) olmaz
         float Horizontal { get; }
         float Vertical { get; }
        bool IsJumpButtonDown { get; }
    }
}

