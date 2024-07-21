using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleControl : MonoBehaviour
{
    // Handled Player Control
    [SerializeField]
    private float dragSpeed;

    [HideInInspector]
    public float currentMoveSpeed;

    [SerializeField]
    Vector3 firstPosition;

    private bool isPlayerFallableLeft = false, isPlayerFallableRight = false;

    private void Start()
    {
        firstPosition = transform.position;
    }
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
                
            TranslateSide(touch);             
            
        }
    }
    private void TranslateSide(Touch touch)
    {
        transform.Translate(Vector3.right * touch.deltaPosition.x * dragSpeed);
    }
}