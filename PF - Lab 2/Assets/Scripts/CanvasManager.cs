using System.Collections;
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
    bool isCoolDown;
    Queue units;

    bool queueIsDone;


    // Start is called before the first frame update
    void Start()
    {
       units = new Queue();

        clickButton();
       
    }

    private void Update()
    {
        // as long as times are in the queue , get the first item and then invoke it 5s - after 5s dequeue / repeat.
        if (isCoolDown)
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
        if (spawnLocation && Unit1Prefab)
        {
            Rigidbody temp = Instantiate(Unit1Prefab, spawnLocation.position, spawnLocation.rotation);

            temp.AddForce(spawnLocation.forward * unitSpeed, ForceMode.Impulse);

            imageCoolDown.fillAmount = 0;
            isCoolDown = false;
           
            units.Dequeue();
            Debug.Log("Unit 1 Left Queue");
        }

    }

    void Loading1()
    {
        Invoke("spawnUnit1", 1);
        units.Enqueue(Unit1Prefab);
        Debug.Log("Unit 1 In Queue");
       
        isCoolDown = true;

        if (isCoolDown)
        {
            imageCoolDown.fillAmount += 1 / cooldown * Time.deltaTime;
        }
    }


    void spawnUnit2()
    {
        if (spawnLocation && Unit2Prefab)
        {
            Rigidbody temp = Instantiate(Unit2Prefab, spawnLocation.position, spawnLocation.rotation);

            temp.AddForce(spawnLocation.forward * unitSpeed, ForceMode.Impulse);

            imageCoolDown.fillAmount = 0;
            isCoolDown = false;
           
            units.Dequeue();
            Debug.Log("Unit 2 Left Queue");
        }
    }
    void Loading2()
    {
        Invoke("spawnUnit2", 3);
        units.Enqueue(Unit2Prefab);
        Debug.Log("Unit 2 In Queue");
        
        isCoolDown = true;

        if (isCoolDown)
        {
            imageCoolDown.fillAmount += 1 / cooldown * Time.deltaTime;
        }
    }

    void spawnUnit3()
    {
        if (spawnLocation && Unit3Prefab)
        {
            Rigidbody temp = Instantiate(Unit3Prefab, spawnLocation.position, spawnLocation.rotation);

            temp.AddForce(spawnLocation.forward * unitSpeed, ForceMode.Impulse);

            imageCoolDown.fillAmount = 0;
            isCoolDown = false;
          
            units.Dequeue();
            Debug.Log("Unit 3 Left Queue");
        }
    }

    void Loading3()
    { 
        Invoke("spawnUnit3", 5);
        units.Enqueue(Unit3Prefab);
        Debug.Log("Unit 3 In Queue");
       
        isCoolDown = true;

        if (isCoolDown)
        {
            imageCoolDown.fillAmount += 1 / cooldown * Time.deltaTime;
        }
    }
    
}


