using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RtanMove : MonoBehaviour
{
    [SerializeField] float speed;

    SpriteRenderer spriteRenderer;

    float dir_key = 0;
    float dir_mouse = 1;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //MoveToWall();
        //FlipbyMouse();
        MovebyKey();
        FlipbyKey();

    }

    void MovebyKey()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            dir_key = Input.GetAxis("Horizontal");

            if (dir_key > 0 && transform.position.x > 2.4)
                return;
            else if (dir_key < 0 && transform.position.x < -2.4)
                return;

            transform.Translate(new Vector3(dir_key * speed * Time.deltaTime, 0, 0));
        }
    }

    void MoveToWall()
    {
        if (transform.position.x >= 2.4)
        {
            dir_mouse = -1;
            spriteRenderer.flipX = true;
        }
        else if (transform.position.x <= -2.4)
        {
            dir_mouse = 1;
            spriteRenderer.flipX = false;
        }

        transform.Translate(new Vector3(dir_mouse * speed * Time.deltaTime, 0, 0));
    }

    void FlipbyKey()
    {
        if (Input.GetAxis("Horizontal") < 0 || (spriteRenderer.flipX = false && Input.GetMouseButton(0)))
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0 || (spriteRenderer.flipX = true && Input.GetMouseButton(0)))
        {
            spriteRenderer.flipX = false;
        }
    }

    void FlipbyMouse()
    {
        if (Input.GetMouseButtonDown(0) && !spriteRenderer.flipX)
        {
            spriteRenderer.flipX = true;
            dir_mouse = -1;
        }
        else if (Input.GetMouseButtonDown(0) && spriteRenderer.flipX)
        {
            spriteRenderer.flipX = false;
            dir_mouse = 1;
        }
    }
}
