using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public GameObject CrossHair = null;
    public Transform CH = null;
    float polateSpeed = 5;

    private void Update()
    {
        Vector3 vec = Vector3.Lerp(CrossHair.transform.position, Input.mousePosition, polateSpeed);
        CH.transform.position = vec;
    }
}
