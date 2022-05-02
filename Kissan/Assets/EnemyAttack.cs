using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject target;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 lookAt = new Vector3(transform.position.x,0,transform.position.z);
        //transform.LookAt(lookAt);
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance>2.5f)
        {
            //Debug.Log(Vector3.Distance(transform.position, target.transform.position));
            transform.Translate(Vector3.forward * Time.deltaTime  * 5);
        }
        if(distance<=2.5f)
        {
            animator.SetBool("Bite", true);
        }


    }
}
