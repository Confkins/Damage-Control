using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SparePartSystem : SystemSuper
{
    public TMP_Text sparePartText;
    public TMP_Text timer;

    // Start is called before the first frame update
    void Start()
    {
        count = 180;
        sparePartCounter = 0;
        StartCoroutine("countdown");
    }

    public IEnumerator countdown()
    {
        while(count != 0)
        {
            yield return new WaitForSeconds(1);
            count--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        sparePartText.text = "Spare Parts:" + sparePartCounter.ToString();
        timer.text = "Time Remaining:" + count.ToString(); 
    }
}
