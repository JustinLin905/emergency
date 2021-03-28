using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject[] EmergenciesPage;
    public GameObject[] CardiacArrestPages;
    public GameObject[] ChokingPages;
    public GameObject[] Extras;

    public GameObject modelPose1;
    public GameObject modelPose2;

    // Public object for blue background to fade in
    public Image blueBackground;

    private void Start()
    {
        blueBackground.gameObject.SetActive(false);
        blueBackground.CrossFadeAlpha(0, 0, false);
    }

    /* 
     * All of the below functions are used to open different pages in the app
     * 
     * for example below, the disable function disables any open pages
     * then the next line opens the desired page
     * public void Example()
     * {
     *     Disable();
     *     Example[0].SetActive(true);
     * }
     * 
     */

    public void OpenMainMenu()
    {
        Disable();
        EmergenciesPage[0].SetActive(true);
    }

    public void OpenChoking()
    {
        Disable();
        ChokingPages[0].SetActive(true);
    }

    public void Choking2()
    {
        Disable();
        ChokingPages[1].SetActive(true);
    }

    public void Choking3()
    {
        Disable();
        ChokingPages[2].SetActive(true);
    }

    public void Choking4()
    {
        Disable();
        ChokingPages[3].SetActive(true);
    }

    public void Choking5()
    {
        Disable();
        StartCoroutine(FadeToChoking5());
    }

    public void OpenNonResponsive()
    {
        Disable();
        ChokingPages[5].SetActive(true);
    }

    public void OpenBackBlow()
    {
        Disable();
        ChokingPages[6].SetActive(true);
    }

    public void OpenChestThursts()
    {
        Disable();
        ChokingPages[7].SetActive(true);
    }

    public void OpenCardiacArrest()
    {
        Disable();
        CardiacArrestPages[0].SetActive(true);
    }

    public void CardiacArrestPage2()
    {
        Disable();
        CardiacArrestPages[1].SetActive(true);
    }

    public void CardiacArrestPage3()
    {
        Disable();
        CardiacArrestPages[2].SetActive(true);
    }

    public void CardiacArrestPage4()
    {
        Disable();
        CardiacArrestPages[3].SetActive(true);
    }

    public void CardiacArrestPage5()
    {
        Disable();
        StartCoroutine(FadeToCardiacArrest4());
    }

    public void CardiacArrestPage6()
    {
        Disable();
        CardiacArrestPages[5].SetActive(true);
    }

    public void CallEmergencyServices()
    {
        // Dial Pizza Nova's number instead of 911. This is to prevent accidental charges in the demo
        Application.OpenURL("tel://4164390000");
    }

    public void OpenLandmarkPage()
    {
        Disable();
        CardiacArrestPages[6].SetActive(true);
        modelPose1.SetActive(true); ;
    }

    public void OpenMetronomePage()
    {
        Disable();
        CardiacArrestPages[7].SetActive(true);
    }    

    
    public void OpenGeneralCPRInstructions()
    {
        Disable();
        CardiacArrestPages[8].SetActive(true);
    }

    public void OpenAboutPage()
    {
        Disable();
        Extras[0].SetActive(true);
    }


    public void Disable()
    {
        foreach(var page in EmergenciesPage)
        {
            page.SetActive(false);
        }
        foreach (var page in CardiacArrestPages)
        {
            page.SetActive(false);
        }
        foreach (var page in ChokingPages)
        {
            page.SetActive(false);
        }
        foreach (var page in Extras)
        {
            page.SetActive(false);
        }
        modelPose1.SetActive(false);
        modelPose2.SetActive(false);
    }

    public void Disclaimer1()
    {
        Disable();
        Extras[1].SetActive(true);
    }
    public void Disclaimer2()
    {
        Disable();
        Extras[2].SetActive(true);
    }

    public void OpenWebsite()
    {
        Application.OpenURL("https://www.ontario.ca/laws/statute/01g02");
    }

    // Coroutine for fade to blue animation to Page CA4
    IEnumerator FadeToCardiacArrest4()
    {
        // First, fade blue background in
        blueBackground.gameObject.SetActive(true);
        blueBackground.CrossFadeAlpha(1, 2, false);

        // Wait one second, then turn off blue background and enable next page
        yield return new WaitForSeconds(2.5f);

        blueBackground.gameObject.SetActive(false); 
        blueBackground.CrossFadeAlpha(0, 0, false);
        CardiacArrestPages[4].SetActive(true);
    }

    // Coroutine for fade to blue animation to Page Choking 5
    IEnumerator FadeToChoking5()
    {
        // First, fade blue background in
        blueBackground.gameObject.SetActive(true);
        blueBackground.CrossFadeAlpha(1, 2, false);

        // Wait one second, then turn off blue background and enable next page
        yield return new WaitForSeconds(2.5f);

        blueBackground.gameObject.SetActive(false);
        blueBackground.CrossFadeAlpha(0, 0, false);
        ChokingPages[4].SetActive(true);
    }

}
