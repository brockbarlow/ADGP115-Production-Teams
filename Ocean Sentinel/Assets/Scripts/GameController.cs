using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    // This is the Enemy Prefab.
    [SerializeField]
    private GameObject EnemyPre;

    // This is the wait before the while loop in the couroutine begins.
    private float startWait;
    // This is the number of enemies that will be spawned.
    private float numbEnemies;
    // This is the amount of time between each enemy being spawned.
    private float spawnWait;
    // This is the amount of Gold the Player has.
    public float Gold;
    // This is the wave the Player is on.
    private float numbWaves;


    // Determinds if the scene can be restarted.
    private bool restart;
    // Is the game over?
    private bool gameOver;
    // Show I spawn the next wave?
    public bool spawnWave;

    // The UI text element for restart.
    [SerializeField]
    private Text restartText;
    // The UI text element for game over.
    [SerializeField]
    private Text gameOverText;
    // The UI text for selection.
    [SerializeField]
    private Text selectionText;
    // The UI text for the wave.
    [SerializeField]
    private Text waveText;
    // The UI text for the gold.
    [SerializeField]
    private Text goldText;

    // Location Enemies spawn at.
    [SerializeField]
    private Vector3 enemLoc;

    // These are the power-up buttons.
    [SerializeField]
    private GameObject UIButton1;
    [SerializeField]
    private GameObject UIButton2;
    [SerializeField]
    private GameObject UIButton3;
    [SerializeField]
    private GameObject UIButton4;
    [SerializeField]
    private GameObject SkipButton;

    void Start ()
    {
        startWait = 3;
        spawnWait = 1;
        numbEnemies = 5;
        numbWaves = 1;
        Gold = 0;

        restart = false;
        gameOver = false;
        spawnWave = true;

        restartText.text = "";
        gameOverText.text = "";

        UIButton1.SetActive(false);
        UIButton2.SetActive(false);
        UIButton3.SetActive(false);
        UIButton4.SetActive(false);
        SkipButton.SetActive(false);
        selectionText.text = "";

        StartCoroutine(SpawnWaves());
	}
	
	void Update ()
    {
        waveText.text = "Wave: " + numbWaves;
        goldText.text = "Gold: " + Gold;

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (gameOver)
        {
            restartText.text = "Press 'R' for Restart";
            restart = true;
        }

        if (numbWaves > 6)
        {
            YouWin();
        }
    }

    // This couroutine will spawn the enemies in the game.
    IEnumerator SpawnWaves()
    {
        // I wait a sec before starting this while loop. Why? For courtesy, the player is about to be stormed with wave after wave of enemies!
        yield return new WaitForSeconds(startWait);
        // Spawn the wave.
        while(spawnWave)
        {
            UIButton1.SetActive(false);
            UIButton2.SetActive(false);
            UIButton3.SetActive(false);
            UIButton4.SetActive(false);
            SkipButton.SetActive(false);
            selectionText.text = "";

            for (int i = 0; i < numbEnemies; i++)
            {
                Vector3 spawnPosition = enemLoc;
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(EnemyPre, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            // Increase the wave count.
            numbWaves++;
            // Increase the number of enemies next wave.
            numbEnemies *= 2;
            // Pause the couroutine.
            spawnWave = false;
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            UIButton1.SetActive(true);
            UIButton2.SetActive(true);
            UIButton3.SetActive(true);
            UIButton4.SetActive(true);
            SkipButton.SetActive(true);
            selectionText.text = "Select Upgrade: ";
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    public void YouWin()
    {
        SceneManager.LoadScene("Win");
    }
}
