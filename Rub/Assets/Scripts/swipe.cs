using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class swipe : MonoBehaviour
{
   public static swipe instance;

   [SerializeField] private GameObject Player;
   [SerializeField] private GameObject knife;
   [SerializeField] private Transform PosUp;
   [SerializeField] private Transform PosDown;

   private float PosX = 2f;
   private float PosY = 8;
   private float PosZ = 44.8f;

   bool up;
   bool down;
   public float Lerp;
   public float speed;

   bool gamePlay = true;

	void Awake () {
        if (instance == null)
            instance = this;
	}

    void Update() {
       if(gamePlay)
       {
        Lerp += Time.deltaTime * speed;
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
          if((PosY + Input.GetTouch(0).deltaPosition.y /100) < PosUp.transform.position.y && (PosY + Input.GetTouch(0).deltaPosition.y /100) > PosDown.transform.position.y)
          {
            if(PosY > PosY + Input.GetTouch(0).deltaPosition.y /100 && down == false)
            {
              down = true;
              up = false;
              Lerp = 0;
              RubRotation.instance.IsTrueRotation();
              Remainder.instance.StartCorout();
              CameraShaker.Invoke();
              PosX -= 0.5f;
            }
            else if(PosY < PosY + Input.GetTouch(0).deltaPosition.y /100 && up == false)
            {
              up = true;
              down = false;
              Lerp = 0;
              RubRotation.instance.IsTrueRotation();
              Remainder.instance.StartCorout();
              PosX -= 0.5f;
            }
            PosY = PosY + Input.GetTouch(0).deltaPosition.y /100;
          }

          Player.transform.position = Vector3.Lerp( Player.transform.position, new Vector3(PosX, PosY, PosZ), Lerp);
        }
       }
    }

    public void StartPosition()
    {
      PosZ = 44.5f;
      PosY = 8f;
      PosX = 2f;
    }

    public void gameOver()
    {
      gamePlay = false;
    }
}
