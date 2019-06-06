using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorScript : MonoBehaviour
{
    public string hexCode = "FFBA53";


    void Start()
    {
        //Fetch the Renderer from the GameObject
        Renderer rend = GetComponent<MeshRenderer>();

        //Set the main Color of the Material to the specificed hex 
        rend.material.color = HexToColor(hexCode);
       
    }

    Color HexToColor(string hex)
    {
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, 255);
    }
}
