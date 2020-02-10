using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    private Level level;
    private GameStatus gameStatus;


    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.AddTotalBlocksCount();

        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        
       
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.RemoveTotalBlocksCount();

        gameStatus.IncreaseTotalScore();


        Destroy(gameObject);
    }

}
