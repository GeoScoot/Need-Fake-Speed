using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text pointsLabel;


    public void RefreshUI(Score score)
    {
        pointsLabel.text = score.points.ToString();
    }

    public void StopGame()
    {
        pointsLabel.text = "GG WP";
    }


    // Start is called before the first frame update
    void Start()
    {
        pointsLabel.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
