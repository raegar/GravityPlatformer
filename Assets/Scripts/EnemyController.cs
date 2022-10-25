using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float PatrolSpeed = 300f;
    public float PatrolDuration = 3f;

    float patrolTimer;

    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        this.direction = Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        patrolTimer += Time.deltaTime;

        if(patrolTimer >= PatrolDuration)
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            patrolTimer = 0;
            direction *= -1;
        }

        this.GetComponent<Rigidbody2D>().AddForce(this.direction * PatrolSpeed * Time.deltaTime);
    }
}
