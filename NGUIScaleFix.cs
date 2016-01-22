using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NGUIScaleFix : MonoBehaviour {

    List<Transform> cpTransList = new List<Transform>();
    Animation anima;

    void Start()
    {
        anima = animation;
        var ps = gameObject.GetComponentsInChildren<UIPanel>();
        
        for (int i = 0; i < ps.Length; i++)
        {
            var p = ps[i];
            if (p.clipping == UIDrawCall.Clipping.SoftClip)
            {
                cpTransList.Add(p.transform);
            }
        }
    }

    public void LateUpdate()
    {
        FixScale();
    }

    void FixScale()
    {
        if (anima != null )
        {
            for (int i = 0; i < cpTransList.Count; i++)
            {
                var p = cpTransList[i];
                var pScale = p.parent.transform.lossyScale;
                var fVak = pScale.y;
                var scale = pScale;
                scale.x = fVak / pScale.x;
                scale.y = fVak / pScale.y;
                scale.z = fVak / pScale.z;
                p.localScale = scale;
            }
        }
	}
}
