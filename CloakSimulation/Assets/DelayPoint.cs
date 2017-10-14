using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DelayPoint : MonoBehaviour {

    public Transform selfTranform;
    Renderer render;
    public Vector3 starPos;

    Vector3 vec;

    public float factor = 1.0f;

	void Start () {
        selfTranform = transform;
        render = selfTranform.GetComponent<Renderer>();

        starPos = selfTranform.position;

        //t2 = delayPoint.transform;


        //targetPoint = t2.TransformPoint(Vector3.zero);

        
        //render.sharedMaterial.SetVector("_DragPoint", t2.position);
        //newPosition = targetPoint;
	}
	
    void Update()
    {
        if (Vector3.SqrMagnitude(this.starPos - selfTranform.position) > (0.1F * 0.1F)) {
            Vector3 tmp = Vector3.zero;
            this.starPos = Vector3.SmoothDamp(this.starPos, selfTranform.position, ref tmp, 0.3f);
            this.vec = (this.starPos - selfTranform.position);
            var localDir = selfTranform.InverseTransformDirection(this.vec).normalized;
            var length = this.vec.magnitude;
            this.vec = length * localDir * this.factor;
        }
        else
        {
            this.vec = Vector3.zero;
        }

        //var worldDirection = (starPos - selfTranform.position).normalized;
        //this.starPos += Time.deltaTime * worldDirection * 3.0F;
        //var veclength = worldDirection.magnitude * factor;

        render.sharedMaterial.SetVector("_DragDirection", this.vec);

        ////starPos = selfTranform.localPosition;
    }

	void LateUpdate () {

        //Vector3 vec1 = Vector3.zero;
        //starPos = Vector3.SmoothDamp(starPos, selfTranform.position, ref vec1, 0.3f);

        //if (Vector3.SqrMagnitude(this.vec) > (0.1F)) {
        //    this.vec *= -1;
        //}
        //else {
        //    this.vec = Vector3.zero;
        //}


        //UnityEngine.Debug.Log(result);
        //this.vec = (starPos - selfTranform.localPosition);
        //    /// Time.deltaTime;
        
        

        ////targetPoint = t2.TransformPoint(Vector3.zero);
        
        ////newPosition = Vector3.SmoothDamp(newPosition, targetPoint, ref velocity, delayTime);
        
        
	}
}
