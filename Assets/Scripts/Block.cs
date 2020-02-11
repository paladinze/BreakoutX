using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject explosionVFX;
    [SerializeField] Sprite[] blockSprites;

    private Level level;
    private GameStatus gameStatus;
    private int hits;
    private int maxHits;

    private void Start()
    {
        maxHits = blockSprites.Length + 1;
        level = FindObjectOfType<Level>();
        IncreaseBreakableCount();

    }

    private void OnCollisionEnter2D (Collision2D collision) {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        if (!tag.Equals("Breakable")) return;

        hits++;
        if (hits >= maxHits)
        {
            DestroyBlock();
        } else
        {
            ShowSpriteForNextDamageLevel();
        }
    }

    private void ShowSpriteForNextDamageLevel()
    {
        int spriteIndex = hits - 1;
        Sprite damagedBlockSprite = blockSprites[spriteIndex];
        if (damagedBlockSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = damagedBlockSprite;
        } else
        {
            Debug.LogError("block damaged sprite is missing");
        }
    }

    private void DestroyBlock()
    {
        Destroy(gameObject);
        level.DecreaseTotalBlocksCount();
        gameStatus = FindObjectOfType<GameStatus>();
        gameStatus.IncreaseTotalScore();
        CreateExplosion();
    }

    private void CreateExplosion()
    {
        GameObject explosion = Instantiate(explosionVFX, transform.position, transform.rotation);
        Destroy(explosion, 2f);
    }

    private void IncreaseBreakableCount()
    {
        if (!tag.Equals("Breakable")) return;
        level.AddTotalBlocksCount();
    }

}