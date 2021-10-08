# Product Service

## Swagger Documentation:

https://app.swaggerhub.com/apis-docs/alprsln/product-service-api/v1

---
## Prequisites:
- Your favourite .net 5 env. with the necessary packages
- Docker desktop

---

## Setting up Postgresql database:

1) Download and start docker desktop 

2) Navigate to the `homework-2-alp-arslan-product-service` directory and run docker compose

```bash
docker compose up
```

3) Navigate to `ProductApi` and update the database
- (Migration is included in the repo)
- (Since temp data is handled badly, one has to comment out the AddDummyData method call from `Infrastructure.Context.ProductContext` constructor before creating a new migration or updating the database)

```bash
dotnet ef database update
```

4) You can access the postgresql admin panel by going to `localhost:5050`. Log in and add a new server connection with values:
```yml
email: root@hepsinerede.com
password: toor

host name: postgresql
port: 5432
username: postgres
password: toor
```

5) Or you can inject a cli into the postgres container and access the database by running the command below

```bash
psql -h localhost -U postgres
```

# 3. Hafta Ödev
2. hafta geliştirdiğiniz api için Unit ve integration test yazın

- Bir önceki hafta oluşturduğunuz repoyu klonlayarak yeni bir repo üzerinde çalışın
- Test edilebilecek tüm method ve function larınızın unit testlerini yazın.
- En az 2 tane senaryo oluşturarak integration test yazın.
- Mock kullanın
- yazdığınız testlere göre refactoring ihtiyacı var ise tamamlayın.

#Bonus:
- code coverage toolu kullanın
- minimum code coverage oranınız %60 olsun
- farklı mock ve test frameworkleri kullanın