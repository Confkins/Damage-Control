﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

    public bool isSelected = false;

	// Use this for initialization
	void Start () {
		
	}
	
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if (hit.collider.tag == "Pawn")
                {
                    isSelected = true;
                }
                else
                {
                    isSelected = false;
                }
            }
        }
    }
}
