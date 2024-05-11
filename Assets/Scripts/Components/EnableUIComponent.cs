using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnableUIComponent : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    public void EnableUIElement()
    {
        _gameObject.SetActive(true);
    }

}
