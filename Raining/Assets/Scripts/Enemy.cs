using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;

    float speed;

    Player playerScript;

    public int damage;

    public GameObject explosion;

    private Transform player;
    Vector2 playerPos;

    float timeBtwSpawn;
    [SerializeField] float startTimesBtwSpawn;

    [SerializeField] GameObject echo;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerPos = player.position;
    }

    // Update is called once per frame
    void Update()
    {   // Move Vertical Down
        //transform.Translate(Vector2.down * speed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);

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

    void OnTriggerEnter2D(Collider2D hitObject)
    {

        if(hitObject.tag == "Player") {
            playerScript.TakeDamage(damage);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (hitObject.tag == "Ground") {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }


}
