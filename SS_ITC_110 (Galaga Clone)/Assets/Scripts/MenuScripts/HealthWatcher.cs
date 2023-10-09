using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthWatcher : MonoBehaviour
{
    public CharacterBrain player;
    public TextMeshProUGUI healthText;

    private void Update()
    {
        healthText.text = "Health: " + player.health;
    }
}
