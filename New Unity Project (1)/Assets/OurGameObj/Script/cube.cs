using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cube : MonoBehaviour
{

    NewBehaviourScript gameController;
    public bool hited = false;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<NewBehaviourScript>();

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hited == false)
        {
            gameController.CallThisScript();
            hited = true;
        }
        Debug.Log("HIT!!!!!!!!!!!!!!!!!!!!!!!");
    }
}
