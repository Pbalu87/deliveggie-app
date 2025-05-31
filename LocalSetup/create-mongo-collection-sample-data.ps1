
$containerName = "mongodb"

$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$seedScript = Join-Path $scriptDir "mongo-seed.js"


if (!(Test-Path $seedScript)) {
    Write-Error "Seed script not found: $seedScript"
    exit 1
}

docker start $containerName | Out-Null
docker cp $seedScript "${containerName}:/tmp/mongo-seed.js"
docker exec $containerName mongosh /tmp/mongo-seed.js


Write-Host "`Verifying inserted Products:"
docker exec $containerName mongosh --eval "db.getSiblingDB('admin').Products.find().pretty()"

Write-Host "MongoDB seeding completed successfully."
