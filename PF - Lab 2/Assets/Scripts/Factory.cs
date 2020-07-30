using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public Rigidbody Unit1Prefab;
    public Rigidbody Unit2Prefab;
    public Rigidbody Unit3Prefab;

    public Transform spawnLocation;

    public float unitSpeed;

    CanvasManager cm;
    // Start is called before the first frame update
    void Start()
    {
        cm = FindObjectOfType<CanvasManager>();

        if (unitSpeed <= 0)
        {
            unitSpeed = 5.0f;
        }

    }

    // Update is called once per frame
    void Update()
    {


      
    }

    public void spawn1()
    {
       
        if (spawnLocation && Unit1Prefab)
        {
            Rigidbody temp = Instantiate(Unit1Prefab, spawnLocation.position, spawnLocation.rotation);

            temp.AddForce(spawnLocation.forward * unitSpeed, ForceMode.Impulse);
        }
    }
}
