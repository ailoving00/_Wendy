using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cellar_Wendy : MonoBehaviour
{

    public GameObject timeover;
    public GameObject EWall;
    public GameObject SWall;

    Cellar_Manager cellar_;

    // Start is called before the first frame update
    void Start()
    {
        timeover.SetActive(false);
        cellar_ = FindObjectOfType<Cellar_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Wall")
        {
            timeover.SetActive(true);

            cellar_.enabled = false;

        }
    }

}
