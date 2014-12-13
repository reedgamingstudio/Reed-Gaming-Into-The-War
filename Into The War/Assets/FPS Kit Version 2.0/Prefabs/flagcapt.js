#pragma strict
function OnTriggerEnter (other : Collider) {
    if(other.gameObject.tag == "Player"){
        GameObject.FindWithTag("Network").SendMessage("CaptureFlagAddPoints", SendMessageOptions.DontRequireReceiver);
    }
}
