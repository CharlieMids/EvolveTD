using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 10f;
    private float countdown = 20f;
    private int waveNum = 1;
    public TextMeshProUGUI waveCountdownIndex;
    private bool waitForWave = false;

    //Setting the variables needed in this script

    void Update()
    {
        if (!waitForWave)
        //If the wave is not currently active
        {
            waveCountdownIndex.text = Mathf.Floor(countdown).ToString();
            //rounds the wave timer down to the whole number for the countdown timer
            waveCountdownIndex.fontSize = 72;
            //Sets the font size 
            if (countdown <= 0f)
            //Checks if the countdown is at 0 or below
            {
                waitForWave = true;
                //Stops the countdown
                waveCountdownIndex.fontSize = 36;
                //Sets the font size
                waveCountdownIndex.text = "Wave Spawning";
                //Changes the text to inform the player that the wave has started
                StartCoroutine(SpawnWave());
                //Starts the wave spawning
                countdown = timeBetweenWaves;
                //Sets the countdown to the above specified cooldown time
            }
            countdown -= Time.deltaTime;
            //Removes time since last check from the countdown timer
        }

    }

    IEnumerator SpawnWave()
    //Declares a coroutine
    {
        for (int i = 0; i < waveNum; i++)
        //repeats for the number of waves the player has reached
        {
            yield return new WaitForSeconds(3f);
            //waits for 3 seconds
            SpawnEnemy();
            //Calls the spawn enemy method
        }
        waveNum++;
        //increases the wave number
        waitForWave = false;
        //Starts the wave countdown
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        //Spawns an enemy on the spawnpoint gameobject
    }
}
