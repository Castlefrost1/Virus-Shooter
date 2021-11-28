using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    //instance setup
    public static Points instance;

    //variable assign
    public Text PointsText;
    public Text ItemText;
    int PointsInt = 0, ItemInt = 0;

    //untuk memulai instance sebelum game berlangsung
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PointsText.text = "Point : " + PointsInt.ToString();
        ItemText.text = "Antidote Collected : " + ItemInt.ToString();
    }

    //function untuk menambahkan score
    public void AddPoints()
    {
        PointsInt += 1;
        PointsText.text = "Point : " + PointsInt.ToString();
    }

    public void AddItem()
    {
        ItemInt += 1;
        ItemText.text = "Antidote Collected : " + ItemInt.ToString();
    }
}
