using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclePrefab;
    private Vector3 spawnPosition = new Vector3(0, 0, 30);
    private int spawnArea;
    private int spawnRotation;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 2, 2);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerController.gameOver == false)
        {
            spawnArea = Random.Range(0, 2);
            if (spawnArea == 0)
            {
                spawnPosition = new Vector3(0, Random.Range(0, 3), 30);
                Debug.Log("Bottom");
            }
            if (spawnArea == 1)
            {
                spawnPosition = new Vector3(0, Random.Range(20, 16), 30);
                Debug.Log("Top");
            }
            GameObject currentObstacle = Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
            if (spawnArea == 1)
            {
                currentObstacle.transform.Rotate(Vector3.forward, 180);
                currentObstacle.transform.Rotate(Vector3.up, 180);
            }
        }
    }
}
