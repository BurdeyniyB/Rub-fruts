using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubRotation : MonoBehaviour
{
    public static RubRotation instance;
    [SerializeField] private GameObject Knife;

    public float start_rotation;
    public float speed;
    public bool TrueRotation;
    public float maxRotation;

    private float rotation;

	void Awake () {
        if (instance == null)
            instance = this;
        rotation = start_rotation;
        Knife.transform.eulerAngles = new Vector3(0f, 90f, -rotation);
	}

    void Update()
    {
        if(TrueRotation)
        {
          rotation += Time.deltaTime * speed;
          Knife.transform.eulerAngles = new Vector3(0f, 90f, -rotation);
          if(rotation >= maxRotation)
          {
            TrueRotation = false;
            rotation = start_rotation;   
            Knife.transform.eulerAngles = new Vector3(0f, 90f, -rotation);
          }
        }
    }

    public void IsTrueRotation()
    {
       rotation = start_rotation;
       Knife.transform.eulerAngles = new Vector3(0f, 90f, -rotation);
       TrueRotation = true;
    }
}
