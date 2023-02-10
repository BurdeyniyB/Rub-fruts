using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubRotation : MonoBehaviour
{
    public static RubRotation instance;
    [SerializeField] private GameObject Knife;

    public float rotation;
    public float speed;
    public bool TrueRotation;

	void Awake () {
        if (instance == null)
            instance = this;
	}

    void Update()
    {
        if(TrueRotation)
        {
          rotation += Time.deltaTime * speed;
          //Knife.transform.Rotate(0, 100f, -rotation, Space.Self);
          Knife.transform.eulerAngles = new Vector3(0, 90f, -rotation);
          if(rotation >= 360f)
          {
//            TrueRotation = false;
            rotation = 280f;
            Knife.transform.eulerAngles = new Vector3(0, 90f, -rotation);
          }
        }
    }

    public void IsTrueRotation()
    {
       TrueRotation = true;
    }
}
