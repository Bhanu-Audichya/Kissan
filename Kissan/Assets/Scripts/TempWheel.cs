using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempWheel : MonoBehaviour
{
   // Rigidbody rigidbody;
    public float speed;
    //Transform child;
    public GameObject child;
    //Transform childTransform;
   // public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = GetComponent<Rigidbody>();
       // childTransform = child.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float zMovement = Input.GetAxis("Vertical");
        float xmovement = Input.GetAxis("Horizontal");
        child.transform.Rotate(Vector3.right * speed * Time.deltaTime * zMovement, Space.Self);
        transform.Rotate(Vector3.up* speed * Time.deltaTime * xmovement);
        Debug.Log(transform.rotation.eulerAngles);
        //rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        //rigidbody.constraints = RigidbodyConstraints.FreezeRotationZ;
    }
}
