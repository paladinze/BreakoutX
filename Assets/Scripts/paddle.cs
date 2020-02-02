using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosXInUnits = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
        mousePosXInUnits = Mathf.Clamp(mousePosXInUnits, 0f, screenWidthInUnits);
        Vector2 paddlePos = new Vector2(mousePosXInUnits, transform.position.y);
        transform.position = paddlePos;
    }
}
