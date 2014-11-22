public var rotateSpeed : float;

public function Update() : void {
	transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
}