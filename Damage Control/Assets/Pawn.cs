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
        this.pawn = gameObject;
        this.agent = GetComponent<NavMeshAgent>();
        agent.speed = 2;
        showName();
        StartCoroutine("Selector");
    }

    // Update is called once per frame
    void Update()
    {
        MoveToClick();
        ChooseAction();
        updateName();
    }
}
