using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour
{
    [SerializeField]
    private Material tractorBeam;

    [SerializeField]
    private Animator ufoAnim;
    [SerializeField]
    private Animator pyramidAnim;

    private Color fixedColor;
    private bool appearBeam = false;
    private bool afterBeam = false;

    // Start is called before the first frame update
    void Start()
    {
        fixedColor = tractorBeam.color;
        fixedColor.a = 0f;
        tractorBeam.color = fixedColor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (appearBeam)
        {
            fixedColor.a += (Time.deltaTime / 2f);
            tractorBeam.color = fixedColor;
            if (tractorBeam.color.a >= 0.5f)
            {
                appearBeam = false;
                afterBeam = true;
            }
        }
        if (afterBeam)
        {
            pyramidAnim.SetTrigger("PyramidToUFO");
            afterBeam = false;
        }
        if (pyramidAnim.GetCurrentAnimatorStateInfo(0).IsName("PyramidAtUFO"))
        {
            fixedColor.a = 0f;
            tractorBeam.color = fixedColor;
            ufoAnim.SetTrigger("UFODip");
            pyramidAnim.SetTrigger("PyramidDip");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        appearBeam = true;
    }
}
