using System.Collections.Generic; // Used to define or create a Generic List.
using UnityEngine;

public class Snake : MonoBehaviour {
    private Vector2 direction = Vector2.right; // 2 floating point values for x and y axis for 2D objects movements
    private List<Transform> segments = new List<Transform>(); // I've learned in CS1331 that this is a List that takes in type Transform
                                                              // Since we changed the way we will start our game, we must initialize first.
    public Transform segmentPrefab; // usually our type will be GameObject, however, since we have the Generic Transform, we will use that for consistency.
                                    // This variable will create a new property called Segment Prefab in Unity for Snake.
    public int initialSize = 4; // Our initialze Size of our snake when the game begins

    private void Start() {
        ResetState();
        //segments = new List<Transform>(); // Must first initialize in order to use a Generic
        //segments.Add(this.transform); // This is adding the first segment of the snake, which is the head of the snake.
    }

    private void Update() { // A Function (set of instructions that perform a task.) call automatically every frame object is active.
        if (Input.GetKeyDown(KeyCode.W)) { // // Syntax of if the W key is pressed down
            direction = Vector2.up; // direction will go up
        } else if (Input.GetKeyDown(KeyCode.S)) {
            direction = Vector2.down;
        } else if (Input.GetKeyDown(KeyCode.A)) {
            direction = Vector2.left;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            direction = Vector2.right;
        }
    }
    // Note that the function above will just take our input. We still have to write a function for the snake to move.

    /**
     * Update() is called every frame, but framerates are very varied (based on your PC Specs)
     * FixedUpdated() always ran at a fixed interval - important for physic related code
    */
    private void FixedUpdate() {
        // This for loop will start from the back of our snake and work forwards - changing our position in reverse order
        // Essentially this is making sure the new object added will be following the one in front of it.
        for (int i = segments.Count - 1; i > 0; i--) { // Example: 4 items in a list, i = 3 because we are indexing ; 3 > 0 ; i--
            segments[i].position = segments[i - 1].position; // 4th position = 3rd position -> This is what it means to folow the one in front.
        }

        // The head will be updated last.
        this.transform.position = new Vector3(//this.transfer is referencing the Transform object on the Unity screen. Will always be new Vector3 as a syntax rule
            Mathf.Round(this.transform.position.x) + direction.x, // this will transform our x position by direction x.
            Mathf.Round(this.transform.position.y) + direction.y, // this will transform our y position by direction y.
            //Mathf.Round will make sure our numbers are ints because snake is a grid based game
            0.0f // This is our z axis
        );
    }

    public void Grow() {
        Transform newSegment = Instantiate(this.segmentPrefab); // This is how we create an instance of Generic Transform of our Prefab.
        newSegment.position = segments[segments.Count - 1].position; // This is how we get the end of the list
        segments.Add(newSegment); // This is how we add our prefab object to the end of the list
    }

    private void ResetState() {
        for (int i = 1; i < segments.Count; i++) { // Start at index 1 because index 0 is our main snake head
            Destroy(segments[i].gameObject); // Destroy is a built in Function.
        }

        segments.Clear(); // This is how we clear the list - technically still a reference to them after we destroy which is why we need this code
        segments.Add(this.transform); // Add back the main head object.

        for (int i = 1; i < this.initialSize; i++) {
            segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector3.zero; // Reset out position
    }

    // This is how we detect objects
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Food") { // We must manually create a Food tag in unity for this to work.
            Grow(); // Call another method after the if statement has been fulfilled.
        } else if (other.tag == "Obstacle") {
            ResetState();
        }
    }
}
