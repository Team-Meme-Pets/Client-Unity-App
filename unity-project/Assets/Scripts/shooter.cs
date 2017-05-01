using UnityEngine;
using System.Collections;

public class shooter : MonoBehaviour {
  public GameObject bulletPrefab;
  public Transform bulletSpawn;
  public int force;

  // Use this for initialization
  void Start () {
  }

  void Fire()
  {
    // Create the Bullet from the Bullet Prefab
    var bullet = (GameObject)Instantiate(
        bulletPrefab,
        bulletSpawn.position,
        bulletSpawn.rotation);

    bullet.transform.Rotate(-90,180,0);

    // Add velocity to the bullet
    bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.transform.forward * force;

    // Destroy the bullet after 2 seconds
    Destroy(bullet, 2.0f);        
  }

  // Update is called once per frame
  void Update () {
    var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
    var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

    transform.Rotate(0, x, 0);
    transform.Translate(0, 0, z);

    if (Input.GetKeyDown(KeyCode.Space)){
      Fire();
    }


    if (Input.GetMouseButtonDown(0)){
      Fire();
    }
  }

  void OnMouseDown(){
    Fire();
  }

}
