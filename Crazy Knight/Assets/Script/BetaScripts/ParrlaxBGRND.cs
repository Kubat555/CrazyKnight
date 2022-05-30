using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrlaxBGRND : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform followTarget;
    [SerializeField, Range(0f, 1f)] float parralaxStrenght = 0.1f;
    [SerializeField] bool disableVerticalParralax;
    Vector3 targetPrebiodPosition;
    void Start()
    {
        if(!followTarget){
            followTarget = Camera.main.transform;
        }
    }

    
    void Update()
    {
        var delta = followTarget.position - targetPrebiodPosition;
        if(disableVerticalParralax) delta.y = 0;

        targetPrebiodPosition = followTarget.position;
        transform.position += delta * parralaxStrenght;
    }
}
