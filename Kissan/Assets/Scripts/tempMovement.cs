using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMotion = Input.GetAxis("Horizontal");
        float zMotion = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.forward * zMotion * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, xMotion * rotationSpeed * Time.deltaTime, 0));
    }
}
