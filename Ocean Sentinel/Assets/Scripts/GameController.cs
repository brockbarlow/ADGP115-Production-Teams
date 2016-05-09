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


    // Determinds if the scene can be restarted.
    private bool restart;
    // Is the game over?
    private bool gameOver;
    // Show I spawn the next wave?
    private bool spawnWave;

    // The UI text element for restart.
    [SerializeField]
    private Text restartText;
    // The UI text element for game over.
    [SerializeField]
    private Text gameOverText;
    // The UI text for selection.
    [SerializeField]
    private Text selectionText;

    // These are the power-up buttons.
    [SerializeField]
    private Button UIButton1;
    [SerializeField]
    private Button UIButton2;
    [SerializeField]
    private Button UIButton3;
    [SerializeField]
    private Button UIButton4;

    void Start ()
    {
        startWait = 3;
        spawnWait = 1;
        numbEnemies = 5;

        restart = false;
        gameOver = false;
        spawnWave = true;

        restartText.text = "";
        gameOverText.text = "";
        selectionText.text = "";

        UIButton1.interactable = false;
        UIButton2.interactable = false;
        UIButton3.interactable = false;
        UIButton4.interactable = false;

        StartCoroutine(SpawnWaves());
	}
	
	void Update ()
    {
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
    }

    // This couroutine will spawn the enemies in the game.
    IEnumerator SpawnWaves()
    {
        // I wait a sec before starting this while loop. Why? For courtesy, the player is about to be stormed with wave after wave of enemies!
        yield return new WaitForSeconds(startWait);
        // Spawn the wave.
        while(spawnWave)
        {
            for (int i = 0; i < numbEnemies; i++)
            {
                Vector3 spawnPosition = new Vector3();
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(EnemyPre, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            // Pause the couroutine.
            spawnWave = false;

            if (FindObjectsOfType())
            {
                UIButton1.interactable = true;
                UIButton2.interactable = true;
                UIButton3.interactable = true;
                UIButton4.interactable = true;
                selectionText.text = "Select Upgrade: ";
            }
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
