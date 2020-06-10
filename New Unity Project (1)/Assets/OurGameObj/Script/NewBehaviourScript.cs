using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject MY_Camera;
    public GameObject[] originOBJ;
    public GameObject NewGameOBJ;
    public GameObject[] LevelObj;
    public GameObject my_player;

    public GameObject Be_Hit;
    public GameObject Pass;

    public int Number;
    public bool StartFlag = false;
    public bool EndFlag = false;

    public bool behit = true;

    public float time;

    public float StartTime = 4;

    public Vector3 spawnPos;

    public GameObject textt;
    public GameObject StartText;
    public GameObject timmingText;
    public GameObject PointText;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            LevelObj[i].active = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        if ((StartFlag == false) && (EndFlag == false))
        {
            StartTime -= Time.deltaTime;
            StartText.GetComponent<Text>().text = ((int)StartTime).ToString();
            if (StartTime < 1)
            {
                StartFlag = true;
                StartText.GetComponent<Text>().text = "";
            }
        }
        if (StartFlag == true)
        {
            if (NewGameOBJ == null)
            {
                behit = true;
                int tempp = Random.Range(0, originOBJ.Length);
                NewGameOBJ = Instantiate(originOBJ[tempp], spawnPos, Quaternion.identity);
                Debug.Log(tempp);
            }

            Vector3 temp = NewGameOBJ.GetComponent<Transform>().position;
            temp.z -= Time.deltaTime;
            NewGameOBJ.GetComponent<Transform>().position = temp;
            if (temp.z < -1)
            {
                if (behit == true)
                {
                    Instantiate(Pass);
                }
                Destroy(NewGameOBJ);
                behit = true;
                int tempp = Random.Range(0, originOBJ.Length);

                NewGameOBJ = Instantiate(originOBJ[tempp], spawnPos, Quaternion.identity);

                Debug.Log(tempp);
            }
            time -= Time.deltaTime;

            if (((((int)time) % 60) / 10) <= 0)
            {
                timmingText.GetComponent<Text>().text = "Time: " + ((int)time) / 60 + ":0" + ((int)time) % 60;
            }
            else
            {
                timmingText.GetComponent<Text>().text = "Time: " + ((int)time) / 60 + ":" + ((int)time) % 60;
            }
        }
        if ((StartFlag == true) && (time < 0))
        {
            StartFlag = false;
            EndFlag = true;
            my_player.GetComponent<Transform>().rotation = new Quaternion(0, 1, 0, 0);


            PointText.GetComponent<Text>().text = " Your Muscle Power : " + (100 - Number * 5).ToString();

            if (Number > 13)
            {
                LevelObj[3].active = true;
            }
            if ((Number <= 13) && (Number > 8))
            {
                LevelObj[2].active = true;
            }
            if ((Number <= 8) && (Number > 3))
            {
                LevelObj[1].active = true;
            }
            if (Number <=3)
            {
                LevelObj[0].active = true;
            }
            //my_player.GetComponent<AvatarController>().playerIndex = 12;
        }
    }

    public void CallThisScript()
    {

        Number++;
        Debug.Log("call game controller" + Number);
        Instantiate(Be_Hit);
        behit = false;
        textt.GetComponent<Text>().text = "HIT : " + Number;
    }
}
