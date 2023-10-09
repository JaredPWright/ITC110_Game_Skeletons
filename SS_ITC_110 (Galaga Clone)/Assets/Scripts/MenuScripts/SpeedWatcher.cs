using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedWatcher : MonoBehaviour
{
    public Movement player;
    public TextMeshProUGUI speedText;

    private void Update()
    {
        speedText.text = "Speed: " + player.movementSpeed;
    }
}
