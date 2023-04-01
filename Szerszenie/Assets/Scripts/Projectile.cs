using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public Vector3 direction;
    public System.Action destroyed;
    public new BoxCollider2D collider { get; private set; }

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.destroyed.Invoke();
        Destroy(this.gameObject);
    }
}