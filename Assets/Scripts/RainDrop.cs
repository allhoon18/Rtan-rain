using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDrop : MonoBehaviour
{
    public GameObject Raindrop;
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
        GameObject rain = Instantiate(Raindrop, tempPos, transform.rotation);
        rain.GetComponent<Rain>()._target = target;
    }
}
