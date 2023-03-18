using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCrosshair : MonoBehaviour
{
    public static ChangeCrosshair instance;
    public Texture2D MyCrosshair;
    public GameObject MyEnemies;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void ActivateMyCrosshair()
    {
        Cursor.SetCursor(MyCrosshair, new Vector2(MyCrosshair.width / 2, MyCrosshair.height / 2), CursorMode.Auto);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ShootTime")
        {
            Debug.Log("Yes");
            ActivateMyCrosshair();
            MyEnemies.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
