# Postman API Doc : 
https://documenter.getpostman.com/view/3449677/TW71mSbT

# install mongo from docker. 
command : 
docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo

-- Either run in docker container --

Docker Run Command : 
docker run -it --rm -p 8080:80 -e MongoDbSettings:Host=mongo --network=dot5catalog rahimin/catalog:v1

Base Url : 
http://localhost:8080/

-- Either run in docker container --


-- OR -- 

- install dotnet-sdk and dotnet-runtime.
- Build & Run.

-- OR --