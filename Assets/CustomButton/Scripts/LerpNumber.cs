using System.Diagnostics;
using UnityEngine;

public class LerpNumber
{

    private float startPoint;
    private float endPoint;
    private float lerpRate; // The amount by which the point has changed in 1 second
  
    private bool isLerping;

    private float currentValue;
  
    private Stopwatch timer;


    
    public LerpNumber(float lerpRate)
    {
        this.lerpRate = lerpRate; //notice how lerpRate cannot be changed after constructor call
        timer = new Stopwatch();
    }

    /// <summary>
    /// Function designed to be called in the Update method. if the startPoint or endPoint change
    /// while "isLerping" is still true then the lerp will start all over again from t=0
    /// </summary>

    public float Lerp(float startPoint,float endPoint)
    {
        //checking if any value has been changed while lerping was still ongoing
        if(isLerping && (this.startPoint!=startPoint || this.endPoint!=endPoint))
        {
            startLerping(startPoint,endPoint);
        }
       
        if(currentValue==endPoint)
        {
            if (isLerping)
            {
                StopLerp();
                ResetLerp();
            }
            return endPoint;
        }
        if(!isLerping)
        {
            startLerping(startPoint,endPoint);
        }
        currentValue = getNextValue();

        return currentValue;
    }
    private float getLerpTime()
    {
        return Mathf.Abs(startPoint-endPoint)/lerpRate;
        
    }
    private float getNextValue()
    {
        float time = getLerpTime();
        if(isLerping && timer.Elapsed.TotalSeconds < time)
        {
          

            float normalizedTime = (float)timer.Elapsed.TotalSeconds / time;


            float value = Mathf.Lerp(startPoint, endPoint, normalizedTime);
            return value;
        }
        else if(!isLerping)
        {
            return startPoint;
        }
        return endPoint;
    }
    private void startLerping(float startPoint,float endPoint)
    {
       
        if(isLerping)
        {
            timer.Stop();
            timer.Reset();
        }
        this.startPoint = startPoint;
        this.endPoint=endPoint;
     
        isLerping = true;
        currentValue = startPoint;
        timer.Start();

    }
    private void StopLerp()
    {
        if (!isLerping)
            return;

        isLerping = false;
        timer.Stop();
    }
    private void ResetLerp()
    {
        
        timer.Reset();
    }

}
