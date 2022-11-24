using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    [SerializeField] private Text scoreManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreManager.text = "Score: " + score.ToString();
    }
}
