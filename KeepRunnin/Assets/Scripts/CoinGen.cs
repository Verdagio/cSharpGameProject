using UnityEngine;

public class CoinGen : MonoBehaviour
{
    public ObjectPool coinPool;
    public float distBetween;
    
    public void SpawnCoin(Vector3 StartPos)
    {
        GameObject coin1 = coinPool.GetPoolObj();
        coin1.transform.position = StartPos;
        coin1.SetActive(true);

        GameObject coin2 = coinPool.GetPoolObj();
        coin2.transform.position = new Vector3(StartPos.x - distBetween, StartPos.y, StartPos.z);
        coin2.SetActive(true);

        GameObject coin3 = coinPool.GetPoolObj();
        coin3.transform.position = new Vector3(StartPos.x - distBetween, StartPos.y, StartPos.z);
        coin3.SetActive(true);
    }//SPAWN COINS
}//class