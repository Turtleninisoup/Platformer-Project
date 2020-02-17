﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LevelParserStarter : MonoBehaviour
{
    public string filename;

    public GameObject Rock;

    public GameObject Brick;

    public GameObject QuestionBox;

    public GameObject Stone;

    public Transform parentTransform;

    int pointsCount;

    int timeCount;

    int coinsCount;

    public Text points;

    public Text time;

    public Text coins;


    // Start is called before the first frame update
    void Start()
    {
        RefreshParse();
    }


    private void FileParser()
    {
        string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/", filename);

        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            int row = 0;

            while ((line = sr.ReadLine()) != null)
            {
                int column = 0;
                char[] letters = line.ToCharArray();
                foreach (var letter in letters)
                {
                    //Call SpawnPrefab
                    SpawnPrefab(letter, new Vector3(column, row, 0));
                    column++;
                }
                row--;
            }

            sr.Close();
        }
    }

    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        GameObject ToSpawn;

        switch (spot)
        {
            case 'b': Debug.Log("Spawn Brick");
                ToSpawn = Brick;
                break;
            case '?': Debug.Log("Spawn QuestionBox");
                ToSpawn = QuestionBox;
                break;
            case 'x': Debug.Log("Spawn Rock");
                ToSpawn = Rock;
                break;
            case 's': Debug.Log("Spawn Rock");
                ToSpawn = Stone;
                break;
            //default: Debug.Log("Default Entered"); break;
            default: return;
                //ToSpawn = //Brick;       break;
        }

        ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
        ToSpawn.transform.localPosition = positionToSpawn;
    }

    public void RefreshParse()
    {
        GameObject newParent = new GameObject();
        newParent.name = "Environment";
        newParent.transform.position = parentTransform.position;
        newParent.transform.parent = this.transform;
        
        if (parentTransform) Destroy(parentTransform.gameObject);

        parentTransform = newParent.transform;
        FileParser();
    }

    public void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);

            if (gameObject == QuestionBox)
            {
                coinsCount++;
            }
        }

        points.text = pointsCount.ToString();
        time.text = timeCount.ToString();
        coins.text = coinsCount.ToString();


    }
}
