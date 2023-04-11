using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "INF MonsterProject/Pet")]
public class Pet : MonoBehaviour
{
    public static Pet Instance
    {
        get; set;
    }

    public string petType;
    public string BPMutation;
    public int petElement;

    [SerializeField] protected int HP, STR, DEX, INT;

    public int hp => HP;
    public int str => STR;
    public int dex => DEX;
    public int Int => INT;

    //values to update while storing them between scenes
    public bool motivated;


    void Awake()
    {
        if (Instance != null) { Destroy(this); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void dexUp()
    {
        int motivationBonus;
        if (motivated)
        {
            motivationBonus = 2;
        }
        else
        {
            motivationBonus = 1;
        }

        DEX += 1 * motivationBonus;

        motivated = false;
    }

}
