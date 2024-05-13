using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetTextTMP : MonoBehaviour
{
    [SerializeField] private TMP_Text textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    public void SetText(TimerManager timerManager)
    {
        textMesh.text = timerManager.GetTime();
    }
}
