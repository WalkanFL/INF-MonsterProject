using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petMaterial : MonoBehaviour
{

    private new Renderer renderer = new Renderer();

    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.enabled = true;
    }

    void Update()
    {
        renderer.sharedMaterial = Pet.Instance.material[Pet.Instance.petElement];
    }
}
