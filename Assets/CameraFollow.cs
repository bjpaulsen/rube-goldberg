using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform[] followTargets;
    [SerializeField] private float damping = 200;
    [SerializeField] private float defaultFOV = 30;

    private Transform follow;
    private int counter = 0;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        follow = followTargets[0];
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((follow.position.x-transform.position.x)/damping+transform.position.x, (follow.position.y-transform.position.y)/damping+transform.position.y, transform.position.z);
    }

    public void SwitchTo(Transform newFollow, float newFOV = -1)
    {
        // I KNOW I KNOW
        if (newFOV == -1) newFOV = defaultFOV;

        follow = newFollow;
        StartCoroutine(SwitchFOV(newFOV));
    }

    private IEnumerator SwitchFOV(float to)
    {
        while (cam.fieldOfView < to-0.1 || cam.fieldOfView > to+0.1)
        {
            cam.fieldOfView = (to-cam.fieldOfView)/damping+cam.fieldOfView;
            yield return null;
        }
        cam.fieldOfView = to;
    }
}
