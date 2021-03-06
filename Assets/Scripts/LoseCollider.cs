﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private SceneLoader sceneLoader;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Game over!");
        sceneLoader.LoadLastScene();
    }
}
