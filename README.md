# Deflate Tire Script

This script uses mesh deformation and coroutines to gradually deflate a tire in Unity over time with adjustable deflation amount and time, assigns the tire mesh at runtime and calls the deflate function automatically.

## Usage
1. When a tire is shot, add the script to the tire object using the "Add Component" option in Unity
2. The tire mesh will be automatically assigned at runtime
3. The tire will start deflating automatically once the script is added
4. The deflation amount and time can be set as readonly variables

## Notes
- Make sure the object you are attaching the script to has a MeshFilter component
- If you want to stop the deflate process you can add a stop function and call it when you want to stop the deflation process
- You should also consider deactivating the wheel collider on the deflated tire and activate another collider like a capsule collider that represents a deflated tire shape, this will make the vehicle physics act accordingly when the tire is deflated.
