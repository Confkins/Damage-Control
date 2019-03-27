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
        StartCoroutine("CheckParts");
    }

    public IEnumerator CheckParts()
    {
        while(1 == 1)
        {
            yield return new WaitForSeconds(1);
            Debug.Log(sparePartCounter);
        }
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        sparePartText.text = "Spare Parts:" + sparePartCounter.ToString();
    }
}
