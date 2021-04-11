docker run --name rediscache -p 5090:6379 -d redis

docker start rediscache

docker exec -it rediscache redis-cli