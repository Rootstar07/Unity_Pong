using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMove : MonoBehaviour
{

    float speed = 30;

    private void FixedUpdate()
    {

        float vertPress = Input.GetAxisRaw("Vertical");

        GetComponent<Rigidbody2D>().velocity = 
            new Vector2(0, vertPress) * speed;

    }

}
