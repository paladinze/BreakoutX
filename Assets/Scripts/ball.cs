using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xSpeed;
    [SerializeField] float ySpeed;
    [SerializeField] AudioClip[] audioClips;
    private AudioSource ballAudioSource;


    Vector2 paddleToBallVector;
    Boolean isLaunched = false;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        ballAudioSource = GetComponent<AudioSource>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isLaunched) return;
        this.GetComponent<AudioSource>().Play();

        // play random sound from collection of audio clips
        AudioClip audioClip = audioClips[UnityEngine.Random.Range(0, audioClips.Length)];
        ballAudioSource.PlayOneShot(audioClip);
    }
}
