using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmark : MonoBehaviour
{
    public GameObject pose1;
    public GameObject pose2;
    public Animator animator;

    public GameObject nextButton;
    public GameObject lastButton;
    public GameObject hintButton;

    public GameObject[] Steps;

    private int count = 0;

    private bool disabling;

    private void Start()
    {
        disabling = true;
        nextButton.SetActive(false);
        lastButton.SetActive(false);
        hintButton.SetActive(false);


        Disable();
        
    }


    private void Update()
    {
        if (!disabling)
        {
            if (count == Steps.Length - 1)
            {
                nextButton.SetActive(false);
            }
            else if (count == 0)
            {
                lastButton.SetActive(false);
            }
            else
            {
                nextButton.SetActive(true);
                lastButton.SetActive(true);
            }

            Disable();
            Steps[count].SetActive(true);
        }
    }


    public void Disable()
    {
        foreach (var step in Steps)
        {
            step.SetActive(false);
        }
    }

    public void NextStep()
    {
        count++;
        if (count > Steps.Length - 1)
        {
            count = Steps.Length - 1;
        }
    }

    public void LastStep()
    {
        count--;
        if (count < 0)
        {
            count = 0;
        }
    }

    public void PlayFirstTimeAnimation()
    {
        pose1.SetActive(true);
        pose2.SetActive(false);

        animator.Play("animation1");



        disabling = true;
        nextButton.SetActive(false);
        lastButton.SetActive(false);
        hintButton.SetActive(false);


        Disable();




        StartCoroutine(ReplaceModel());
    }

    IEnumerator ReplaceModel()
    {
        disabling = true;

        yield return new WaitForSeconds(1.5f);

        pose2.SetActive(true);
        pose1.SetActive(false);

        disabling = false;
        nextButton.SetActive(true);
        lastButton.SetActive(true);
        hintButton.SetActive(true);
    }

}
