using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay;
    public float countDown;
    
    public Text gameOver, message;

    public void EndGame ()
    {
        countDown = restartDelay;
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over!");          
            Invoke("Restart", restartDelay);
            StartCoroutine(CountDownHandler());
        }
    }

    public void SetText()
    {
        gameOver.text = "Game Over!";
        message.text = "Your Game Will Restart In " + countDown.ToString();
    }

    IEnumerator CountDownHandler()
    {
        while(countDown > 0)
        {
            SetText();
            yield return new WaitForSeconds(1f);
            countDown -= 1;
        }
    }
        

    void Update ()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart();
            }
        }

    public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
