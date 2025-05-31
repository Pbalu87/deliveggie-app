
Write-Host "Pulling latest RabbitMQ image..."
docker pull rabbitmq:management


Write-Host "Starting RabbitMQ container..."
docker run -d `
  --name rabbitmq `
  -p 5672:5672 `
  -p 15672:15672 `
  rabbitmq:management


Write-Host "Pulling latest MongoDB image..."
docker pull mongo


Write-Host "Starting MongoDB container..."
docker run -d `
  --name mongodb `
  -p 27017:27017 `
  mongo

Write-Host "RabbitMQ Management UI → http://localhost:15672"
Write-Host "Default username: guest, password: guest"
Write-Host "MongoDB running on → mongodb://localhost:27017"
