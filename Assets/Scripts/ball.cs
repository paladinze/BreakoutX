using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
  [SerializeField] paddle paddle1;
  [SerializeField] float xSpeed;
  [SerializeField] float ySpeed;
  Vector2 paddleToBallVector;
  Boolean isLaunched = false;
  // Start is called before the first frame update
  void Start()
  {
    paddleToBallVector = transform.position - paddle1.transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    if (!isLaunched) {
        SetBallAbovePaddle();
    }
    LaunchOnMouseClick();
  }

  private void LaunchOnMouseClick()
  {
    if (Input.GetMouseButtonDown(0)) {
        GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, ySpeed);
        isLaunched = true;
    }
  }

  private void SetBallAbovePaddle()
  {
    transform.position = (Vector2)paddle1.transform.position + paddleToBallVector;
  }
}
