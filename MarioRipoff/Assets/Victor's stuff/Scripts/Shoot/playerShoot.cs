using UnityEngine;
using System.Collections;

public class playerShoot : MonoBehaviour {

//    This variable should be on projectile prefab
//    public LayerMask toHit;
    public GameObject weapon;
    IShootable shootable;
    modifiedMove playermove;

    void Start () {
        shootable = weapon.GetComponent<IShootable>();
        playermove = gameObject.GetComponent<modifiedMove>();
    }

	// Update is called once per frame
	void Update () {
        if (shootable == null)
            Debug.Log("No weapon");
        else {
            if (Input.GetButton("Fire1") && Input.GetAxis("Vertical") > 0) {
                shootable.Shoot(Vector2.up);
            }
            //Need to check that the player is grounded
            else if(Input.GetButton("Fire1") && Input.GetAxis("Vertical") < 0 && !playermove.grounded) {
                shootable.Shoot(Vector2.down);
            }
            //Still need to implement shooting in direction player is facing
            else if (Input.GetButton("Fire1") && playermove.facingRight) {
                shootable.Shoot(Vector2.right);
            }
            else if (Input.GetButton("Fire1") && !playermove.facingRight) {
                shootable.Shoot(Vector2.left);
            }
        }
	}
}
