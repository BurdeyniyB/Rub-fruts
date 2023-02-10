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
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
          if((PosY + Input.GetTouch(0).deltaPosition.y /100) < PosUp.transform.position.y && (PosY + Input.GetTouch(0).deltaPosition.y /100) > PosDown.transform.position.y)
          {
            if(PosY > PosY + Input.GetTouch(0).deltaPosition.y /100 && down == false)
            {
              down = true;
              up = false;
              Remainder.instance.StartCorout();
              CameraShaker.Invoke();
            }
            else if(PosY < PosY + Input.GetTouch(0).deltaPosition.y /100 && up == false)
            {
              up = true;
              down = false;
              Remainder.instance.StartCorout();
            }
            PosY = PosY + Input.GetTouch(0).deltaPosition.y /100;
          }


          Player.transform.position = new Vector3(PosX, PosY, PosZ);
          PosX -= 0.03f;
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
