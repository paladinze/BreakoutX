using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int totalNumberBlocks = 0;
    private SceneLoader sceneLoader;

    public void AddTotalBlocksCount()
    {
        totalNumberBlocks++;
    }

    public void DecreaseTotalBlocksCount()
    {
        totalNumberBlocks--;
        if (totalNumberBlocks == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
