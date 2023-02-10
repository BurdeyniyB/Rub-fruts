using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDestroy : MonoBehaviour
{
    public float destroyAfter = 2;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyAfter);
    }

}
