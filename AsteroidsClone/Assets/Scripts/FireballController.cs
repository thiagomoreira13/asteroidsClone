using UnityEngine;

public class FireballController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Set the bullet to destroy itself after 1 seconds
        Destroy(gameObject, 1.2f);

        // Push the bullet in the direction it is facing
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 600);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
