using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Rain : MonoBehaviour
{
    public float drop_speed = 10;
    public Transform _target;
    public int score;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale *= Random.Range(0.2f, 0.8f);
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(score == 1)
        {
            spriteRenderer.color = new Color(112f / 255f, 221f / 255f, 255f / 255f, Random.Range(100f, 255f) / 255f);
        }
        else
        {
            spriteRenderer.color = new Color(1, 0, 160f / 255f, Random.Range(100f, 255f) / 255f);
        }

        drop_speed = Random.Range(3f, 12f);

    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1 * drop_speed * Time.deltaTime, 0));

        Vector3 to_target = _target.position - transform.position;
        float distace = to_target.magnitude;
        
        if (distace < (transform.localScale.x/2 + _target.localScale.x/2))
        {
            Debug.Log("touch");
            Gamemanager.instance.AddScore(score);
            Destroy(gameObject);
        }

        if(transform.position.y < -4 + transform.localScale.y/2)
        {
            Destroy(gameObject);
        }
    }
}
