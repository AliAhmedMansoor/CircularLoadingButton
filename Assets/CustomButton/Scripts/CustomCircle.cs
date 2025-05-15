using System;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;
[UxmlElement]
public partial class CustomCircle:VisualElement
{
    private static CustomStyleProperty<Color> s_FillColor = new("--primary-Fill");
    private static CustomStyleProperty<Color> s_StrokeColor = new("--primary-Stroke");
    
    private Color primaryFill = new(0.5f,0.5f,0.5f,0.5f);
    private Color primaryStroke = Color.white;


//---------------------------------------------------
    private float endAngle = 360;
    [UxmlAttribute]
    public float EndAngle {

        get => endAngle;
        set
        {
            endAngle = value;
            MarkDirtyRepaint();
        }
    
    
    }
//---------------------------------------------------
    private bool hasStroke = true;
    [UxmlAttribute]
    private bool HasStroke
    {
        get => hasStroke;
        set
        {
            hasStroke = value;
            MarkDirtyRepaint();
        }
    }
//----------------------------------------------------
    private float radius=5;
    [UxmlAttribute]
     private float Radius {
        get => radius;
        set
        {
            radius = value;
            style.width = 2 * radius;
            style.height = 2 * radius;
            MarkDirtyRepaint();
        }
    }
//----------------------------------------------------
    private float lineWidth = 8;
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
//----------------------------------------------------

    public CustomCircle()
    {
        RegisterCallback<CustomStyleResolvedEvent>(StyleResolved);
        generateVisualContent += DrawFilledCircle;

       
    }

    private void StyleResolved(CustomStyleResolvedEvent evt)
    {
        bool repaint = false;
        if (evt.customStyle.TryGetValue(s_FillColor, out primaryFill))
            repaint = true;
        if (evt.customStyle.TryGetValue(s_StrokeColor, out primaryStroke))
            repaint = true;

        if (repaint)
            MarkDirtyRepaint();
    }
    
    private void DrawFilledCircle(MeshGenerationContext context)
    {
        float width = contentRect.width;
        float height = contentRect.height;

        Painter2D painter = context.painter2D;
        DrawCircle(new Vector2(width*0.5f,height*0.5f),radius,hasStroke,primaryFill,painter);

    }

    private void DrawCircle(Vector2 center,float radius,bool hasStroke,Color fillColor,Painter2D painter,float scale=1)
    {
        painter.BeginPath();
        painter.lineWidth = lineWidth;
        painter.Arc(center, radius*scale, 0, endAngle);
        painter.ClosePath();
        painter.fillColor = fillColor;
        painter.Fill(FillRule.NonZero);
        if (hasStroke)
        {
            painter.strokeColor = primaryStroke;

            painter.Stroke();
        }
    }
   

    
   
}
