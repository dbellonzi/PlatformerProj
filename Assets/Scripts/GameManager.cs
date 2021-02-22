using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text Score;
    [SerializeField] private Text Coins;
    [SerializeField] private Text World;
    [SerializeField] private Text TimeField;

    private string timeBase = "TIME\n";
    private string scoreBase = "MARIO\n";
    private string coinBase = "x ";
    private float timeLeft;
    public int curScore;
    public int curCoins;

    public float MAXTIME = 999;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = MAXTIME;
        curScore = 0;
        curCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        updateOSD();
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit) && hit.collider.tag == "hittable")
            {
                Debug.Log(hit.collider.tag);
                if(hit.collider.name == "QuestionBox(Clone)") curCoins++;
                Destroy(hit.collider.gameObject);
            }
        }
    }

    private void updateOSD()
    {
        Score.text = scoreBase + curScore.ToString("D6");
        Coins.text = coinBase + curCoins.ToString("D2");
        TimeField.text = timeBase + timeLeft.ToString("N0");
    }
}