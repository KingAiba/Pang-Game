using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float projectileSpeed;
    public float yLimit = 8.0f;
    public float startScale = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scaleIncrease = transform.localScale.y + transform.localScale.y * projectileSpeed * Time.deltaTime;
        transform.localScale = new Vector3(transform.localScale.x, 
            scaleIncrease, 
            transform.localScale.z);

        transform.position = new Vector3(transform.position.x, scaleIncrease, transform.position.z);
        //if

        if(transform.position.y >= yLimit)
        {
            Destroy(gameObject);
        }
    }
}
