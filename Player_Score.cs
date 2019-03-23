using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour
{
    private float timeLeft = 120;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;

    void Start()
    {
        Data_Management.datamanagement.LoadData(); 
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
        if (timeLeft < 0.1f)
            SceneManager.LoadScene("Main_Scene");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EndLevel")
        {
            CountScore();
            Data_Management.datamanagement.SaveData();
        }
            
        if (collision.gameObject.name == "Coins")
        {
            playerScore += 10;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "Box2")
        {
            playerScore += 20;
            Destroy(collision.gameObject);
        }
    }

    void CountScore()
    {
        //Debug.Log("Data says hight score is currently " + Data_Management.datamanagement.hightScore);
        playerScore = playerScore + (int)(timeLeft * 10);
        Data_Management.datamanagement.hightScore = playerScore + (int)(timeLeft * 10);
        Data_Management.datamanagement.SaveData();
        //Debug.Log("Now that we have added the score to Data says hight score is currently " + Data_Management.datamanagement.hightScore);
    }
}
