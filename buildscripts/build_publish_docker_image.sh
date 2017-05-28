cd $HOME/build/robisrob/gameoflivecsharp/Application
dotnet publish -c Release -o ./docker_workdir/app 
cp ../buildscripts/Dockerfile ./docker_workdir
cd docker_workdir
docker build -t robisrob/gol .
docker login -u="$DOCKER_USERNAME" -p="$DOCKER_PASSWORD"
docker push robisrob/gol


