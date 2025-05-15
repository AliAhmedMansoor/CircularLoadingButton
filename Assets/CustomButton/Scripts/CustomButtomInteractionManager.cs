
using UnityEngine;
using UnityEngine.UIElements;

public class CustomButtomInteractionManager : MonoBehaviour
{
    private CustomCircle primaryCircle;
    private CustomCircle secondaryCircle;
    private CustomPath circularLoader;

    private const string PrimaryCircleName = "PrimaryCircle";
    private const string SecondaryCircleName = "SecondaryCircle";
    private const string CircularLoaderName = "CircularLoader";
    
    private bool isPressed;
    private LerpNumber lerper;
   
    [SerializeField]
    private float lerpRate;// The amount by which the point has changed in 1 second

    private float rewindAngle;// The angle to start Rewinding from
    private float forwardAngle;// The angle to start winding from
    void Awake()
    {
 
        VisualElement root=GetComponent<UIDocument>().rootVisualElement;
       
        primaryCircle = root.Q<CustomCircle>(PrimaryCircleName);
        secondaryCircle = root.Q<CustomCircle>(SecondaryCircleName);
        circularLoader = root.Q<CustomPath>(CircularLoaderName);

      
        lerper = new(lerpRate);
     
    }
    private void OnEnable()
    {
        secondaryCircle.RegisterCallback<MouseDownEvent>(CustomButtonClicked);
        secondaryCircle.RegisterCallback<MouseUpEvent>(CustomButtonClickedOff);
    }

    private void CustomButtonClickedOff(MouseUpEvent evt)
    {
        
        primaryCircle.style.scale = new StyleScale(new Scale(new Vector2(1, 1)));
        secondaryCircle.style.scale = new StyleScale(new Scale(new Vector2(1, 1)));
        circularLoader.style.scale = new StyleScale(new Scale(new Vector2(1, 1)));
        isPressed = false;
    }

    private void CustomButtonClicked(MouseDownEvent evt)
    {
        primaryCircle.style.scale = new StyleScale(new Scale(new Vector2(1.5f,1.5f)));
        secondaryCircle.style.scale = new StyleScale(new Scale(new Vector2(2f, 2f)));
        circularLoader.style.scale = new StyleScale(new Scale(new Vector2(1.5f,1.5f)));
        isPressed = true;
    
    }

    private void OnDisable()
    {
        secondaryCircle.UnregisterCallback<MouseDownEvent>(CustomButtonClicked);
        secondaryCircle.UnregisterCallback<MouseUpEvent>(CustomButtonClickedOff);
    }


    private void Update()
    {
        if(isPressed)
        {
           

            circularLoader.EndAngle = lerper.Lerp(forwardAngle,360);
            rewindAngle = circularLoader.EndAngle;
        
           
        }
        
        else if(circularLoader.EndAngle!=0)
        {
            circularLoader.EndAngle = lerper.Lerp(rewindAngle,0);
            forwardAngle=circularLoader.EndAngle;
         
        }
       
    }


}
