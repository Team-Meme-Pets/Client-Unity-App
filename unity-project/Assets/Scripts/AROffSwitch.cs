using UnityEngine;
using System.Collections;

public class AROffSwitch : MonoBehaviour {
  private bool en = true;
  public Camera cam;
  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {

  }

  public void toggle(){
    en = !en;
    if(en){
      cam.clearFlags = CameraClearFlags.SolidColor;
    }
    else{
      cam.clearFlags = CameraClearFlags.Skybox;
    }
  }
}
