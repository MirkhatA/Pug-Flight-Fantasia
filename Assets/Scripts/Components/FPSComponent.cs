using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSComponent : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 100;
    }
}
