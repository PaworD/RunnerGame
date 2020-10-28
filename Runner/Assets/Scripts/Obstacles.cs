using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private float EnvLength = 90f;
    public GameObject obstacle;
    

    void Start()
    {

        Vector3 spawnPosition = new Vector3(Random.Range(-5f, -1.5f), -0.5f, Random.Range(transform.position.z, transform.position.z + 30f));

       

        //instantiating obstacle in random position

        GameObject inst = Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
        inst.transform.parent = gameObject.transform;
    }

}
