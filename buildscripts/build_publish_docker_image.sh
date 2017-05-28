cd $HOME
dotnet publish -c Release -o ./docker_workdir/app ./Application.csproj
cp buildscripts/Dockerfile Application/docker_workdir
cd Application/docker_workdir
docker build -t robisrob/gol .
docker login -u="$DOCKER_USERNAME" -p="$DOCKER_PASSWORD"
docker push robisrob/gol


