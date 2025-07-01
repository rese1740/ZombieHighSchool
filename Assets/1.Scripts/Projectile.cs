using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 2f;
    private Vector3 direction;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    public void Launch(Vector3 dir)
    {
        direction = dir.normalized;
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
