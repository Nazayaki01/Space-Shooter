using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax, zMin, zMax;

}
public class PlayerController : MonoBehaviour {
    public float speed;
    public Boundary boundary;
    public float tilt;
    public GameObject shot;
    public Transform shotspawn;
    private float nextFire;
    public float fireRate;
   



    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotspawn.position, shotspawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        


   Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
		GetComponent <Rigidbody> ().velocity = movement * speed;
        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax),
             Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax),
             0.0f);

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(GetComponent<Rigidbody>().velocity.y * -tilt, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
        

	}
}
