using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Noodles;
    
    public GameObject startNoodle;
    public GameObject currentNoodle;

    private AudioSource audioSource1;
    private AudioSource audioSource2;
    public AudioClip badPlacementSound;
    public AudioClip congratsSound; 


    // Start is called before the first frame update
    void Start()
    {
        SpawnStartingNoodle();
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentNoodle != null) {
            UserInput();  // move this into OnDrag
        }
        
    }

    void UserInput() {
        if (Input.GetKeyDown(KeyCode.R)) {  // press R to rotate noodle
            currentNoodle.transform.Rotate(0,0,90); 
        } else if (Input.GetKeyDown(KeyCode.F)) {  // press F to flip noodle
            currentNoodle.transform.Rotate(0,180,0);
        }
    }

    void SpawnStartingNoodle() {
        int index = Random.Range(0, Noodles.Length);
        double[] possibleX = {-8, -7, -6, -5, -4, -3, -2};
        double[] possibleY = {0.5, 1.5};
        int xPos = Random.Range(0, possibleX.Length);
        int yPos = Random.Range(0, possibleY.Length);
        startNoodle = Instantiate(Noodles[index], new Vector3((float)possibleX[xPos], (float)possibleY[yPos], 0), Quaternion.identity);
        GameObject.Destroy(Noodles[index]);

        // Set a flag on the Noodle script to indicate it is the starting noodle
        startNoodle.GetComponent<Draggable>().isStartingNoodle = true;
    }

    public void SetCurrentNoodle(GameObject noodle) {
        currentNoodle = noodle;
    }

    public void PlayErrorSound() {
        audioSource1.PlayOneShot(badPlacementSound);
    }

    public void PlayCongratsSound() {
        audioSource2.PlayOneShot(congratsSound);
    }

}
