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
    public Material[] material;

    [SerializeField] protected int HP, STR, DEX, INT;

    public int hp => HP;
    public int str => STR;
    public int dex => DEX;
    public int Int => INT;

    //values to update while storing them between scenes
    public bool motivated;
    private int motivatedBonus;


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
    private void petMotivatedBonus()
    {
        if (motivated)
        {
            motivatedBonus = 2;
        }
        else if (!motivated)
        {
            motivatedBonus = 1;
        }
    }

    public void mutateElemental()
    {
        petElement = Random.Range(1, 5);
        renderer.sharedMaterial = material[petElement];
    }

    private void petElementBonus(int x, int y)
    {
        if (petElement == x)
        {
            elementalBonus = -1;

        }
        else if (petElement == y)
        {
            elementalBonus = 1;
        }
        else
        {
            elementalBonus = 0;
        }
    }

    public void dexUp()
    {
        petMotivatedBonus();
        petElementBonus(3, 4);
        DEX += ((1 * motivatedBonus) + elementalBonus);
        motivated = false;
    }

}
