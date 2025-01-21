using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public GameObject gamaEnd;
    public float setTime = 30f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(setTime > 0)
        {
            scoreText.text = $"{score}";
            timeText.text = setTime.ToString("N2");
            setTime -= Time.deltaTime;
            
        }
        else
        {
            Time.timeScale = 0f;
            gamaEnd.SetActive(true);
        }

    }

    public void AddScore(int _score)
    {
        score += _score;
    }
}
