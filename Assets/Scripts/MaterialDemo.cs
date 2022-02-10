using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class MaterialDemo : MonoBehaviour {
    Material SphereMaterial;
    SpriteRenderer meshRenderer;
    // Use this for initialization
    private void OnEnable() {
        SphereMaterial = Resources.Load<Material>("defalut-Sp");
        meshRenderer = GetComponent<SpriteRenderer>();
        // Get the current material applied on the GameObject
        Material oldMaterial = meshRenderer.material;
        //Debug.Log("Applied Material: " + oldMaterial.name);
        // Set the new material on the GameObject
        meshRenderer.material = SphereMaterial;
    }

}