﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOR : MonoBehaviour
{
    public GameObject orStart, orEnd, orConnection;
    [SerializeField] private Sprite onSprite, offSprite;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Connection connection;
    public bool isTrue, functionCalled;
    public bool leg1, leg2;
    public CountGates counter;

    // Start is called before the first frame update
    void Start()
    {
        this.isTrue = false;
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        orStart.SetActive(false);
        orEnd.SetActive(false);
        orConnection.SetActive(false);
        // connection = GetComponent<Connection>();
    }

    // Update is called once per frame
    void Update()
    {
        if(leg1 || leg2){
            this.isTrue = true;
            connection.turnedOn = true;
            checkTrue();
            orStart.SetActive(true);
            orEnd.SetActive(true);
            orConnection.SetActive(true);
        } else {
            this.isTrue = false;
            connection.turnedOn = false;
            checkFalse();
            orStart.SetActive(false);
            orEnd.SetActive(false);
            orConnection.SetActive(false);
        }
        checkSprite();
    }

    void checkSprite(){
        if(isTrue){
            this.spriteRenderer.sprite = onSprite;
        } else {
            this.spriteRenderer.sprite = offSprite;
        }        
    }

    void checkTrue(){
        if(!functionCalled){
            functionCalled = true;
            counter.activeGates += 1;
        }
    }

    void checkFalse(){
        if(functionCalled){
            functionCalled = false;
            counter.activeGates -= 1;
        }
    }
}
