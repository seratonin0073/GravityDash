using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;
    private float minAngular = 35, maxAngular = 80;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        if (speed > 0) speed *= -1;            
        rb2d.AddForce(new Vector2(Random.Range(-1.5f, 1.5f), speed), ForceMode2D.Impulse);
       
        if(Random.Range(0,2) == 0)
            rb2d.angularVelocity = Random.Range(minAngular, maxAngular);
        else
            rb2d.angularVelocity = Random.Range(-minAngular, -maxAngular);

        Destroy(gameObject, 3f);
    }
}
