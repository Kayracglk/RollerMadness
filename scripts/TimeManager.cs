using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{
    [SerializeField] float finishTime = 10f;
    [SerializeField] public bool gameOver = false;
    [HideInInspector] public bool gameFinished = false;
    [SerializeField] private Text timeText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private List<GameObject> destroyAfterGame = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver || !gameFinished)
            UpdateText();
        if (Time.timeSinceLevelLoad >= finishTime && gameOver == false)
        {
            gameFinished = true;
            winPanel.SetActive(true);
            losePanel.SetActive(false);
            UpdateObjectList("Objects");
            UpdateObjectList("Enemy");
            foreach (GameObject objects in destroyAfterGame)
            {
                Destroy(objects);
            }
        }
        if(gameOver)
        {
            winPanel.SetActive(false);
            losePanel.SetActive(true);
            UpdateObjectList("Objects");
            UpdateObjectList("Enemy");
            foreach (GameObject objects in destroyAfterGame)
            {
                Destroy(objects);
            }
        }
    }
    private void UpdateText()
    {
        timeText.text = "Time: " + (int)Time.time;
    }
    private void UpdateObjectList(string tag)
    {
        destroyAfterGame.AddRange(GameObject.FindGameObjectsWithTag(tag));
    }
}
