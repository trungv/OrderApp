# Order App

Order App is a SPA. It was builded following Microservice Artchitect and deployed in Docker Container. 

### Tech
Order App uses some technology:

* [VueJS], [.Net Core 2.2, 3.0], [gRPC], [RabitMQ], [IdentityServer4]

### Deployment
Open Powershell at deployment folder 
First step:
```sh
$ docker-compose build
```

Second step:
```sh
$ docker-compose up
```

### Host infomation

| Plugin | README |
| ------ | ------ |
| RabitMQ | http://localhost:15672/ |
|  | User: guest|
|  | Password: guest |
| PgAdmin4 for Postgres | http://localhost:8001/ |
|  | Password: admin@admin.com |
|  | Password: P@ssw0rd |
| Orderapp-api | http://localhost:2001/ |
| Orderapp-api Swagger | http://localhost:2001/swagger |
| Orderapp-email-grpc | Use gRPC Client call to localhost:2111 |

**References**
   [VueJS]: <https://vuejs.org>
   [.Net Core 2.2, 3.0]: <https://docs.microsoft.com/en-us/dotnet/core/>
   [gRPC]: <https://grpc.io>
   [RabitMQ]: <https://www.rabbitmq.com/>
   [IdentityServer4]: <http://docs.identityserver.io/en/latest/>
