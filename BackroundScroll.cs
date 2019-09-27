using UnityEngine;

public class BackroundScroll : MonoBehaviour
{
    // Defining variables 
    public float scrollSpeed = 0.2f;
    private MeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>(); //Getting component 
    }

    void Update()
    {
        //Increasing x value of offset property
        float x = Time.time * scrollSpeed;
        Vector2 offset = new Vector2(x, 0);
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset); //Offseting mesh - for scrolling effect (backround image WRAP MODE must be set to REPEAT)
    }
}
