using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CublerAnim : MonoBehaviour
{
    public Text txt;
    bool growing;
    private float dt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        if (txt.fontSize > 140 || txt.fontSize < 100)
        {
            // Debug.Log("Changed font growing to: " + growing);
            growing = !growing;
        }
        if (dt >= 0.01f)
        {
            dt -= 0.01f;
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
}
