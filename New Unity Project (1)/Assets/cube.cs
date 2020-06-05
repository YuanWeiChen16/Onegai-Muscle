using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cube : MonoBehaviour
{

    NewBehaviourScript gameController;
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
        gameController.CallThisScript();
        //Debug.Log("DIE : ");
    }
    private void OnCollisionEnter(Collision collision)
    {
        gameController.CallThisScript();
        Debug.Log("DIE : ");
    }
}
