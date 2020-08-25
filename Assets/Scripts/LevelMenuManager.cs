using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuManager : MonoBehaviour
{
    public Button[] lvlButtons;
    private bool TODO = true;

    // Start is called before the first frame update
    void Start()
    {
        //Handle saving and loading of reached levels
        if (!TODO)
        {
            int levelReached = PlayerPrefs.GetInt("levelReached", 1);

            for (int i = 0; i < levelReached; i++)
            {
                if (i + 1 > levelReached)
                {
                    lvlButtons[i].interactable = false;
                }
            }
        }
    }

}
