using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public Collider2D currNoodle = null;

    public bool covered = false;

    void OnTriggerEnter2D(Collider2D collider) {
        if (!covered) {
            Debug.Log("covered");
            currNoodle = collider;
            this.covered = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider == currNoodle) {
            Debug.Log("uncovered");
            this.covered = false;
            currNoodle = null;
        }

    }


    public bool isCovered() {
        return this.covered;
    }
}
