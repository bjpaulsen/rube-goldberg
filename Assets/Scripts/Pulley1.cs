using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnCollisionEnter(Collision other)
    // {
    //     print(this.tag);
    //     if (this.tag == "PulleyTrigger")
    //     {
    //         anim.SetTrigger("startElevator");
    //     }
    // }

    void onTriggerEnter(Collider other)
    {
        print("hi");
    }
}
