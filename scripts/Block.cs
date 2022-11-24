using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool isColided = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (isColided == false)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                ScoreManager score = FindObjectOfType<ScoreManager>();
                score.score--;
                isColided = true;
            }
        }
            
    }
}
