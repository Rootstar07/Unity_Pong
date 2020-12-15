using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Ball2 : MonoBehaviour
{

    public float speed = 30;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector2.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "LeftPaddle")
        {
            handlePaddleHit(collision);
        }
    }

    void handlePaddleHit(Collision2D col)
    {
        Vector2 dir;

        dir = new Vector2(1, 0).normalized;


        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }

}
