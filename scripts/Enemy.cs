using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float stopDistance = 3f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; // objeyi buldu ve transformunu getirdi
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
            float mesafe = Vector3.Distance(transform.position, target.position); // iki nokta arasý mesafeyi alýyor
            if (mesafe > stopDistance)
            {
                transform.position += transform.forward * Time.deltaTime * speed;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FindObjectOfType<TimeManager>().gameOver = true;
            Destroy(collision.gameObject);
        }
    }
}
