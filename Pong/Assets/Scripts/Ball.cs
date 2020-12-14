﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{ 

    public float speed = 30;

    private Rigidbody2D rigidBody;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //패들에 맞을 때
        if ((collision.gameObject.name == "LeftPaddle") || 
            (collision.gameObject.name == "RightPaddle"))
        {

            handlePaddleHit(collision);

        }

        //위아래 벽에 맞았을 때
        if ((collision.gameObject.name == "TopWall") ||
            (collision.gameObject.name == "BottomWall"))
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.WallSound);
        }

        //점수 판정
        if ((collision.gameObject.name == "LeftWall") ||
            (collision.gameObject.name == "RightWall"))
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.goalBloop);

            //todo 점수 ui

            transform.position = new Vector2(0, 0);
        }
    }

    void handlePaddleHit(Collision2D col)
    {
        float y = ballHitPaddleWhere(transform.position,
            col.transform.position, col.collider.bounds.size.y);

        Vector2 dir = new Vector2();

        if(col.gameObject.name == "LeftPaddle")
        {
            dir = new Vector2(1, y).normalized;
        }

        if (col.gameObject.name == "RightPaddle")
        {
            dir = new Vector2(-1, y).normalized;
        }

        rigidBody.velocity = dir * speed;

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.HitPaddleBloop);

    }

    float ballHitPaddleWhere(Vector2 ball, Vector2 paddle,
        float paddleHeight)
    {
        return (ball.y = paddle.y) / paddleHeight;
    }
    

}