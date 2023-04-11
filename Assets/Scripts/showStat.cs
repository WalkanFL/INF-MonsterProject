using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showStat : MonoBehaviour
{

    public void showHP(TMP_Text textAsset)
    {
        textAsset.SetText("HP: " + Pet.Instance.hp);
    }

    public void showSTR(TMP_Text textAsset)
    {
        textAsset.SetText("STR: " + Pet.Instance.str);
    }

    public void showDEX(TMP_Text textAsset)
    {
        textAsset.SetText("DEX: " + Pet.Instance.dex);
    }
    public void showINT(TMP_Text textAsset)
    {
        textAsset.SetText("INT: " + Pet.Instance.Int);
    }
}
