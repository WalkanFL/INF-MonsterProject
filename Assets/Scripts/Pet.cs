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

    public new Renderer renderer = new Renderer();
    public string petType;
    public string BPMutation;
    public int petElement = 0;
    int elementalBonus;
    //An array of all possible materials
    public Material[] material;
    //Value manipulated for the purpose of raising statistics
    public int statGain;

    //All the different statictics to use during gameplay
    [SerializeField] protected int HP, STR, DEX, INT;

    public int hp => HP;
    public int str => STR;
    public int dex => DEX;
    public int Int => INT;

    public bool motivated;


    void Awake()
    {
        if (Instance != null) { Destroy(this); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        renderer = GetComponent<Renderer>();
        renderer.enabled = true;
        renderer.sharedMaterial = material[petElement];
    }

    public void motivate()
    {
        motivated = true;

    }
    public int petMotivatedBonus()
    {
        if (motivated)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

    public void mutateElemental()
    {
        petElement = Random.Range(1, 5);
        renderer.sharedMaterial = material[petElement];
    }

    public int petElementBonus(int x, int y)
    {
        if (petElement == x)
        {
            return -1;

        }
        else if (petElement == y)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public void dexUp()
    {
        DEX += statGain;

        motivated = false;
    }

}
