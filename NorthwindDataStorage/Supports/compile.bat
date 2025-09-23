docker build -t mssql-northwind-db:1.3 .
@REM docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password123" -p 1433:1433 --name sql1 -d mssql-northwind-db

docker run -d --name mssql-northwind-container -p 1466:1433 mssql-northwind-db:1.3

TIMEOUT /T 15

docker exec -it mssql-northwind-container bash -c "/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Password123 -i /usr/src/app/setup.sql;"

docker commit mssql-northwind-container mssql-northwind-db:1.4

docker stop mssql-northwind-container 

docker rm mssql-northwind-container