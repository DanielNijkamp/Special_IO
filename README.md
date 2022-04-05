# Special Input & Output

Special IO is a project where I try to create a game like [Calm down Stalin](https://store.steampowered.com/app/502940/Calm_Down_Stalin/) but use a [Leap Motion controller](https://www.ultraleap.com/product/leap-motion-controller/) as a input device instead of VR or keyboard controls.

## Scope

I want the game to be somewhere between a demo to a game and a [Leap Motion demo](https://developer.leapmotion.com/tracking-software-download). you are positioned in a room with objects and you can experiment and play around with the objects around you with your hands. the demo will also have some gameplay elements to keep the experience fun and fresh, like being able to punch a punching bag or smash your keyboard or computer in game.


## Requirements

The game will be made using the Unity game engine and a Leap motion controller, to implement the tracking of the controller. I will also be using a Unity plugin so the movements of the tracker can be used inside of Unity.


## Obstacles/Problems

The hardest part of the project will be properly implementing the hand tracking into Unity and make sure everything works smoothly and without problems. from the scope and ideas that I have the first working product should be done about 2-3 weeks. and after that i will work to improve the gameplay aspects and if any problems should arise fix them.

some problems that arose during development were:
Working with the Internal Leapmotion API to get finger positions
Raycasting through a render texture
Unity collisions
make sure that the lazergame UI button works properly when pressed multiple times

### Screenshots

<h1 align="center">

![Raycast](https://github.com/DanielNijkamp/Special_IO/blob/master/Special_IO/Screenshots/Raycast.jpg)

</h1>

<h1 align="center">

![Phone](https://github.com/DanielNijkamp/Special_IO/blob/master/Special_IO/Screenshots/PhoneGizmos.PNG)

</h1>

## Gifs
<h1 align="center">

![Interaction](https://github.com/DanielNijkamp/Special_IO/blob/master/Special_IO/Gifs/Interaction.gif)

</h1>

<h2 align="center">

![UI](https://github.com/DanielNijkamp/Special_IO/blob/master/Special_IO/Gifs/UI.gif)

</h2>

<h1 align="center">

![lazergame](https://github.com/DanielNijkamp/Special_IO/blob/master/Special_IO/Gifs/lazergame.gif)

</h1>

<h1 align="center">

![Phone](https://github.com/DanielNijkamp/Special_IO/blob/master/Special_IO/Gifs/phone.gif)

</h1>

## Sources


[Leap motion in-depth testing](https://youtu.be/ZK5FRPwIWVE)

[Leap motion Unity Plugin](https://developer.leapmotion.com/unity)

[Leap motion tracking API](https://docs.ultraleap.com/tracking-api/)

[Trello Board](https://trello.com/b/FPIkMKX7/specialio)

[Leap motion in Unity reddit thread](https://www.reddit.com/r/leapmotion/comments/4dx68o/almost_seamlessly_picking_up_objects/)

## Addendum:
Although the idea of the game and using the leap motion controller as a input device is definitive, the contents of this readme and other documentation about the Special IO project are **not definitive**. meaning that some parts are bound to change in the course of development.
