using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{

    public MeshRenderer DodecahedronMeshRenderer;

    [SerializeField] [Range(0f, 1f)] float lerpTime;

    [SerializeField] Color[] myColors;

    int colorIndex = 0;

    float t = 0;

    int len;

    // Start is called before the first frame update
    void Start()
    {
        DodecahedronMeshRenderer = GetComponent<MeshRenderer>();
        len = myColors.Length;
    }

    // Update is called once per frame
    void Update()
    {
        DodecahedronMeshRenderer.material.color = Color.Lerp(DodecahedronMeshRenderer.material.color, myColors[colorIndex], lerpTime*Time.deltaTime);

        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);

        if(t>.9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }
    }


}
