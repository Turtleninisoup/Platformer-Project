using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroya : MonoBehaviour
{
    int pointsCount;

    int timeCount;

    int coinsCount;

    public Text points;

    public Text time;

    public Text coins;

    LevelParserStarter thing;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(thing.gameObject);

            if (gameObject == thing.QuestionBox)
            {
                coinsCount++;
            }
        }

        points.text = pointsCount.ToString();
        time.text = timeCount.ToString();
        coins.text = coinsCount.ToString();
    }

    public void OnMouseDown()
    {
        Destroy(this.gameObject);
    }


}
