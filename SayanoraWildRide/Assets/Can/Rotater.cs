using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public Transform tr;
    public float rotSpeed;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tr.transform.Rotate(90 * rotSpeed * Time.deltaTime, 0, 0 );
    }

    
}
