using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CublerAnimation : MonoBehaviour
{
    public float changeTime;
    public float waitTime;

    private Color color;
    private TMP_Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = this.GetComponent<TMP_Text>();
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        //Save our initial color
        color = txt.color;

        //Get a random color to change to
        float r = Random.Range(0, 1.0f);
        float g = Random.Range(0, 1.0f);
        float b = Random.Range(0, 1.0f);

        Color newColor = new Color(r, g, b);

        float t = 0;

        while (t < 1)
        {
            //Set our color
            txt.color = Color.Lerp(color, newColor, t);
            //Update our t according to how much time has passed
            t += Time.deltaTime / changeTime;
            yield return null;
        }

        //If we have a waittime, wait and then start over
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(ChangeColor());
    }

}
