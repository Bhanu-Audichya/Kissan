using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Vehicle;
    float speed;
    public float rotationSpeed;
    public float force;
    bool idle = true;
    public GameObject lookObject;
    [SerializeField]
    bool jump = true;
    float leftRightSpeed = 5;
    Vector3 direction;
    Quaternion lookAt;
    Animator animator;
    Rigidbody rigidbody;
    Drive drive;
    public GameObject cam1;
    public GameObject cam2;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        drive = GameObject.Find("Truck").GetComponent<Drive>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (idle)
        {
            Move();  // Method of player for Movement
        }
        // For Front and Back
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && idle)
        {
            speed = 12f;
            animator.SetBool("Static_b", false);
            animator.SetFloat("Speed_f", 0.6f);
            animator.SetBool("running", true);
            LookAtCamera();
        }
        else if (Input.GetKey(KeyCode.W) && idle ) // Always Look in Alignment with Camera
        {
            animator.SetBool("running", false);
            animator.SetBool("Static_b", true);
            animator.SetFloat("Speed_f", 0.3f);
            speed = 3f;
            //leftRightSpeed = 0;
            LookAtCamera();
        }
        else if (Input.GetKey(KeyCode.S) && idle)
        {
            animator.SetBool("WalkBack", true);
            speed = 3;
        }
        else if (!Input.GetKey(KeyCode.S))
        {
            animator.SetBool("WalkBack", false);
        }
        if (!Input.GetKey(KeyCode.W))
        {
            animator.SetFloat("Speed_f", 0.1f);
        }
        // For Left and Right
        if (Input.GetKey(KeyCode.A)&& idle )
        {
            animator.SetBool("LeftWalk", true);
            leftRightSpeed = 5;
        }
        else if(Input.GetKey(KeyCode.D) && idle)
        {
            animator.SetBool("RightWalk", true);
            leftRightSpeed = 5;
        }
        else if (!Input.GetKey(KeyCode.D) )
        {
            animator.SetBool("RightWalk", false);
        }
        if(!Input.GetKey(KeyCode.A))
        {
            animator.SetBool("LeftWalk", false);
        }

        
        if(Input.GetKeyDown(KeyCode.Space) && jump)
        {
            Jump();
        }
        if(Input.GetMouseButtonDown(0) && idle)
        {
            animator.SetBool("attack", true);
            idle = false;
            StartCoroutine(Idle(2f));

        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            speed = 0;
            leftRightSpeed = 0;
            animator.SetFloat("Speed_f", 0.1f);
            animator.SetBool("LeftWalk", false);

        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            speed = 0;
            leftRightSpeed = 0;
            animator.SetFloat("Speed_f", 0.1f);
            animator.SetBool("RightWalk", false);

        }

        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(this.transform.position,Vehicle.transform.position)<5)
        {
            Debug.Log("pata nhi");
            gameObject.SetActive(false);
            drive.enabled = true;
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
    }
    IEnumerator Idle(float time)
    {
        
        yield return new WaitForSeconds(time);
        animator.SetBool("attack", false);
        idle = true;
    }
    public void Move()
    {
        float vecticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        //Debug.Log(speed);
        transform.Translate(Vector3.right * leftRightSpeed * Time.deltaTime * horizontalInput);
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vecticalInput);
    }

    public void LookAtCamera()
    {
        direction = lookObject.transform.position - this.transform.position;
        lookAt = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(this.transform.rotation, lookAt, 15f * Time.deltaTime);
    }
    public void Jump()
    {
        animator.SetBool("Jump_b", true);
        rigidbody.AddForce(Vector3.up * force,ForceMode.Impulse);
        jump = false;
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //Debug.Log("Olla");
            animator.SetBool("Jump_b", false);
            jump = true;

        }
    }
}
