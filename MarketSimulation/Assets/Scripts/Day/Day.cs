using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Day : MonoBehaviour
{
    public int day = 1;
    public TextMeshProUGUI timeText;

    public void Update()
    {
        timeText.text = day.ToString();
    }
}
