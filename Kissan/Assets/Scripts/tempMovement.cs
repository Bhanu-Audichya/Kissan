using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float rotationSpeed;
    CharacterController characterController;
    Rigidbody rigidbody;
    [SerializeField]
    // float force;
    //GameObject player;
    //public GameObject Truck;
    //Drive drive;
    //public GameObject look;
    // Start is called before the first frame update
    bool move = true;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();
       // player = this.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        float zMovement = Input.GetAxis("Vertical");
        float xMovement = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(xMovement, 0, zMovement);
        rigidbody.velocity = move * speed;
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = Vector3.zero;
        }
        else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = Vector3.zero;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Physics.gravity = Vector3.down * 100;
           rigidbody.AddForce(Vector3.up * 500,ForceMode.Impulse);
        }

        //rigidbody.velocity = Vector3.right * xMovement * speed;
        //rigidbody.AddForce(Vector3.forward * zMovement * speed );
        
        



    }
   
}
