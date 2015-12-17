using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SH_DisplayStats : MonoBehaviour {

    public static SH_DisplayStats DS;

    public Text LineOne;
    public Text LineTwo;

    public void Awake()
    {
        if (DS == null)
            DS = this;

        LineOne.text = "";
        LineTwo.text = "";
    }

    /// <summary>
    /// diplay submitted string on line one. usualy a name
    /// </summary>
    /// <param name="p"></param>
    internal void DisplayLineOne(string p)
    {
        LineOne.text = p;
    }
    /// <summary>
    /// clears info from the text feilds
    /// </summary>
    internal void Clear()
    {
        LineOne.text = "";
        LineTwo.text = "";
    }

    /// <summary>
    /// display a stat submitted
    /// </summary>
    /// <param name="p"></param>
    /// <param name="number"></param>
    internal void DisplayLineTwo(string p, float number)
    {
        LineTwo.text = p+" "+ number;
    }
}
