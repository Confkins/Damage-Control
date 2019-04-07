using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarTEST : MonoBehaviour
{

    public Slider testSlider;

    // Start is called before the first frame update
    void Start()
    {
        testSlider.value = 1;
        StartCoroutine("foobar");
    }

    IEnumerator foobar()
    {
        while(1==1)
        {
            if(testSlider.value < 0.1)
            {
                testSlider.fillRect.transform.localScale = new Vector3(0,0,0);
            }
            else
            {
                testSlider.fillRect.transform.localScale = new Vector3(1, 1, 1);
            }
            yield return new WaitForSeconds(2);
            testSlider.value -= 0.1f;
        }
        
    }
    // Update is called once per frame
}
