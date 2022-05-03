# SolarWinds.Tools.ModelGenerators

Library of "Model" Data Generators. A model data generator generates in-memory data that can then be used to for other data generation processes like populating the Orion Database. The focus is to generate model data that is realistic and generic, not having any reliance on Orion or some other platform.

##  Model Generators
### [Internet Generator]("./api/index.md")
Generates networks of connected devices featuring accurate subnets and connections via device interfaces. Also includes generation of intranet networks in private address spaces. Each network will be connecrted to the next and within a network, multipkl redunant paths are created that mimic real-work Internet including definition of the network Autonomous Systems (AS).
