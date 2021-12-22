using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3 dir;

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().MovePosition(transform.position + (dir * speed));
    }

    public Vector3 targetVactor
    {
        set
        {
            dir = (value - transform.position).normalized;

            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public float Speed
    {
        set
        {
            speed = value;
        }
    }
}
