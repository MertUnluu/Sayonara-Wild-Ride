using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShootMechanic : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public bool LoopMe;
    public float loopTime;
    public GameObject enemyDeath = null;

    public Color selectedEnemy = Color.red;

    Ray ray;
    RaycastHit hit;

    public void AddEnemies()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.tag == "Enemy")
                {
                    Enemies.Add(hit.collider.gameObject);
                    SoundManager.instance.PlaySoundEffect(4, hit.collider.transform.position, 1.0f, 0.1f);
                    hit.collider.gameObject.GetComponent<EnemySelected>().Select.SetActive(true);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        AddEnemies();
        //loopTime += Time.deltaTime * 1;
        
        if(LoopMe)
        {
            loopTime += Time.deltaTime * 1;
            if (loopTime > 0.35f)
            {
                for(int i = 0; i < 1; i++)
                {
                    loopTime = 0;
                    //Destroy(Enemies[i]);
                    Enemies[i].SetActive(false);
                    Instantiate(enemyDeath, Enemies[i].transform.position, Enemies[i].transform.rotation);
                    SoundManager.instance.PlaySoundEffect(5, Enemies[i].transform.position, 1.0f, 0.1f);
                    Enemies[i].GetComponent<EnemySelected>().Select.SetActive(false);
                    Enemies.RemoveAt(i);
                    if(Enemies.Count.Equals(0))
                    {
                        LoopMe = false;
                    }
                }
            }
        }
        
        if(Input.GetMouseButtonDown(1))
        {
            if(!Enemies.Count.Equals(0))
            {
                LoopMe = true;
            }
        }

    }
}
