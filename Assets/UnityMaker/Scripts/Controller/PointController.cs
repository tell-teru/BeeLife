using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ポイント管理のクラス
/// </summary>
public class PointController : MonoBehaviour
{
    [SerializeField] private Text coin;
    [SerializeField] private Text point;
    private int playerCoin;
    private int playerPoint;


    public void Awake()
    {
        LoadData();
        SetData();
    }


    public void AddCoin()
    {
        SetData();
        SaveData();
    }


    public void LossCoin()
    {
        SetData();
        SaveData();
    }


    public void BigAddCoin()
    {
        playerCoin += 30;
        playerPoint += 3000;
        SetData();
        SaveData();
    }


    public void BigLossCoin()
    {
        if (playerCoin >= 30 && playerPoint >= 3000)
        {
            playerCoin -= 30;
            playerPoint -= 3000;
        }
        else
        {
            playerCoin = 0;
            playerPoint = 0;
        }

        SetData();
        SaveData();
    }


    private void SetData()
    {
        coin.text = playerCoin.ToString("000");
        point.text = playerPoint.ToString("0000000");
    }


    private void LoadData()
    {
        playerCoin = PlayerPrefs.GetInt("coin", 0);
        playerPoint = PlayerPrefs.GetInt("point", 0);
    }


    private void SaveData()
    {
        PlayerPrefs.SetInt("coin", playerCoin);
        PlayerPrefs.SetInt("point", playerPoint);
    }
}