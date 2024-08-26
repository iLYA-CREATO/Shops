using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeDay : MonoBehaviour
{
    public Day _day;

    public Transform sunTransform;
    public int hours = 8; 
    public int minutes; 
    public float secondsPerMinute = 1f; 
    public float sunRotationSpeed = 1f; 

    private float timeCounter;

    public TextMeshProUGUI timeText;
    void Start()
    {
        hours = 8;
    }
    void Update()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter >= secondsPerMinute)
        {
            timeCounter -= secondsPerMinute; 
            minutes++; 

            
            if (minutes >= 60)
            {
                minutes = 0; 
                hours++; 


                if (hours >= 24)
                {
                    hours = 0; 
                    _day.day++; 
                }
            }
        }
        
        
        UpdateTimeText();
        RotateSun();
    }

    void UpdateTimeText()
    {
        timeText.text = $"{hours:00}:{minutes:00}";
    }

    void RotateSun()
    {
        float rotationThisFrame = sunRotationSpeed * (secondsPerMinute / 60f) * Time.deltaTime;
        sunTransform.Rotate(Vector3.up, rotationThisFrame);
    }
}
