using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
   public static gameManager instance;

   [SerializeField] private Text TaskText;
   [SerializeField] private Text CountText;
   [SerializeField] private Color _color;
   [SerializeField] private GameObject confetti;
   [SerializeField] private GameObject RestartButton;

   private int NeedCountFruits;
   private int CountRubFruits;

	void Awake () {
        if (instance == null)
            instance = this;
	}

	void Start()
	{
	  NeedCountFruits = Random.Range(3, 6);
	  TaskText.text = "Sodium " + NeedCountFruits.ToString() + " fruits";
	}

	void Update()
	{
	  CountText.text = CountRubFruits.ToString() + " / " + NeedCountFruits.ToString();
	}

	public void NewCountRubFruit()
	{
	  CountRubFruits ++;
      if(NeedCountFruits == CountRubFruits)
      {
        TaskText.text = "Win";
        TaskText.color = _color;
        CountText.color = _color;
        FruitGeneration.instance.GanerationFalse();
        confetti.SetActive(true);
        RestartButton.SetActive(true);
        PlayerPrefs.SetInt("Breeze", 1);
        swipe.instance.gameOver();
      }
	}
}
