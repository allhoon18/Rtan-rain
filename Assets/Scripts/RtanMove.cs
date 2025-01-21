using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RtanMove : MonoBehaviour
{
    [SerializeField] float speed;

    SpriteRenderer spriteRenderer;

    float dir = 0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToWall();
        //FlipbyMouse();
        //MovebyKey();
        //FlipbyKey();
        

    }

    void MovebyKey()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            dir = Input.GetAxis("Horizontal");

            if (dir > 0 && transform.position.x > 2.4)
                return;
            else if (dir < 0 && transform.position.x < -2.4)
                return;

            transform.Translate(new Vector3(dir * speed * Time.deltaTime, 0, 0));
        }

        
        Flip(dir);
    }

    void MoveToWall()
    {
        if(dir == 0)
        {
            dir = 1;
        }

        if (transform.position.x > 2.4)
        {
            dir = -1;
            spriteRenderer.flipX = true;
        }
        
        if (transform.position.x < -2.4)
        {
            dir = 1;
            spriteRenderer.flipX = false;
        }

        transform.Translate(new Vector3(dir * speed * Time.deltaTime, 0, 0));
        FlipbyMouse();
        Flip(dir);
    }

    void FlipbyKey()
    {
        if (Input.GetAxis("Horizontal") < 0 || (spriteRenderer.flipX = false))
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0 || (spriteRenderer.flipX = true))
        {
            spriteRenderer.flipX = false;
        }
    }

    void FlipbyMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            dir *= -1;
        }
    }

    void Flip(float dir)
    {
        if(dir > 0)
        {
            spriteRenderer.flipX = false ;
        }
        else if(dir < 0)
        {
            spriteRenderer.flipX= true ;
        }
    }
}
