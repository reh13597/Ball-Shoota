using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    public GameObject winMenuUI;
    public Camera playerCamera;
    public TextMeshProUGUI scoreText;

    int score;

    void Start()
    {
        score = 0;
        SetScoreText();
        winMenuUI.SetActive(false);
    }

    void SetScoreText()
    {
        scoreText.text = "Enemies killed: " + score.ToString();
        Debug.Log("Score: " + this.score);
        if (score >= 15)
        {
            YouWin();
        }
    }

    void YouWin()
    {
        winMenuUI.SetActive(true);
        Time.timeScale = 0f;
        playerCamera.GetComponent<MouseLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnCollisionEnter(Collision col)
    {
        Debug.Log("DLSKJf");
        if (col.collider.CompareTag("Enemy"))
        {
            //Destroy(col.collider.gameObject);
            this.score = this.score + 1;
            Debug.Log("Score: " + this.score);
            SetScoreText();
        }

    }
}