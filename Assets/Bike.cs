using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour
{
    public float bikePush;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "ground")
        {
            this.GetComponent<Rigidbody>().AddForce(transform.right * bikePush, ForceMode.Force);
        }
    }
}
