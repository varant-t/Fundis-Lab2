﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    Factory factory;

    public Button Unit1;
    public Button Unit2;
    public Button Unit3;

    public Rigidbody Unit1Prefab;
    public Rigidbody Unit2Prefab;
    public Rigidbody Unit3Prefab;


    public Transform spawnLocation;

    public float unitSpeed;

    public Image imageCoolDown;
    public float cooldown = 5;
    bool isCoolDown = true;
    bool spawning;
    Queue units;


    // Start is called before the first frame update
    void Start()
    {
        units = new Queue();

        clickButton();

       //StartCoroutine("SpawnDelay");


    }

    private void Update()
    {
        // as long as times are in the queue , get the first item and then invoke it 5s - after 5s dequeue / repeat.

        if (spawning == true)
        {
            imageCoolDown.fillAmount += 1 / cooldown * Time.deltaTime;
        }
    }

    void clickButton()
    {
        if (Unit1)
        {
            Unit1.onClick.AddListener(Loading1);
        }

        if (Unit2)
        {
            Unit2.onClick.AddListener(Loading2);
        }

        if (Unit3)
        {
            Unit3.onClick.AddListener(Loading3);

       
        }
    }

    void spawnUnit1()
    {
 
            if(spawnLocation && units.Peek().Equals(Unit1Prefab))
                {
                Rigidbody temp = Instantiate(Unit1Prefab, spawnLocation.position, spawnLocation.rotation);

                temp.AddForce(spawnLocation.forward * unitSpeed, ForceMode.Impulse);


                imageCoolDown.fillAmount = 0;
                units.Dequeue();
                isCoolDown = true;
                spawning = false;
                Debug.Log("Unit 1 Left Queue");
            }
    }

    void Loading1()
    {
        if (isCoolDown)
        {
                 units.Enqueue(Unit1Prefab);
                 Debug.Log("Unit 1 In Queue");
                 spawning = true;
                 isCoolDown = false;
                 Invoke("spawnUnit1", 1);
                 imageCoolDown.fillAmount += 1 / cooldown * Time.deltaTime;
        }
        
    }


    void spawnUnit2()
    {
            if (spawnLocation && units.Peek().Equals(Unit2Prefab))
            {
                Rigidbody temp = Instantiate(Unit2Prefab, spawnLocation.position, spawnLocation.rotation);

                temp.AddForce(spawnLocation.forward * unitSpeed, ForceMode.Impulse);

                imageCoolDown.fillAmount = 0;
                units.Dequeue();
                isCoolDown = true;
                spawning = false;
                Debug.Log("Unit 2 Left Queue");

            }
    }
    void Loading2()
    {
        if (isCoolDown)
        {
            units.Enqueue(Unit2Prefab);
            Debug.Log("Unit 2 In Queue");
            spawning = true;
            isCoolDown = false;
            Invoke("spawnUnit2", 3);
            imageCoolDown.fillAmount += 1 / cooldown * Time.deltaTime;

        }
      
    }

    void spawnUnit3()
    {
        if (spawnLocation && units.Peek().Equals(Unit3Prefab))
        {
            Rigidbody temp = Instantiate(Unit3Prefab, spawnLocation.position, spawnLocation.rotation);

            temp.AddForce(spawnLocation.forward * unitSpeed, ForceMode.Impulse);

            imageCoolDown.fillAmount = 0;
            units.Dequeue();
            isCoolDown = true;
            spawning = false;
            Debug.Log("Unit 3 Left Queue");
        }
    }

        

    void Loading3()
    {
     
        if (isCoolDown)
        {
            StartCoroutine("SpawnDelay");
            units.Enqueue(Unit3Prefab);
            Debug.Log("Unit 3 In Queue");
            spawning = true;
            isCoolDown = false;
            Invoke("spawnUnit3", 5);
            imageCoolDown.fillAmount += 1 / cooldown * Time.deltaTime;
        }
        
    }

    IEnumerator SpawnDelay()
    {
            if(units.Peek().Equals(Unit3Prefab))
            {
                Debug.Log("Here 5");
            yield return new WaitForSeconds(5);
            Debug.Log("Waitng 5 Seconds");
            } 
    }

}


