using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] waypoints;
    int currentWp = 0;
    float speed = 4;
    GameObject[] targets;
    GameObject target;
    public bool targetDie = false;
    int currntarget = 1;
    [SerializeField]
    bool walk = true;

    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Animal");
        StartCoroutine(GetAnimal(.2f));
    }

    IEnumerator GetAnimal(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        targets = GameObject.FindGameObjectsWithTag("Animal");
        float wpDistance = Vector3.Distance(waypoints[currentWp].transform.position, this.transform.position);
        if (wpDistance <=2)
        {
            currentWp++;
        }
        if(currentWp >= waypoints.Length)
        {
            currentWp = 0;
        }
        //Debug.Log(targets.Length);
        
        

       
        //Debug.Log(targets.Length);
        if(targets==null)
        {
            Debug.Log("Olla");
        }
        if (targets.Length>0)
        {
            
            target = targets[0];
            //Debug.Log(target);
            if( Vector3.Distance(target.transform.position, this.transform.position) < 15)
            {
                Vector3 targetPosition = new Vector3(target.transform.position.x,0.5f,target.transform.position.z);
                transform.LookAt(targetPosition);
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                walk = false;
            }
            else
            {
                walk = true;
            }
        
        }
        else
        {
            walk = true;
        }
        if (walk)
        {
            Vector3 Wp = new Vector3(waypoints[currentWp].transform.position.x, 0.4f, waypoints[currentWp].transform.position.z);
            transform.LookAt(Wp);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        
        }






    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Animal")
        {
            currntarget++;
            Destroy(collision.gameObject);
        }
    }
}
