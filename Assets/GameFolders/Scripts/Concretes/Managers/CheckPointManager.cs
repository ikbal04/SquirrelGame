using SquirrelGame.Combats;
using SquirrelGame.Controllers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    CheckPointController[] _checkPointControllers;
    Health _health;

    private void Awake()
    {
        _checkPointControllers = GetComponentsInChildren<CheckPointController>();
        _health = FindObjectOfType<PlayerController>().GetComponent<Health>();
    }
    private void Start()
    {
        _health.OnHealthChanged += HandleHealthChanged;
    }

    private void HandleHealthChanged(int currentHealth)
    {
        _health.transform.position = _checkPointControllers.LastOrDefault(x => x.IsPassed).transform.position;
    }
}
