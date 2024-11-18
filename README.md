# Meteor Rush Game for PCVR - Originally Built in 24 Hours!

## Inspiration
Our inspiration for Meteor Rush came from a Steam arcade game in The Lab, which challenged players to survive an onslaught of incoming projectiles. Additionally, we were inspired by NASA's DART Mission to incorporate asteroids into our game as part of defending Earth. By combining these two influences, we aimed to create an engaging VR experience with arcade-style gameplay.

## What it does
Meteor Rush throws players into a thrilling VR experience where they have to defend Earth from incoming meteors. Using VR controls and strategic reflexes, players must target and destroy asteroids before they reach Earth's atmosphere.

## How we built it
We built Meteor Rush using the Unity editor, leveraging pre-built XR building blocks for rapid development. Asteroid spawning was implemented by randomly generating positions on a spherical boundary using Unity's Random.onUnitSphere, ensuring a minimum distance from the center, and assigning randomized speeds and directions toward Earth. The project was tested on Meta Quest devices.

## Challenges we ran into
One of the challenges we faced was enabling ray tracing to work correctly on our UIs. XR requires a specific event manager for proper functionality. To resolve this, we utilized an XR UI Canvas, which is specifically designed for VR interfaces.

Another issue we encountered was achieving compatibility between the spaceship model and the Oculus Quest controller hardware. When we attempted to replace the controller with our pre-fab spaceship model, it was overwritten by the default Oculus Quest controller model, causing rendering issues and preventing the spaceship from displaying correctly.

## Accomplishments that we're proud of
We are proud to have successfully created our first VR game, overcoming technical challenges such as researching VR development tools, implementing ray tracing, and designing asteroid spawning mechanics. This achievement has been both rewarding and a valuable learning experience.

## What we learned
We gained insight into the difficulties of VR game development. Specifically, we learned how to use Meta's building blocks and the XR Toolkit to create a VR experience. We overcame challenges such as solving how ray tracing works with UI and replacing the VR controller with our spaceship model. Additionally, we gained an understanding of using GitHub with Unity by working around unreadable Unity files. This experience deepened our knowledge of both the technical and creative aspects of VR development.

## What's next for Meteor Rush
We plan to expand Meteor Rush with customizable ship models, new planets to defend, and optimizations to improve performance and reduce load times, enhancing immersion and setting the stage for future growth.
