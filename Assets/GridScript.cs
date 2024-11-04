using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public Transform[,] grid;
    public GameObject[] middlePoints;
    public int width, height;
    private Points point;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Transform [width, height];
        point = FindObjectOfType<Points>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool isGridFull() {

        foreach (GameObject p in middlePoints) {
            Points pointComponent = p.GetComponent<Points>();
            // maybe in if statement pointComponent == null || 
            if (!pointComponent.isCovered()) {
                Debug.Log("not full yet");
                return false;
            }
        }
    
        return true; 
    }


}
