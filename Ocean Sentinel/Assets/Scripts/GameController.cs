using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    // This is a list of empty gameObjects that have a transform. Used for spawn positions.
    [SerializeField]
    private GameObject[] spawnPoints;

    // This is the Enemy Prefab.
    [SerializeField]
    private GameObject EnemyPre;

    // Use for the Leaderboard Serializing.
    [SerializeField]
    private GameObject Leader;

    // This is the number of enemies that will be spawned.
    private float numbEnemies;
    // This is the amount of time between each enemy being spawned.
    private float spawnWait;
    // This is the amount of Gold the Player has.
    public float Gold;
    // This is the wave the Player is on.
    private float numbWaves;

    // Show I spawn the next wave?
    public bool spawnWave;

    // The UI text for the wave.
    [SerializeField]
    private Text waveText;
    // The UI text for the gold.
    [SerializeField]
    private Text goldText;
    // The UI text for Base HP.
    [SerializeField]
    private Text baseHPText;
    // The UI text for Base Armor.
    [SerializeField]
    private Text baseArmorText;
    // The UI text for the amount of current enemies.
    [SerializeField]
    private Text numbEnemiesText;

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
    [SerializeField]
    private GameObject TheBase;

    void Start ()
    {
        spawnWait = 1;
        numbEnemies = 5;
        numbWaves = 1;
        Gold = 0;

        spawnWave = true;

        UIButton1.SetActive(false);
        UIButton2.SetActive(false);
        UIButton3.SetActive(false);
        UIButton4.SetActive(false);
        SkipButton.SetActive(false);

        StartCoroutine(SpawnWaves());
	}
	
	void Update ()
    {
        waveText.text = "Wave: " + numbWaves;
        goldText.text = "Gold: " + Gold;
        baseHPText.text = "HP: " + TheBase.GetComponent<Base>().HP;
        baseArmorText.text = "Armor: " + TheBase.GetComponent<Base>().Armor;
        numbEnemiesText.text = "Enemies Remaining: " + GameObject.FindGameObjectsWithTag("Enemy").Length;



        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            UIButton1.SetActive(true);
            UIButton2.SetActive(true);
            UIButton3.SetActive(true);
            UIButton4.SetActive(true);
            SkipButton.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().MoveVelocity = 1;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().projectileRate = 1;
            DestroyAll(GameObject.FindGameObjectsWithTag("Projectile"));
        }

        if (numbWaves > 6)
        {
            YouWin();
        }
    }

    // This couroutine will spawn the enemies in the game.
    public IEnumerator SpawnWaves()
    {
        // Spawn the wave.
            while (spawnWave)
            {
                int g = 0;
                UIButton1.SetActive(false);
                UIButton2.SetActive(false);
                UIButton3.SetActive(false);
                UIButton4.SetActive(false);
                SkipButton.SetActive(false);

                for (int i = 0; i < numbEnemies; i++)
                {
                    Vector3 spawnPosition = spawnPoints[g].transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(EnemyPre, spawnPosition, spawnRotation);
                    g++;
                    if (g >= spawnPoints.Length)
                    {
                         g = 0;
                    }
                    yield return new WaitForSeconds(spawnWait);
                }
                // Increase the wave count.
                numbWaves++;
                // Increase the number of enemies next wave.
                numbEnemies *= 2;
                // Pause the couroutine.
                spawnWave = false;
            }
    }

    public void GameOver()
    {
        Leader.GetComponent<Serializer>().Scores.Add(numbWaves);
        Leader.GetComponent<Serializer>().Scores.Sort(MySorter);
        Leader.GetComponent<Serializer>().Save();
        SceneManager.LoadScene("GameOver");
    }

    public void YouWin()
    {
        SceneManager.LoadScene("Win");
    }

    public int MySorter(float a, float b)
    {
        if (a > b)
            return -1;
        else if(a < b)
            return 1;

        return 0;
    }

    void DestroyAll(GameObject[] a)
    {
        foreach(GameObject b in a)
        {
            Destroy(b);
        }   
    }
}
