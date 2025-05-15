using System;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

[UxmlElement]
public partial class CustomPath:VisualElement
{
//===================================================================
    private float endAngle = 90;
    [UxmlAttribute]
    public float EndAngle
    {
        get => endAngle;
        set
        {
            endAngle = value;
            MarkDirtyRepaint();
        }
    }
//===================================================================
    private float lineWidth = 10;
    [UxmlAttribute]
    private float LineWidth
    {
        get => lineWidth;
        set
        {
            lineWidth = value;
            MarkDirtyRepaint();
        }
    }
//===================================================================
    private float radius = 50;
    [UxmlAttribute]
    private float Radius
    {
        get => radius;
        set
        {
            radius = value;
            style.width = 2*value;
            style.height = 2*value;
            MarkDirtyRepaint();
        }
    }
//===================================================================


    private int segments = 10;
    [UxmlAttribute]
    private int Segments
    {
        get => segments;
        set
        {
            segments = value;
            MarkDirtyRepaint();
        }
    }
//===================================================================
    public CustomPath()
    {
        generateVisualContent += DrawCircularPath;

    }

    private void DrawCircularPath(MeshGenerationContext context)
    {
      
        Painter2D painter = context.painter2D;

        painter.strokeColor = Color.red;
        painter.lineWidth = lineWidth;

        painter.lineJoin = LineJoin.Round;

        Vector2 center = contentRect.center; 
     
        painter.BeginPath();

        float b = 0;
        float p = 0;
       
        painter.MoveTo(center+new Vector2(radius,0));
        for (float angle = 0; angle <= endAngle; angle+=(360f/segments))
        {
            b = radius * Mathf.Cos(Mathf.Deg2Rad * angle);
            p = radius * Mathf.Sin(Mathf.Deg2Rad * angle);

            painter.LineTo(center + new Vector2(b, p));
           
           



        }
        if (endAngle >= 360)
             painter.LineTo(center + new Vector2(radius, 1f));
        //if a complete circle is drawn then connect the starting and ending points of the circle to avoid the "weird gap"
        painter.Stroke();
        painter.ClosePath();
    }

}
