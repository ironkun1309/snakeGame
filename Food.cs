using UnityEngine;

public class Food : MonoBehaviour {
    
    // BoxCollider has a propety of type Bounds which gives us exact size - which we'll use to generate random numbers.
    public BoxCollider2D gridArea; // Doing this will now create a propety of "Grid Area in our Inspector.

    // built-in function that Unity will call automatically is called Start() - will be called on the very start of the game.
    private void Start() {
        RandomizePosition(); // This is how we call a function
    }

    // Function that will randomize our position
    private void RandomizePosition() {
        Bounds bounds = this.gridArea.bounds; // With this, we can now get a random numbers.
        float x = Random.Range(bounds.min.x, bounds.max.x); //Range(between x1,x2)
        float y = Random.Range(bounds.min.y, bounds.max.y); //Range(between y1,y2)

        //Vector3(x, y, z)
        this.transform.position = new Vector3(x, y, 0.0f); // We are not getting our new coordinates and placing it onto our food variable.

        //Everything must align to grid -> round numbers from float to ints
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    // This function will be called automatically whenever our game object collide with one another object - in this case, it's the "Player" tag.
    private void OnTriggerEnter2D(Collider2D other) {
        // What other objects collided with our object? Snake - generally good practice to say that it will be the "other" object
        // Tag is a property to our player object that we can choose in the main unity engine. We chose snake to be our Player.
        if (other.tag == "Player") {
            RandomizePosition();
        }
    }
}
