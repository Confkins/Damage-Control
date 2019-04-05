using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pawn : PawnSuper
{
    public Pawn()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.agent = GetComponent<NavMeshAgent>();
        agent.speed = 2;
        StartCoroutine("Selector");
    }

    // Update is called once per frame
    void Update()
    {
        MoveToClick();
        ChooseAction();
    }
}
