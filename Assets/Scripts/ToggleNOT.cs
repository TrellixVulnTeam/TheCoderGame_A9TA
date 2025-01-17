﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleNOT : MonoBehaviour
{
    public GameObject notStart, notEnd, notConnection;
    [SerializeField] private Sprite onSprite, offSprite;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Connection connection;
    public bool isTrue, functionCalled;
    public bool leg;
    public CountGates counter;

    // Start is called before the first frame update
    void Start()
    {
        this.isTrue = false;
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        notStart.SetActive(true);
        notEnd.SetActive(true);
        notConnection.SetActive(true);
        // connection = GetComponent<Connection>();
    }

    // Update is called once per frame
    void Update()
    {
        if(leg){
            this.isTrue = false;
            connection.turnedOn = false;
            notStart.SetActive(false);
            notEnd.SetActive(false);
            notConnection.SetActive(false);
            checkFalse();

        } else {
            this.isTrue = true;
            connection.turnedOn = true;
            notStart.SetActive(true);
            notEnd.SetActive(true);
            notConnection.SetActive(true);
            checkTrue();
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
