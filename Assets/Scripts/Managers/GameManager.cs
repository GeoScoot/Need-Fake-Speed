using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public Player player;
    Score score = new Score();

    public void HandleCollision(GameObject gameObject)
    {
        if(gameObject.tag == "Bonus")
        {
            TakeBonus(gameObject);
        }
        else
        if (gameObject.tag == "Obstacle")
        {
            GameOver();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void TakeBonus(GameObject gameObject)
    {
        var bonus = gameObject.GetComponent<Bonus>();
        score.points += bonus.points;
        uiManager.RefreshUI(score);
        Destroy(gameObject);
    }
    private void GameOver()
    {
        uiManager.StopGame();
        player.gameOver = true;
    }
}
