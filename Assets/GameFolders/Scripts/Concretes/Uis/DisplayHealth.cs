using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace SquirrelGame.Uis
{
    public class DisplayHealth : MonoBehaviour
    {
        TextMeshProUGUI _healthText;
        private void Awake()
        {
            _healthText = GetComponent<TextMeshProUGUI>();
        }
        public void WriteHealth(int currentHealth)
        {
            _healthText.text = currentHealth.ToString();
        }
    }
}

