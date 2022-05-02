using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoorAnimal : MonoBehaviour
{
    public float health;
    public GameObject meat;
    GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("OLLla");
        if(collision.gameObject.tag == "Enemy" && health >=1)
        {
            health--;
        }
        if(health<=0)
        {
            prefab = Instantiate(meat,new Vector3(transform.position.x,0,transform.position.z),Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
