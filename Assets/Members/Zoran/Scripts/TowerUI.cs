using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
    private Color emptyTowerStartColor;
    private Color highlightedColor = new Color(0, 78, 0);

    void Start()
    {
        emptyTowerStartColor = GetComponent<Renderer>().material.color;
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.EnableKeyword("_EmissionColor");
        GetComponent<Renderer>().material.SetColor("_EmissionColor", highlightedColor);
        Debug.Log("MouseEnter Worked");
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.SetColor("_EmissionColor", emptyTowerStartColor);
        Debug.Log("MouseExit Worked");
    }
}
