using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followerScript : MonoBehaviour
{
    public fruitGenerator generator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Generate"))
        {
            generator.generate();
            Debug.Log("checkpoint");
        }
    }
}
