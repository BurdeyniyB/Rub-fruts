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

	void Awake () {
        if (instance == null)
            instance = this;
	}

    IEnumerator CreateRemainder()
    {
        ob = Instantiate(SpawnObjPrefab, transformRemainder);
        ob.transform.localScale = new Vector3(Random.Range(0.1f, 0.25f), Random.Range(0.3f, 0.5f), Random.Range(0.1f, 0.25f));
        ob.GetComponent<Renderer>().material = mainMaterial[num];

        yield return new WaitForSeconds(0.2f);
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