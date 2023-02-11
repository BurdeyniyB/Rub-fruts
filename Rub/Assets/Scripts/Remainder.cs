using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remainder : MonoBehaviour
{
    public static Remainder instance;
    [SerializeField] private GameObject SpawnObjPrefab;
    [SerializeField] private Transform transformRemainder;

    [SerializeField] private Material[] mainMaterial;
    private GameObject ob;
    int num;
    int randomRub;

	void Awake () {
        if (instance == null)
            instance = this;
	}

    IEnumerator CreateRemainder()
    {
      randomRub = Random.Range(1,5);
      for(int i = 0; i < randomRub; i++)
      {
        ob = Instantiate(SpawnObjPrefab, transformRemainder);
        ob.transform.position += new Vector3(Random.Range(-0.6f, 0.6f), Random.Range(-0.6f, 0.6f), Random.Range(-0.6f, 0.6f));
        ob.transform.localScale = new Vector3(Random.Range(0.03f, 0.05f), Random.Range(0.6f, 0.8f), Random.Range(0.1f, 0.15f));
        ob.GetComponent<Renderer>().material = mainMaterial[num];

        yield return new WaitForSeconds(0.05f);
       }
    }

    public void GetNum(int random)
    {
       num = random;
    }

    public void StartCorout()
    {
       StartCoroutine(CreateRemainder());
    }
}
//StartCoroutine(CreateRemainder());