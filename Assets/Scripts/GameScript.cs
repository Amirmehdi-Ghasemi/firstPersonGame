using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameScript : MonoBehaviour
{

    public GameObject player, enemy, finishLine, losePanel, winPanel, mainCamera;
    public TextMeshProUGUI infoText;
    public float timer = 2f;

    bool showDistance = true;
    // level ongoing = 0, level won = 1, level lost = 2
    byte levelStatus = 0;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (!PauseMenuScript.isPaused)
        {
            if (showDistance)
            {
                infoText.text = "Distance: " + Mathf.Round(Vector3.Distance(player.transform.position,
                finishLine.transform.position) / 4).ToString();
            }
            else
            {
                mainCamera.GetComponent<MouseLook>().enabled = false;
                Time.timeScale = 0.5f;
                timer -= Time.deltaTime;
            }
            if (player.transform.position.z >= finishLine.transform.position.z && levelStatus != 2)
            {
                levelStatus = 1;
                LevelWon();
            }
            if ((player.transform.position.z <= enemy.transform.position.z || player.transform.position.y <= -1) && levelStatus != 1)
            {
                levelStatus = 2;
                LevelLose();
            }
        }
    }

    void LevelWon()
    {
        showDistance = false;
        infoText.text = "Finished! Loading next level...";
        winPanel.SetActive(true);
        if (timer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void LevelLose()
    {
        showDistance = false;
        infoText.text = "You Died! Restarting...";
        losePanel.SetActive(true);
        if (timer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
