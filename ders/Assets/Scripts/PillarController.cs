using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarController : MonoBehaviour
{
    public enum ColumnColorType
    {
        Blue,
        Yellow,
        Orange,
        Pink
    }
    public ColumnColorType colorType;
    private Renderer colRenderer;

    void Start()
    {
        colRenderer = GetComponent<Renderer>();
        SetColorByEnum(); //Taglarına göre kolonlara rengini veriyoruz
    }

    void SetColorByEnum()
    {
        switch (colorType)
        {
            case ColumnColorType.Blue:
                colRenderer.material.color = Color.blue;
                break;
            case ColumnColorType.Yellow:
                colRenderer.material.color = Color.yellow;
                break;
            case ColumnColorType.Orange:
                colRenderer.material.color = new Color(1f, 0.5f, 0f);//Unity de turuncu olmadığı için manuel olarak ekledim
                break;
            case ColumnColorType.Pink:
                colRenderer.material.color = new Color(1f, 0.71f, 0.76f);//Unity de pembe olmadığı için manuel olarak ekledim
                break;
        }
    }
}

