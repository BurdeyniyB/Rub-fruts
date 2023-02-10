using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGeneration : MonoBehaviour
{
    public static FruitGeneration instance;

    [SerializeField] private GameObject[] SpawnObjPrefabs;
    [SerializeField] private Transform transformFruit;
    [SerializeField] private GameObject FruitOdj;
    [SerializeField] private GameObject SpawnObj;
    private int random;
    bool Generation = true;

	void Awake () {
        if (instance == null)
            instance = this;
	}

    void Start()
    {
        InstantiateFruit();
    }

    void Update()
    {
       if(SpawnObj != null && SpawnObj.tag == "apple" && SpawnObj.transform.position.x <= 0.2f)
       {
          NewRub();
       }

       if(SpawnObj != null && SpawnObj.tag == "banana" && SpawnObj.transform.position.x <= -1.3f)
       {
          NewRub();
       }

       if(SpawnObj != null && SpawnObj.tag == "melon" && SpawnObj.transform.position.x <= -1.9f)
       {
          NewRub();
       }
    }

    void NewRub()
    {
          gameManager.instance.NewCountRubFruit();
          swipe.instance.StartPosition();
          FruitOdj.transform.position = new Vector3(2f, 8f, 44.5f);
          Destroy(SpawnObj);
          InstantiateFruit();
          Debug.Log("swipe.instance.StartPosition();");
    }
    
    public void InstantiateFruit()
    {
       if(Generation)
       {
         random = Random.Range(0, SpawnObjPrefabs.Length);
         SpawnObj = Instantiate(SpawnObjPrefabs[random], transformFruit);
         Remainder.instance.GetNum(random);
       }
    }

    public void AddFruit(GameObject _positive)
    {
       SpawnObj = _positive;
    }

    public void GanerationFalse()
    {
      Generation = false;
    }
}
