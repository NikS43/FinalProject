using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private GameObject bullet_prefab;
    [SerializeField]
    private Transform spawn;
    private int Lives = 100;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Spawn_Bullet", 2f, 3f);
    }

    private void Spawn_Bullet()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction = direction.normalized;
        GameObject bullet =  Instantiate(bullet_prefab, spawn.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = direction * 50;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shoot"))
        {
            Lives -= 10;
            Destroy(collision.gameObject);
            if (Lives <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
