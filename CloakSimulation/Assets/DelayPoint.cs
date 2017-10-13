using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DelayPoint : MonoBehaviour {

    public Transform selfTranform;
    Renderer render;
    Vector3 starPos;

    public Vector3 vec;

    public float factor = 1.0f;

	void Start () {
        selfTranform = transform;
        render = selfTranform.GetComponent<Renderer>();

        starPos = selfTranform.localPosition;

        //t2 = delayPoint.transform;


        //targetPoint = t2.TransformPoint(Vector3.zero);

        
        //render.sharedMaterial.SetVector("_DragPoint", t2.position);
        //newPosition = targetPoint;
	}
	
	void Update () {


        //starPos = Vector3.SmoothDamp(starPos, selfTranform.position, ref this.vec, 0.3f);

        //if (Vector3.SqrMagnitude(this.vec) > (0.1F)) {
        //    this.vec *= -1;
        //}
        //else {
        //    this.vec = Vector3.zero;
        //}

        var worldDirection = (starPos - selfTranform.localPosition);
        var veclength = worldDirection.magnitude * factor;
        this.vec = veclength * selfTranform.InverseTransformDirection(worldDirection);
        //UnityEngine.Debug.Log(result);
        //this.vec = (starPos - selfTranform.localPosition);
        //    /// Time.deltaTime;
        
        

        ////targetPoint = t2.TransformPoint(Vector3.zero);
        
        ////newPosition = Vector3.SmoothDamp(newPosition, targetPoint, ref velocity, delayTime);
        render.sharedMaterial.SetVector("_DragDirection", this.vec);
        starPos = selfTranform.localPosition;
	}
}
