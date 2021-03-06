# AnneCHPostma - Random Walker

Unity Doodle: follow the random walker.<br/>
<br/>
This is a Unity coding exercise, where the camera tries to follow a walker when it randomly chooses where to go in a 3D environment. When the frame rate drops below 30 frames per second, the oldest cubes are being removed and the number of cubes stay the same from that moment on.<br/>
<br/>
Use the ESCape key to quit<br/>
Use the ~ key to toggle the information on and off<br/>
<br/>
![Random Walker](./Content/RandomWalker.png)
<br/>
<br/>
## Wishlist (when I find some free time)

* Optimize the camera tracking bu using a technique like Lerp to smooth the transitions more
* Zoom out smoothly, when the walker comes nearer to the camera
* Add options for the user, to control the walker:
    * Change the color
    * Change the speed
    * Change the distance range from the camera to the walker
    * Change the transparency