using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class CharacterMovement: MonoBehaviour {
	public float speed = 6.0F;
  public float jumpSpeed = 8.0F;
  public float gravity = 20.0F;
	public float mouseXSensitivity = 32.0F;
	public int maxHealth = 100;

  private Vector3 moveDirection = Vector3.zero;
	private bool isGrounded = false;
	int playerHealth;

	void Awake() {
		Screen.lockCursor = true;
		Screen.showCursor = false;
		playerHealth = maxHealth;
	}

  void Update() {

		if(playerHealth <= 0){
			GlobalValues.isPlayerDead = true;
		}

    CharacterController controller = GetComponent<CharacterController>();
    if (controller.isGrounded && isGrounded) {
      moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
      moveDirection = transform.TransformDirection(moveDirection);
      moveDirection *= speed;
      if (Input.GetButtonDown("Jump"))
        moveDirection.y = jumpSpeed;
    } else {
			moveDirection.x = Input.GetAxis("Horizontal") * speed;
			moveDirection.z = Input.GetAxis("Vertical") * speed;
			moveDirection = transform.TransformDirection(moveDirection);
		}
    moveDirection.y -= gravity * Time.deltaTime;
    controller.Move(moveDirection * Time.deltaTime);

		transform.Rotate(0, Time.deltaTime * Input.GetAxis("Mouse X") * mouseXSensitivity, 0, Space.World);

		if (Input.GetKeyDown("escape")){
			Screen.lockCursor = !Screen.lockCursor;
			Screen.showCursor = !Screen.showCursor;
		}
  }

	void OnControllerColliderHit(ControllerColliderHit hit) {

		if(hit.normal == new Vector3(0.0F, 1.0F, 0.0F))
		{
			isGrounded = true;
		} else {
			isGrounded = false;
		}
	}

	public void Damage(int _damage){
		playerHealth -= _damage;
	}

}
