docker build -t plant-shop-image .

docker tag plant-shop-image registry.heroku.com/plants-plants-plants/web

docker push registry.heroku.com/plants-plants-plants/web

heroku container:release web -a plants-plants-plants