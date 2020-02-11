using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xSpeed;
    [SerializeField] float ySpeed;
    [SerializeField] float randomFactor = 0.2f;
    [SerializeField] AudioClip[] audioClips;

    private AudioSource ballAudioSource;
    private Rigidbody2D ballRigidBody2D;

    Vector2 paddleToBallVector;
    Boolean isLaunched = false;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        ballAudioSource = GetComponent<AudioSource>();
        ballRigidBody2D = GetComponent<Rigidbody2D>();
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
            ballRigidBody2D.velocity = new Vector2(xSpeed, ySpeed);
            isLaunched = true;
        }
    }

    private void SetBallAbovePaddle()
    {
        transform.position = (Vector2)paddle1.transform.position + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // change to velocity on hit (to prevent deterministic reflection ;)
        Vector2 randomVelocityDelta = new Vector2(
            UnityEngine.Random.Range(-randomFactor, randomFactor),
            UnityEngine.Random.Range(-randomFactor, randomFactor));

        if (!isLaunched) return;

        // apply random velocity change to ball
        ballRigidBody2D.velocity += randomVelocityDelta;

        // play random sound from collection of audio clips
        AudioClip audioClip = audioClips[UnityEngine.Random.Range(0, audioClips.Length)];
        ballAudioSource.PlayOneShot(audioClip);
    }
}
