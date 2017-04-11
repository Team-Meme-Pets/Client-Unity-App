using UnityEngine;
using System.Collections;

public class RotaterPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
          rotate();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

        public void rotate(){
          //the accelerometer inputs do not align to the rotater axis
          float x = System.Math.Abs(Input.acceleration.y);
          float y = System.Math.Abs(Input.acceleration.z);
          float z = System.Math.Abs(Input.acceleration.x);
          if(x > y && x > z){
            Debug.Log("x");
            if(Input.acceleration.x > 0){

            }
            else{

            }
          }
          else if(y > x && y > z){
            Debug.Log("y");
            if(Input.acceleration.z > 0){
            }
            else{
              transform.Rotate(0,0,-90);
            }
          }
          else if(z > y && z > x){
            Debug.Log("z");
            if(Input.acceleration.x > 0){
              transform.Rotate(0,-90,0);
            }
            else{
              transform.Rotate(0,90,0);
            }
          }
          else{
            Debug.Log("fuck");
          }
        }
}
