using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] originOBJ;
    public GameObject NewGameOBJ;
    public int Number;
    public Vector3 spawnPos = new Vector3(-2f, 1.86f, 2f);

    public GameObject textt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(NewGameOBJ==null)
        {
            int tempp= Random.Range(0,4);
            NewGameOBJ = Instantiate(originOBJ[tempp], spawnPos, Quaternion.identity);
        }

        Vector3 temp = NewGameOBJ.GetComponent<Transform>().position;
        temp.z -= 0.5f*Time.deltaTime;
        NewGameOBJ.GetComponent<Transform>().position = temp;
        if(temp.z<-2)
        {
           
            Destroy(NewGameOBJ);
            int tempp = Random.Range(0, 4);
            NewGameOBJ = Instantiate(originOBJ[tempp], spawnPos, Quaternion.identity);
        }
    }

    public void CallThisScript()
    {
        
        Number++;
        Debug.Log("call game controller"+ Number);

        textt.GetComponent<Text>().text = "HIT : " + Number;
    }
}
