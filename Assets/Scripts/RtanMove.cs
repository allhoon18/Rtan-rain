using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RtanMove : MonoBehaviour
{
    [SerializeField] float speed;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if(Input.GetAxis("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    void Move()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            float dir = Input.GetAxis("Horizontal");

            transform.Translate(new Vector3(dir * speed * Time.deltaTime, 0, 0));
        }
    }
}
