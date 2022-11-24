using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 movement;
    [SerializeField] private float speed = 10f;
    private Rigidbody rb;

    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(!FindObjectOfType<TimeManager>().gameOver && !FindObjectOfType<TimeManager>().gameFinished )
        {
            Move();
        }
        if(FindObjectOfType<TimeManager>().gameFinished || FindObjectOfType<TimeManager>().gameFinished)
        {
            rb.isKinematic = true;
        }
    }
    private void Move()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        movement = new Vector3(x, 0f, z);
        //transform.position += movement;
        rb.AddForce(movement);
    }
}
