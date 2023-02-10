using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAndKnife : MonoBehaviour
{
    public static CameraAndKnife instance;
    [SerializeField] private Vector3 NewVector;

    public bool move;
    public float Lerp;
    public float speed;


	void Awake () {
        if (instance == null)
            instance = this;
        NewVector = transform.position;
	}

    void Update()
    {
        if(move)
        {
          Lerp = Lerp + Time.deltaTime * speed;
          transform.position = Vector3.Lerp(transform.position, NewVector, Lerp);
        }
    }

    public void IsMove()
    {
      move = true;
      Lerp = 0;
      NewVector += new Vector3(0.15f, 0, 0);
    }

    public void StartVector()
    {
      NewVector = new Vector3(0, 9.9f, 66.8f);
    }
}
