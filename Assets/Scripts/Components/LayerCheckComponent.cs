using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerCheckComponent : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    public bool IsTouchingLayer;

    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IsTouchingLayer = _collider.IsTouchingLayers(layerMask);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsTouchingLayer = _collider.IsTouchingLayers(layerMask);
    }
}
