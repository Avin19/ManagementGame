using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCountervisuaal : MonoBehaviour
{
    private Animator animator;
    private const string OPEN_CLOSE= "OpenClose";
    [SerializeField] private ContainerCounter containerCounter;
    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {
        containerCounter.OnPlayerGrabbedObject += CounterContainer_OnPlayerGrabbedObject;
    }

    private void CounterContainer_OnPlayerGrabbedObject(object sender, EventArgs e)
    {
        animator.SetTrigger(OPEN_CLOSE);
    }
}
