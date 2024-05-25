using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private Color[] colors = { Color.red, Color.green, Color.cyan, Color.magenta };
    private int[] colCount = { 0, 0, 0, 0 };
    private int colUsed;
    private int[] colorChoose;
    private int colorSurvive;
    public int gameStatus = 0;
    public int timer;
    public GameObject startPanel;
    public GameObject endPanel;
    public GameObject pausePanel;
    public GameObject timerText;
    public GameObject endText;
    public GameObject[] plates;
    public int[] platesColors;
    public GameObject img;
    public GameObject p1;
    public GameObject p2;
    
    private void Awake()
    {
        plates = GameObject.FindGameObjectsWithTag("Plate");
    }

    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space) && gameStatus == 0 )
        {
            startPanel.SetActive( false );
            img.SetActive( true );
            gameStatus = 1;
            Timer();
            Plates(2);
        }
        if ( gameStatus == 2 )
        {
            if ( Input.GetKeyDown(KeyCode.Space) ) {
                SceneManager.LoadScene(0);
            }
        }
        if (gameStatus == 1)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameStatus = 3;
                pausePanel.SetActive( true );
            }
        }
    }

    public void PauseOff()
    {
        gameStatus = 1;
        pausePanel.SetActive( false );
        Invoke(nameof(Timer), 0.5f);
    }
    private void Timer()
    {
        if ( gameStatus == 1) {
            if (timer > 0)
            {
                if (timer % 10 == 0 && timer % 100 != 0 && (timer + 80) % 100 != 0 && (timer + 90) % 100 != 0)
                {
                    if ((timer + 10) % 100 == 0)
                    {

                        if (p1.activeInHierarchy != true || p2.activeInHierarchy != true)
                        {

                            Debug.Log(p2);
                            timer = 0;
                            End();
                        }
                        foreach (var plate in plates)
                        {
                            plate.SetActive(true);
                        }
                    }
                    foreach (var plate in plates)
                    {
                        plate.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    }
                    int count = Random.Range(4, 6);
                    for (int i = 0; i < count; i++)
                    {
                        int show = Random.Range(0, 25);
                        plates[show].GetComponent<Renderer>().material.color = colors[platesColors[show]];
                    }
                }
                else if ((timer + 80) % 100 == 0)
                {
                    colorSurvive = Random.Range(0, colUsed);

                    img.GetComponent<Image>().color = colors[colorSurvive];
                    foreach (var plate in plates)
                    {
                        plate.GetComponent<Renderer>().material.color = Color.white;
                    }
                }
                else if (timer % 100 == 0)
                {
                    img.GetComponent<Image>().color = Color.white;
                    if (timer != 600)
                    {
                        for (int i = 0; i < 25; i++)
                        {
                            if (platesColors[i] != colorSurvive)
                            {
                                plates[i].SetActive(false);
                            }
                            else
                            {
                                plates[i].GetComponent<Renderer>().material.color = colors[colorSurvive];
                            }
                        }

                        Plates(Random.Range(3, 5));
                    }
                }

                timer--;
                Invoke(nameof(Timer), 0.1f);
                timerText.GetComponent<TMP_Text>().text = ((float)timer / 10).ToString();

                if (timer < 30)
                {
                    timerText.GetComponent<TMP_Text>().color = new Color(1, 0.2f, 0.1f, 1.0f);
                }
                else if (timer < 100)
                {
                    timerText.GetComponent<TMP_Text>().color = new Color(1, 0.4f, 0.1f, 1.0f);
                }
            }
            else
            {
                for (int i = 0; i < 25; i++)
                {
                    if (platesColors[i] != colorSurvive)
                    {
                        plates[i].SetActive(false);
                    }
                    else
                    {
                        plates[i].GetComponent<Renderer>().material.color = colors[colorSurvive];
                    }
                }

                Invoke(nameof(End), 2f);
            }
        }
    }
    private void End()
    {
        gameStatus = 2;

        if ( p1.activeInHierarchy == p2.activeInHierarchy )
        {
            endText.GetComponent<TMP_Text>().text = "Ничья";
        }
        else if ( p1.activeInHierarchy == true )
        {
            endText.GetComponent<TMP_Text>().text = "Первый игрок выйграл";
        } else
        {
            endText.GetComponent<TMP_Text>().text = "Второй игрок выйграл";
        }
        img.SetActive(false);
        timerText.SetActive( false );
        endPanel.SetActive( true );
    }
    private void Plates(int it)
    {
        if ( it > 4 )
        {
            it = 4;
        } else if ( it < 2 )
        {
            it = 2;
        }
        colUsed = it;
        int iter = 25;
        if ( it == 2 )
        {
            colCount[0] = 13;
            colCount[1] = 12;
            colCount[2] = 0;
            colCount[3] = 0;
            
        } else if ( it == 3 )
        {
            colCount[0] = 9;
            colCount[1] = 8;
            colCount[2] = 8;
            colCount[3] = 0;
        } else if ( it == 4 )
        {
            colCount[0] = 7;
            colCount[1] = 6;
            colCount[2] = 6;
            colCount[3] = 6;
        }
        foreach (var plate in plates)
        {
            int col = Random.Range(1, iter + 1);
            Debug.Log(25 - iter);
            if (col <= colCount[0])
            {
                platesColors[25 - iter] = 0;
                colCount[0]--;
            } else if (col <= colCount[0] + colCount[1])
            {
                platesColors[25 - iter] = 1;
                colCount[1]--;
            } else if (col <= colCount[0] + colCount[1] + colCount[2])
            {
                platesColors[25 - iter] = 2;
                colCount[2]--;
            } else
            {
                platesColors[25 - iter] = 3;
                colCount[3]--;
            }
            iter--;
        }
    }
}
