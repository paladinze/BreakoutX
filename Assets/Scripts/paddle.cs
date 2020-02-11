using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;

    private GameStatus gameStatus;
    private Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        float xPaddlePos = GetXPosForPaddle();
        Vector2 paddlePos = new Vector2(xPaddlePos, transform.position.y);
        transform.position = paddlePos;
    }

    float GetXPosForPaddle()
    {
        if (gameStatus.GetIsAutoPlaymodeEnabled())
        {
            return ball.transform.position.x;
        } else
        {
            float mousePosXInUnits = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
            mousePosXInUnits = Mathf.Clamp(mousePosXInUnits, 0f, screenWidthInUnits);
            return mousePosXInUnits;
        }
    }
}
