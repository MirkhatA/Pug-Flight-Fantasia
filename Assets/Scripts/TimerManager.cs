using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerTxt;

    private float elapsedTime;

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        var minutes = Mathf.FloorToInt(elapsedTime / 60);
        var seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public string GetTime()
    {
        return timerTxt.text;
    }
}
