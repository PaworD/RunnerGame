using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{

    public GameObject[] Environments;
    private float zSpawn = 90;
    private float envLength = 90;

    private List<GameObject> active = new List<GameObject>();

    public Transform playerPosition;

    // Start is called before the first frame update
    void Start()
    {
            InitializeNewEnvironment();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPosition.position.z -35 > zSpawn - (Environments.Length * envLength))
        {
            InitializeNewEnvironment();
            DeletePassedEnvironment();
        }
    }

    private void DeletePassedEnvironment()
    {
        Destroy(active[0]);
        active.RemoveAt(0);

        if(playerPosition.position.z > (active[1].transform.position.z + active[2].transform.position.z) / 3)
        {
            Destroy(active[1]);
            active.RemoveAt(1);

        }
    }

    private void InitializeNewEnvironment()
    {
        GameObject activeEnvironmentFirst = Instantiate(Environments[0], transform.forward * zSpawn, transform.rotation);
        GameObject activeEnvironmentSecond = Instantiate(Environments[0], activeEnvironmentFirst.transform.forward * zSpawn, transform.rotation);
        active.Add(activeEnvironmentFirst);
        active.Add(activeEnvironmentSecond);
        zSpawn += envLength;
    }

}
