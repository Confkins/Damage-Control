using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SparePartSystem : SystemSuper
{
    public TMP_Text sparePartText;

    // Start is called before the first frame update
    void Start()
    {

    
    }

    // Update is called once per frame
    void Update()
    {
        sparePartText.text = "Spare Parts:" + sparePartCounter.ToString();
    }
}
