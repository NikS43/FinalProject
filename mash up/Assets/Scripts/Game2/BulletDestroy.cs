using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Destroy : MonoBehaviour
{
    void Start()
    {
        Invoke("Destroy_Bullet", 3f);
    }

    private void Destroy_Bullet()
    {
        Destroy(gameObject);
    }
}
