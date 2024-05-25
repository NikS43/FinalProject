using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    bool onPause = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onPause = !onPause;
            pauseMenu.SetActive(onPause);
        }
    }

    public void Continue()
    {
        onPause = !onPause;
        pauseMenu.SetActive(onPause);
    }
}
