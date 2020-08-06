using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CublerAnim : MonoBehaviour
{
    public Text txt;
    bool growing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (txt.fontSize > 140 || txt.fontSize < 100)
        {
            // Debug.Log("Changed font growing to: " + growing);
            growing = !growing;
        }
        if (!growing)
        {
            txt.fontSize -= 1;
        }
        else
        {
            txt.fontSize += 1;
        }
    }
}
