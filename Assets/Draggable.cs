using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    
    private Vector3 offset;
    private bool dragging = false;
    private GameManager gameManager;

    private Timer timer;

    private GridScript grid;

    private bool onTop = false;
    public bool isStartingNoodle = false;
    Vector3 startPos;




    private void Start() {
        
        gameManager = FindObjectOfType<GameManager>();
        timer = FindObjectOfType<Timer>();
        grid = FindObjectOfType<GridScript>();
        startPos = transform.position;
    }

    private void OnMouseDown()
    {
        if (isStartingNoodle) return; // prevent starting noodle from being dragged

        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        dragging = true;
        gameManager.SetCurrentNoodle(gameObject);
    }

    private void OnMouseUp()
    {
        if (onTop) {
            gameManager.PlayErrorSound();
            Instantiate(gameObject, startPos, Quaternion.identity);
            Destroy(gameObject);
            
        }
        dragging = false;
        gameManager.SetCurrentNoodle(null);
        //timer.isDone();
        if (grid.isGridFull()) {
            Debug.Log("Grid is full!");
            timer.StopStopwatch();
            gameManager.PlayCongratsSound();
        }
    }


    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.GetComponent<Draggable>() && dragging) {
            // reinstantiate new object
            onTop = true;
        }
    }


    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.GetComponent<Draggable>() && dragging) {
            // reinstantiate new object
            onTop = false;
        }
    }

    private void Update()
    {
        if (dragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            transform.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, 0);
        }
    }


}
