using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    float force;
    [SerializeField]
    private GameObject[] wheels;
    [SerializeField]
    private float wheelspeed;
    Drive drive;
    [SerializeField]
    public GameObject player;
    [SerializeField]
    public GameObject cam1;
    [SerializeField]
    public GameObject cam2;
    [SerializeField]
    bool script = false;
    
    // Start is called before the first frame update
    void Start()
    {
        script = false;
        drive = GetComponent<Drive>();
        //player = GameObject.Find("Player").gameObject;
        StartCoroutine(Delay(2));   

    }
    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        script = true;
    }
    // Update is called once per frame
    void Update()
    {
        float xMotion = Input.GetAxis("Horizontal");
        float zMotion = Input.GetAxis("Vertical");
       
        if (script)
        {
            transform.Translate(Vector3.forward * zMotion * speed * Time.deltaTime);
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                transform.Rotate(new Vector3(0, xMotion * rotationSpeed * Time.deltaTime, 0));
            }
            
            foreach (GameObject wheel in wheels)
            {
                wheel.transform.Rotate(new Vector3(zMotion * wheelspeed * Time.deltaTime, 0, 0));
            }

            
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {

            
            if (drive.enabled)
            {
                Debug.Log("Problem");
                drive.enabled = false;
                player.SetActive(true);
                cam1.SetActive(true);
                cam2.SetActive(false);
                player.transform.position = this.transform.position + new Vector3(-3, 0, -1);
            }

        }
       




    }
}
