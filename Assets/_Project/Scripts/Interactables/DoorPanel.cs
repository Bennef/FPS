﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPanel : MonoBehaviour, IInteractible
{
    public bool HasBeenInteractedWith { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    [SerializeField] Transform _doorToUnlock;

    public void Interact()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
