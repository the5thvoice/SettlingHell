using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SH_DisplayStats : MonoBehaviour {

    public static SH_DisplayStats DS;

    public Text LineOne;
    public Text LineTwo;

    public 

    void Awake()
    {
        if (DS == null)
            DS = this;

        LineOne.text = "";
        LineTwo.text = "";
    }

    internal void DisplayName(string p)
    {
        LineOne.text = p;
    }

    internal void Clear()
    {
        LineOne.text = "";
        LineTwo.text = "";
    }

    internal void DisplayLineTwo(string p, float number)
    {
        LineTwo.text = p+" "+ number;
    }
}
