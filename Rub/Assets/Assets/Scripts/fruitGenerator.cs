using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitGenerator : MonoBehaviour
{
    public GameObject[] fruits;
    public GameObject EndTrigger;
    [SerializeField]
    private GameObject currentFruit;

    public GameObject follower;

    private void Start()
    {
        generate();
    }

    public void generate()
    {
        if(GameManager.gameManager.canGenerateFruit)
        {
            int rand = Random.Range(0, fruits.Length);
            GameObject fruitIns = Instantiate(fruits[rand],transform.position,fruits[rand].transform.rotation);
            currentFruit = fruitIns;
            GameManager.gameManager.updateFruits();
        }
        else
        {
            Instantiate(EndTrigger, transform.position, EndTrigger.transform.rotation);
            follower.SetActive(false);
        }

    }

    private void Update()
    {
        if(currentFruit != null)
            follower.transform.position = currentFruit.transform.position;
    }


}
