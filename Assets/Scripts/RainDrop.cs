using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDrop : MonoBehaviour
{
    public GameObject[] Raindrops = new GameObject[2];
    public Transform target;
    public Gamemanager gamemanager;

    [SerializeField] float waitTime = 0.5f;
    float lastTime = 0f;

    private void Start()
    {
        InvokeRepeating("MakeRain", 0f, waitTime);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Time.time - lastTime > waitTime)
        {
            MakeRain();
            lastTime = Time.time;
        }*/

    }

    void MakeRain()
    {
        Vector3 tempPos = transform.position;
        tempPos.x = Random.Range(-2.4f, 2.4f);

        int tempNum = Random.Range(0, 10);

        GameObject rain;

        if (tempNum < 6)
        {
            rain = Instantiate(Raindrops[0], tempPos, transform.rotation);
        }
        else
        {
            rain = Instantiate(Raindrops[1], tempPos, transform.rotation);
        }

        rain.GetComponent<Rain>()._target = target;
    }
}
