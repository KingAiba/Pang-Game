using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Level1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBall()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-9, 9), 9, 0);

        Instantiate(ballPrefab, spawnPos, ballPrefab.transform.rotation);
    }

    public void Level1()
    {
        Invoke("SpawnBall", 6);
        Invoke("SpawnBall", 12);
    }
}
