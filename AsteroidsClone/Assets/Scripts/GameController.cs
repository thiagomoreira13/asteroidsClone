using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject enemy;

    private int score;
    private int hiscore;
    private int enemiesRemaining;
    private int lives;
    private int wave;
    private int increaseEachWave = 4;

    public Text scoreText;
    public Text livesText;
    public Text waveText;
    public Text hiscoreText;

    // Use this for initialization
    void Start()
    {

        hiscore = PlayerPrefs.GetInt("hiscore", 0);
        BeginGame();
    }

    // Update is called once per frame
    void Update()
    {

        // Quit if player presses escape
        if (Input.GetKey("escape"))
            Application.Quit();

    }

    void BeginGame()
    {

        score = 0;
        lives = 3;
        wave = 1;

        // Prepare the HUD
        scoreText.text = "SCORE:" + score;
        hiscoreText.text = "HI-SCORE: " + hiscore;
        livesText.text = "LIVES: " + lives;
        waveText.text = "WAVE: " + wave;

        SpawnEnemies();
    }

    void SpawnEnemies()
    {

        DestroyExistingEnemies();

        // Decide how many enemies to spawn
        // If any enemies left over from previous game, subtract them
        enemiesRemaining = (wave * increaseEachWave);

        for (int i = 0; i < enemiesRemaining; i++)
        {

            // Spawn an enemy
            Instantiate(enemy,
                new Vector3(Random.Range(-9.0f, 9.0f),
                    Random.Range(-6.0f, 6.0f), 0),
                Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));

        }

        waveText.text = "WAVE: " + wave;
    }

    public void IncrementScore()
    {
        score++;

        scoreText.text = "SCORE:" + score;

        if (score > hiscore)
        {
            hiscore = score;
            hiscoreText.text = "HI-SCORE: " + hiscore;

            // Save the new hiscore
            PlayerPrefs.SetInt("hiscore", hiscore);
        }

        // Has player destroyed all enemies?
        if (enemiesRemaining < 1)
        {

            // Start next wave
            wave++;
            SpawnEnemies();

        }
    }

    public void DecrementLives()
    {
        lives--;
        livesText.text = "LIVES: " + lives;

        // Has player run out of lives?
        if (lives < 1)
        {
            // Restart the game
            BeginGame();
        }
    }

    public void DecrementEnemies()
    {
        enemiesRemaining--;
    }

    public void SplitEnemy()
    {
        // Two extra enemies
        // - big one
        // + 3 little ones
        // = 2
        enemiesRemaining += 2;

    }

    void DestroyExistingEnemies()
    {
        GameObject[] enemies =
            GameObject.FindGameObjectsWithTag("Enemy1");

        foreach (GameObject current in enemies)
        {
            GameObject.Destroy(current);
        }

        GameObject[] enemies2 =
            GameObject.FindGameObjectsWithTag("Enemy2");

        foreach (GameObject current in enemies2)
        {
            GameObject.Destroy(current);
        }
    }
}
