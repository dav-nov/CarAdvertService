# CarAdvertService
# About
RESTful web-service for car advertising

# Specification
- WebApi based project 
- includes simple GUI for testing
- service accepts and returns data in JSON format
- service is able to handle CORS requests from any domain

# Data storage
Current service run without any database, however it can be simple extended. For now all data is cached.
Initially some basic data is created - list of data can be easily edited using service requests or through 
the GUI.

# Test
Project includes simple unit tests for testing GET, POST, PUT and DELETE requests.

# Functionality
- functionality to return list of all car adverts (i.e. http://localhost:xxxx/api/caradvert)
- optional sorting by any field specified by query parameter, default sorting - by **id** (i.e. http://localhost:xxxx/api/caradvert?sortby=mileage)
- have functionality to return data for single car advert by id (i.e. http://localhost:xxxx/api/caradvert?Id=20)
- have functionality to add car advert
- have functionality to modify car advert by id
- have functionality to delete car advert by id
- have validation functionality
- accept and return data in JSON format.
