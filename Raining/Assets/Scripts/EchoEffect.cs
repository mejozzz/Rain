using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
    float timeBtwSpawn;
    [SerializeField] float startTimesBtwSpawn;

    [SerializeField] GameObject echo;

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            //spawn echo 
            Instantiate(echo, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimesBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
