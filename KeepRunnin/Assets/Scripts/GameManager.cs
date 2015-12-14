using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform generator;
    private Vector3 startPoint;

    public Controller player;
    private Vector3 playerStartPoint;

    private Destruction[] platformList;
    private ScoreManager score;
    public RespawnMenu resMenu;

    void Start()
    {
        startPoint = generator.position;
        playerStartPoint = player.transform.position;

        score = FindObjectOfType<ScoreManager>();

    }//start

    void Update()
    {

    }//update

    public void Respawn()
    {

        score.scoreInc = false;
        player.gameObject.SetActive(false);

        resMenu.gameObject.SetActive(true);

    }

    public void Reset()
    {
        resMenu.gameObject.SetActive(false);

        platformList = FindObjectsOfType<Destruction>();

        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }//Remove old platforms that have been generated

        player.transform.position = playerStartPoint;
        generator.position = startPoint;
        player.gameObject.SetActive(true);
        score.scoreCount = 0;
        score.scoreInc = true;
    }


}//class