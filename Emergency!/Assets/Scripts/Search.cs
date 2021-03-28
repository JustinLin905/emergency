using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Search : MonoBehaviour
{
    public Text searchResultText;
    public InputField searchBox;
    public GameObject SearchArea;
    public GameObject cardiacArrestButton;
    public GameObject chokingAdultButton;
    public RectTransform chokingAdultButtonForTransform;

    private string[] names = { "cardiac arrest", "choking (adult)" };

    public void ExitSearches()
    {
        SearchArea.SetActive(false);
    }

    public void SearchForEmergencies()
    {
        SearchArea.SetActive(true);

        cardiacArrestButton.SetActive(false);
        chokingAdultButton.SetActive(false);



        string search = searchBox.text.ToLower();

        searchResultText.text = $"Search Results for {search}";

        // names
        // Cardiac Arrest
        // Choking (Adult)

        for (int i = 0; i < names.Length; i++)
        {
            if (names[i].Contains(search) && search != "" && search != " ")
            {
                if (names[i] == "cardiac arrest")
                {
                    cardiacArrestButton.SetActive(true);
                }

                if (names[i] == "choking (adult)")
                {
                    chokingAdultButton.SetActive(true);
                }
            }
        }


        if (chokingAdultButton.activeSelf && cardiacArrestButton.activeSelf)
        {
            chokingAdultButtonForTransform.position = new Vector3(0.0f, 29.6f, 90.0f);
        }
        else
        {
            chokingAdultButtonForTransform.position = new Vector3(-17.3f, 29.6f, 90.0f);
        }

    }
}
