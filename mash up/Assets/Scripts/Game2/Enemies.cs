using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enmy : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private GameObject bullet_prefab;
    [SerializeField]
    private Transform spawn;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Spawn_Bullet", 5f, 0.05f);
    }

    private void Spawn_Bullet()
    {
        Vector3 direction = new Vector3(Random.Range(-9, 10), 0, Random.Range(-9, 10)) - transform.position;
        direction = direction.normalized;
        Debug.Log(transform.position);
        GameObject bullet = Instantiate(bullet_prefab, spawn.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = direction * 50;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shoot"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
