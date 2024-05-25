using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        if (Random.Range(0, 5) == 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(4);
        }
    }

    public void GameSettings()
    {
        SceneManager.LoadScene(2);
    }

    public void AboutAuthors()
    {
        SceneManager.LoadScene(3);
    }

    public void ColorGame()
    {
        SceneManager.LoadScene(4);
    }

    public void BackStart()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
