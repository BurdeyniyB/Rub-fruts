using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeControl : MonoBehaviour
{
    public Animator animator;

    public float exhaustion = 0;
    public float exhaustionRate;
    public float coolDownRate;
    bool isCutting = false;
    bool isExhausted = false;

    public Slider exhaustionMeter;
    public GameObject exhaustedTxt;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isExhausted)
        {
            Debug.Log("hit");
            animator.SetBool("cut", true);
            isCutting = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && !isExhausted)
        {
            animator.SetBool("cut", false);
            isCutting = false;
        }

        if(isCutting)
        {
            if(exhaustion < exhaustionMeter.maxValue && !isExhausted)
            {
                exhaustion += Time.deltaTime * exhaustionRate;
                if(exhaustion >= exhaustionMeter.maxValue)
                {
                    Debug.Log("Man! Relax");
                    StartCoroutine(showTxt());
                    isExhausted = true;
                    animator.SetBool("cut", false);
                    isCutting = false;
                }
            }
        }
        else
        {
            if(!isExhausted && exhaustion > 0)
            {
                exhaustion -= Time.deltaTime * coolDownRate;
            }
        }

        if(isExhausted)
        {
            if(exhaustion > 0)
            {
                exhaustion -= Time.deltaTime * coolDownRate;
                if(exhaustion <= 0)
                {
                    Debug.Log("Get Working!");
                    isExhausted = false;
                }
            }
        }

        exhaustionMeter.value = exhaustion;
    }


    IEnumerator showTxt()
    {
        exhaustedTxt.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        exhaustedTxt.SetActive(false);

    }

}
