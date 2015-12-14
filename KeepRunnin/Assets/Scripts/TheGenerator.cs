using UnityEngine;

public class TheGenerator : MonoBehaviour 
{

    public GameObject thePlatform;
    public Transform genPoint;
    public float distanceBetween;
    private float platformWidth;
    public float minDist;
    public float maxDist;
    public int selection;
    public float[] widths;
    public ObjectPool[] thePool;

    public float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxheightChange;
    private float heightChange;

    private CoinGen cg;
    public float coinThreshold;


    // Use this for initialization
    void Start()
    {
        widths = new float[thePool.Length];

        for (int i = 0; i < thePool.Length; i++)
        {
            widths[i] = thePool[i].poolObj.GetComponent<BoxCollider2D>().size.x;
        }//for

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
        cg = FindObjectOfType<CoinGen>();
    }//start

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < genPoint.position.x)
        {
            distanceBetween = Random.Range(minDist, maxDist);

            selection = Random.Range(0, thePool.Length);

            heightChange = transform.position.y + Random.Range(maxheightChange, -maxheightChange);

            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }//if
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }//else if

            transform.position = new Vector3(transform.position.x + (widths[selection] / 2) + distanceBetween, heightChange, transform.position.z);

            GameObject newPlatform = thePool[selection].GetPoolObj();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if (Random.Range(0f, 100f) < coinThreshold)
            {
                cg.SpawnCoin(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }
            transform.position = new Vector3(transform.position.x + (widths[selection] / 2), transform.position.y, transform.position.z);

        }
    }
}
