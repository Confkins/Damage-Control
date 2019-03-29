using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SparePartSystem : SystemSuper
{
    public Text sparePartText;

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
