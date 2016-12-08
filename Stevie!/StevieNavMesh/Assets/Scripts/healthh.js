#pragma strict

var health = 100;

 function Update () {
         if(health <= 0){
             health = 0;
             //killPlayer();
             }
}

 function OnTriggerStay (other : Collider){

 var currentHealth = 100;
 var health = currentHealth - Time.deltaTime;


     if (other.gameObject.CompareTag("Enemy"))
         {
         health -= 2;
         print("Hello World!");
         }
     if (other.gameObject.CompareTag("White Orb"))
         {
         health += 1;
         }

}