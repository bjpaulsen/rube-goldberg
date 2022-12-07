using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform follow;
    [SerializeField] private float defualtDamping = 200;
    private float damping = 200;


    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((follow.position.x-transform.position.x)/damping+transform.position.x, (follow.position.y-transform.position.y)/damping+transform.position.y, transform.position.z);
    }

    public void SwitchTo(Transform newFollow, float newFOV)
    {
        damping = defualtDamping;
        follow = newFollow;
        StartCoroutine(SwitchFOV(newFOV));
    }

    private IEnumerator SwitchFOV(float to)
    {
        while (cam.fieldOfView < to-.5 || cam.fieldOfView > to+.5)
        {
            cam.fieldOfView = (to-cam.fieldOfView)/damping+cam.fieldOfView;
            yield return null;
        }

        cam.fieldOfView = to;
        StartCoroutine(RemoveDampen());
    }

    private IEnumerator RemoveDampen()
    {
        float t = 0;
        while (damping > 1)
        {
            damping = Mathf.Lerp(defualtDamping, 1, t);
            t += 1f * Time.deltaTime;
            yield return null;
        }
    }
}
