using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontalMovement;
    private float verticalMovement;
    public float speed = 1000.0f;
    private bool canJump;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);
        rb.AddForce(movement * speed);

        if(Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            rb.AddForce(Vector3.up * 350, ForceMode.Impulse);
            canJump = false;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("ground"))
        {
            canJump = true;
            Debug.Log("Puedo saltar?: " + canJump);
        }
    }
}
