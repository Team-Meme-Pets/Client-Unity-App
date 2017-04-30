using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIFunctions : MonoBehaviour {
  public InputField loginName;
  public InputField loginPass;

  public InputField signupName;
  public InputField signupEmail;
  public InputField signupPass;

  private string hostname = "http://bc1691.code.engineering.nyu.edu:9800/";

  void Start () {}
  void Update () {}

  public void login(){
    WWWForm postData = new WWWForm();
    postData.AddField("username",loginName.text);
    postData.AddField("password",loginPass.text);
    
    WWW www = new WWW(hostname+"loginAuth", postData);

    while(!www.isDone){
    }

    print(System.Text.Encoding.UTF8.GetString(www.bytes));

    //if it worked alert the user
    //if it failed alert the user

  }

  public void createAcct(){
    WWWForm postData = new WWWForm();
    postData.AddField("username",signupName.text);
    postData.AddField("password",signupPass.text);
    postData.AddField("email",signupEmail.text);
    
    WWW www = new WWW(hostname+"registerAuth", postData);

    while(!www.isDone){
    }

    print(System.Text.Encoding.UTF8.GetString(www.bytes));

  }
}
