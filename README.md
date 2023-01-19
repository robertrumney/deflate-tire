# Deflate Tire

A Unity script that allows you to deflate a tire gradually over time.

## Getting Started

To get started, simply add the DeflateTire script to a GameObject in your Unity scene that has a MeshFilter and a WheelCollider component attached. In the Unity editor, you can then set the tire mesh, deflation amount, deflation time, and wheel collider that you want to use.

## Using the Script

To deflate the tire, you can call the Deflate() function on the DeflateTire component. For example, you could add a button in your UI that calls the function when clicked.

## Customizing the Script

You can customize the amount and time of deflation by adjusting the deflationAmount and deflationTime fields in the Unity editor. You can also change the tire mesh and wheel collider that is used by the script.

## Note

This script uses the original vertices of the tire to make sure it won't become completely flat.
