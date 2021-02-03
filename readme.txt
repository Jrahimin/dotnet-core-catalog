# install mongo from docker. 
command : sudo docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo

# Postman API Doc : 
https://documenter.getpostman.com/view/3449677/TW71mSbT


Docker Run Command : 
docker run -it --rm -p 8080:80 -e MongoDbSettings:Host mongo --network=dot5catalog catalog:v1