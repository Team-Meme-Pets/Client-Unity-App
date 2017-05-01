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
    if(parseResponseCode(www.responseHeaders["STATUS"]) == 500){
      Debug.LogError("500 booo");

    }
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

  //yanked this from stack overflow
  private static int parseResponseCode(string statusLine) {
    int ret = 0;

    string[] components = statusLine.Split(' ');
    if (components.Length < 3) {
      Debug.LogError("invalid response status: " + statusLine);
    }
    else {
      if (!int.TryParse(components[1], out ret)) {
        Debug.LogError("invalid response code: " + components[1]);
      }
    }

    return ret;
  }
}
