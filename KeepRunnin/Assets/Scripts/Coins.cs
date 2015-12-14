using UnityEngine;

public class Coins : MonoBehaviour
{
    public int giveScore;
    public ScoreManager sm;

    void Start() {
        sm = FindObjectOfType<ScoreManager>();
    }//start

    void Update() {

    }//Update

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "PlayerRight")
        {
            sm.AddPoints(giveScore);
            gameObject.SetActive(false);
        }//if its the player
    }//trigger
}//class