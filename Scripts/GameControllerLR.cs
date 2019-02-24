using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerLR : MonoBehaviour
{
    public float xRangeMin;
    public float xRangeMax;
    public float yRangeMin;
    public float yRangeMax;
    public float startWaitTime;
    public float timeInterval;
    public float maxNumTargets;
    //public float curNumTargets;


    public float gameTime;
    public GameObject Target;
    //public GameObject Target2;
    //public GameObject Target3;
    //public GameObject Target4;
    //public GameObject Target5;

    public Text scoreText;
    public Text streakText;
    public Text hitNumberText;
    public Text hitRateText;

    private float startTime;
   
    private int targetNumber;
    private int hitNumber;
    private int missCounter;
    int hitPercent = 100;

    private int streak;
    private int score;

    // The method to generate target at random location on the map
    void SpawnTargets()
    {
        int side = Random.Range(0 , 2);
        float size = Random.Range(1 , 5);
        if (side % 2 == 0)
        {
            float yPosition = Random.Range(yRangeMin, yRangeMax);
            Vector3 newSpawnPoint = new Vector3(-65, yPosition, size);
            GameObject test = Instantiate(Target, newSpawnPoint, Quaternion.identity);
            test.transform.localScale = new Vector3(2 / size, 2 / size, 1);
        }else
        {
            float yPosition = Random.Range(yRangeMin, yRangeMax);
            Vector3 newSpawnPoint = new Vector3(65, yPosition, size);
            GameObject test = Instantiate(Target, newSpawnPoint, Quaternion.identity);
            test.transform.localScale = new Vector3(2 / size, 2 / size, 1);
        }
        //float xPosition = Random.Range(xRangeMin, xRangeMax);
        //float yPosition = Random.Range(xRangeMin, xRangeMax);
        
        //switch (zPosition)
        //{
        //    case 0:
        //        Instantiate(Target, newSpawnPosition, Quaternion.identity);
        //        break;
        //    case 1:
        //        Instantiate(Target2, newSpawnPosition, Quaternion.identity);
        //        break;
        //    case 2:
        //        Instantiate(Target3, newSpawnPosition, Quaternion.identity);
        //        break;
        //    case 3:
        //        Instantiate(Target4, newSpawnPosition, Quaternion.identity);
        //        break;
        //    case 4:
        //        Instantiate(Target5, newSpawnPosition, Quaternion.identity);
        //        break;
        //}
        //Instantiate(Target, newSpawnPosition, Quaternion.identity);

    }


    // Start is called before the first frame update
    void Start()
    {
        //set game mode
        PlayerStats.CurrentGame = "LR";
        // first target spawn is delayed
        Cursor.visible = false;
        new WaitForSeconds(startWaitTime);
        startTime = Time.time;
        targetNumber = 0;

        // setup display text
        scoreText.text = "Score: 0";
        streakText.text = "Current Streak: 0";
        hitNumberText.text = "You hit: 0";
        hitRateText.text = "Hit rate is: 0%";

        //variable set up
        score = 0;
        streak = 0;

        for (int i = 0; i < maxNumTargets; i++)
        {
            SpawnTargets();
        }

        //GameObject test = Instantiate(Target, new Vector3(10, 10, 1), Quaternion.identity);
        //test.transform.localScale = new Vector3(.25f,.25f,1);

    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - startTime) >= gameTime)
        {
            Cursor.visible = true;
            new WaitForSeconds(2);
            PlayerStats.Kills = hitNumber;
            PlayerStats.Score = score;
            PlayerStats.Accuracy = hitPercent;
            PlayerStats.Streak = streak;
            PlayerStats.Misses = missCounter;
            SceneManager.LoadScene("Results");
        }
        hitNumberText.text = "You hit: " + hitNumber;
        scoreText.text = "Score : " + score;
        streakText.text = "Current Streak: " + streak;
        if (score > 0)
            {
            hitPercent = (int)((float)hitNumber / (hitNumber + missCounter) * 100);
            hitRateText.text = "Hit rate is: " + hitPercent;
        } else
            {
                hitRateText.text = "Hit rate is: 0%";
            }
        
   }

    public int getTargetNumber()
    {
        return targetNumber;
    }

    // Called when a target is hit;
    public void HitNumberPlusOne()
    {
        score += 1 + streak / 5;
        streak++;
        hitNumber++;
        GetComponent<AudioSource>().Play();
        SpawnTargets();
    }
    public void Miss()
    {
        streak = 0;
        missCounter++;
    }
}
