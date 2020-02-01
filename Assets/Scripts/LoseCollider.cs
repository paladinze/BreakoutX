using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    void Start()
    {
        Debug.Log("Hello");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("trigger enter");
        SceneManager.LoadScene("Win Screen");
    }
}
