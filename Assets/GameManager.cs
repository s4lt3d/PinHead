using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public FloatVariable ballCount;
    public int ballsToCapture = 2;
    public bool resetOnStart = true;
    public string nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        if(resetOnStart)
        {
            ballCount.Value = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ballsToCapture <= ballCount.Value)
            LoadScene();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
