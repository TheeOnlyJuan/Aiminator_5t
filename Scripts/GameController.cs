using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
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

    public Text scoreText;
    public Text streakText;
    public Text hitNumberText;
    public Text hitRateText;

    private float startTime;
    private float nextTarget;
    private int targetNumber;
    private int hitNumber;
    private int missCounter;

    private int streak;
    private int score;

    // The method to generate target at random location on the map
    void SpawnTargets()
    {

        float xPosition = Random.Range(xRangeMin, xRangeMax);
        float yPosition = Random.Range(xRangeMin, xRangeMax);
        float zPosition = Random.Range(0, 5);
        Vector3 newSpawnPosition = new Vector3(xPosition, yPosition, 500);
        Instantiate(Target, newSpawnPosition, Quaternion.identity);

    }


    // Start is called before the first frame update
    void Start()
    {
        // first target spawn is delayed
        new WaitForSeconds(startWaitTime);
        startTime = Time.time;
        nextTarget = 0;
        targetNumber = 0;

        // setup display text
        scoreText.text = "Score: 0";
        streakText.text = "Current Streak: 0";
        hitNumberText.text = "You hit: 0";
        hitRateText.text = "Hit rate is: 0%";

        //variable set up
        score = 0;
        streak = 0;

        //
        //curNumTargets = maxNumTargets;
        for(int i = 0; i < maxNumTargets; i++)
        {
            SpawnTargets();
        }
    }

    // Update is called once per frame
    void Update()
    {

       // Randomly generate targets 
       //if (curNumTargets <= maxNumTargets)
       //{
       //     //SpawnTargets();

       //     float xPosition = Random.Range(xRangeMin, xRangeMax);
       //     float yPosition = Random.Range(yRangeMin, yRangeMax);
       //     //float xPosition = 10;
       //     //float yPosition = 10;
       //     Vector3 newSpawnPosition = new Vector3(xPosition, yPosition, 0);
       //     Instantiate(Target, newSpawnPosition, Quaternion.identity);
       //     nextTarget = Time.time + timeInterval;
        
       // }
       // Display results
      
            
        hitNumberText.text = "You hit: " + hitNumber;
        scoreText.text = "Score : " + score;
        streakText.text = "Current Streak: " + streak;
        if (score > 0)
            {
            int hitPercent = (int)((float)hitNumber / (hitNumber + missCounter) * 100);
            hitRateText.text = "Hit rate is: " + hitPercent;
            //Debug.Log(hitPercent + "");
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
        //curNumTargets--;
        SpawnTargets();
    }

    //public void TargetNumberAddOne()
    //{
    //    targetNumber++;
    //}
    public void Miss()
    {
        streak = 0;
        missCounter++;
    }
}
