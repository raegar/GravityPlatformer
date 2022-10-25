using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void OnHitSpikeAction();
    public delegate void OnHitCoinAction();

    public OnHitSpikeAction OnHitSpike;
    public OnHitCoinAction OnHitCoin;

    float speed = 1000;

    Vector3 leftBound;
    Vector3 rightBound;
    bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        if (Physics2D.gravity.y > 0) 
        {
            Physics2D.gravity *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if(Input.GetKey("left") || Input.GetKey("a"))
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed * Time.deltaTime);
        
        if(Input.GetKey("right") || Input.GetKey("d"))
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed * Time.deltaTime);

        if(Input.GetKeyDown("up") || Input.GetKey("w"))
            InvertGravity();
    }

    private void InvertGravity()
    {
        Physics2D.gravity *= -1;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<SpikeController>() != null)
        {
            if (OnHitSpike != null) 
            {
                OnHitSpike();
            }
        }
        else if(collision.gameObject.GetComponent<EnemyController>() != null) 
        {
            if(OnHitSpike != null)
            {
                OnHitSpike();
            }
        }

        else if(collision.gameObject.GetComponent<CoinController>() != null) 
        {
            GameObject.Destroy(collision.gameObject);

            if(OnHitCoin != null)
            {
                OnHitCoin();
            }
        }
    }
}
