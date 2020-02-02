﻿using System.Collections;
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
        float mousePositionXInUnits = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
        Vector2 paddlePosition = new Vector2(mousePositionXInUnits, transform.position.y);
        transform.position = paddlePosition;
    }
}
