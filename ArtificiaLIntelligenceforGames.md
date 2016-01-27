Kinematic Movement algorithms

Kinematic movement algorithms use static datea (position and orientation, no velocitis) and output a desired velocity.  The output is often simply an on or off and  a target direction, moving at full speed or being stationary.  Kinematic algorithms do not use acceleration, although the abrupt changes in velocity might be smoothed over several frames.

Many games simplify things even further and force the orientation of a character to be in the direction it is travelling. If the character is stationary, it faces either a preset direction or the last direction it was moving in.  If its movement algorithm returns a target velocity, then that is used to set its orientation.

This can be done simply with the function.



def getNewOrientation(currentOrientation, velocity):


  1. Make sure we have a velocity
> > if velocity.length() > 0:

  1. Calculate orientation using an arc tangent of
  1. the velocity components.

> return atan2(-static.x, static.z)

  1. Otherwise use the current orientation
> else: return currentOrientation



Seek behaviour

A kinematic seek behaviour takes as input the character's and their target's static data.  It calculates the direction from the character to the target and requests a velocity along this line.  The orientation values are typically ignored, altough we can use the getNewOrientation function above to face in the direction we are moving.

The algorithm can be implemented in a few lines:



class KinematicSeek:

#Holds the static data for the character and target
> character
> target

#Holds the maximum speed the character the character can travel
maxSpeed

def getSteering():

  1. reate the structure for output
> steering = new KinematicSteeringOutput()

  1. Get the direction to the target
> steering.velocity =
> target.position - character.position

  1. The velocity is along this direction, at full speed
> steering.velocity.normalize()
> steering.velocity x= maxSpeed

  1. ace in the direction we want to move
> character.orientation =
> > getNewOrientation(character.orientation,
> > > steering.velocity)

  1. Output the steering

> steering.rotation = 0

> return steering



where the normalize method applies to a vector and makes sure it has a length of one. If the vector is a zero vector, then it is left unchanged.



Flee

If we want the character to run away from their target, we can simply reverse the second line of the getSteering method to give.



# Get the direction away from the target
steering.velocity = character.position - target.position



The character will then move at maximum velocity in the opposite direction.



Arriving

Full algorithm for Arriving



# Holds the kinematic data for the character and target
character
target

#Holds the max acceleration and speed of the character
MaxAcceleration
MaxSpeed

#Holds the radius for arriving at the target
targetRadius

#Holds the radius for beginning to slow down
slowRadius

#Holds the time over which to achieve target speed
timeToTarget = 0.1

def getSteering(target):

  1. reate the structure to hold our output
> steering = new SteeringOutput()

  1. et the direction to the target
> direction = target.position - character.position
> distance = direction.length()

  1. heck if we are there, return no steering
> if distance < targetRadius
> > return None

  1. f we are outside the slowRadius, then go max speed

> if distance > slowRadius:
> targetSpeed = maxSpeed

  1. otherwise calculate a scaled speed
> else:
> > targetSpeed = maxSpeed (times) distance divided by slowRadius

  1. The target velocity combines speed and direction

> targetVelocity = direction
> targetVelocity.normalize()
> targetVelocity x= targetSpeed

  1. Acceleration tries to get to the target velocity
> steering.linear =
> targetVelocity - character.velocity
> steering.linear /= timeToTarget

  1. Check if the acceleration is too fast
> if steering.linear.length() > maxAcceeleration:
> steering.linear.normalize()
> steering.linear x= maxAcceleration

  1. Output the steering
> steering.angular = 0
> return steering

