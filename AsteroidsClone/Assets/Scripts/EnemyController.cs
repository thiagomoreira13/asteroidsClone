using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AudioClip destroy;
    public GameObject smallEnemy;

    private GameController gameController;

    // Use this for initialization
    void Start()
    {

        // Get a reference to the game controller object and the script
        GameObject gameControllerObject =
            GameObject.FindWithTag("GameController");

        gameController =
            gameControllerObject.GetComponent<GameController>();

        // Push the enemy in the direction it is facing
        GetComponent<Rigidbody2D>()
            .AddForce(transform.up * Random.Range(-50.0f, 150.0f));

        // Give a random angular velocity/rotation
        GetComponent<Rigidbody2D>()
            .angularVelocity = Random.Range(-0.0f, 90.0f);

    }

    void OnCollisionEnter2D(Collision2D c)
    {

        if (c.gameObject.tag.Equals("Fireball"))
        {

            // Destroy the bullet
            Destroy(c.gameObject);

            // If large enemy spawn new ones
            if (tag.Equals("Enemy1"))
            {
                // Spawn small enemies
                Instantiate(smallEnemy,
                    new Vector3(transform.position.x - .5f,
                        transform.position.y - .5f, 0),
                        Quaternion.Euler(0, 0, 90));

                // Spawn small enemies
                Instantiate(smallEnemy,
                    new Vector3(transform.position.x + .5f,
                        transform.position.y + .0f, 0),
                        Quaternion.Euler(0, 0, 0));

                // Spawn small enemies
                Instantiate(smallEnemy,
                    new Vector3(transform.position.x + .5f,
                        transform.position.y - .5f, 0),
                        Quaternion.Euler(0, 0, 270));

                gameController.SplitEnemy(); // +2

            }
            else
            {
                // Just a small enemy destroyed
                gameController.DecrementEnemies();
            }

            // Play a sound
            AudioSource.PlayClipAtPoint(
                destroy, Camera.main.transform.position);

            // Add to the score
            gameController.IncrementScore();

            // Destroy the current enemy
            Destroy(gameObject);

        }

    }
}
