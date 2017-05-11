using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Public Vars
    public int p1Score;
    public int p2Score;
    public int scoreLimit;
    public Text p1Text;
    public Text p2Text;
    public bool isPVP;
    public GameObject ball;

    //Unity Funcitons
    private void Start()
    {
        p1Score = 0;
        p2Score = 0;

        StartCoroutine(begin());
    }

    //Class Functions
    public void displayScore()
    {
        p1Text.text = p1Score.ToString();
        p2Text.text = p2Score.ToString();
        if (p1Score > scoreLimit - 1)
        {
            p1Text.text = "WIN";
            p2Text.text = "LOSE";
        }
        else if(p2Score > scoreLimit - 1)
        {
            p1Text.text = "LOSE";
            p2Text.text = "WIN";
        }

        StartCoroutine(end());
    }

    //Coroutine Functions
    private IEnumerator begin()
    {
        p1Text.text = "P1";

        if (isPVP)
            p2Text.text = "P2";
        else
            p2Text.text = "CPU";

        yield return new WaitForSeconds(3);

        p1Text.text = p1Score.ToString();
        p2Text.text = p2Score.ToString();

        Instantiate(ball);
    }

    private IEnumerator end()
    {
        Destroy(ball);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }
}
