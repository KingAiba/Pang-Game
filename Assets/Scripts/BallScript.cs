using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float minSize = 1;
    public float maxSize = 6;

    public float forceMulti = 2;

    public GameObject ballPrefab;
    public Rigidbody ballRB;

    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        Vector3 forceDir = new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 0);
        ballRB.AddForce(forceDir * forceMulti, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(ballRB.velocity.magnitude > 30)
        {
            ballRB.AddForce(-ballRB.velocity.normalized * forceMulti, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            explosion.Play();

            if (transform.localScale.x > minSize)
            {
                Destroy(collision.gameObject);

                GameObject newball = Instantiate(ballPrefab, transform.position, ballPrefab.transform.rotation);
                newball.transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.x / 2);

                newball = Instantiate(ballPrefab, transform.position, ballPrefab.transform.rotation);
                newball.transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.x / 2);

                Destroy(gameObject);
            }
            else
            {

                Destroy(collision.gameObject);
                Destroy(gameObject);
            }

        }
        else if (collision.gameObject.CompareTag("Player")) 
        {
            collision.gameObject.GetComponent<PlayerController>().AddHealth(-1);
        }
        if(collision.gameObject.CompareTag("Ground"))
        {
            ballRB.AddForce(Vector3.up * forceMulti, ForceMode.Impulse);
        }
    }
}
