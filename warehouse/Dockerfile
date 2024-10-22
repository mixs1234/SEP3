# Build stage
#
FROM maven:3.6.0-jdk-11-slim AS build
COPY warehouse/src /home/app/src
COPY warehouse/pom.xml /home/app
RUN mvn -f /home/app/pom.xml clean package

#
# Package stage
#
FROM openjdk:11-jre-slim
COPY --from=build /home/app/target/warehouse-1.0-SNAPSHOT.jar /usr/local/lib/warehouse.jar
EXPOSE 8080
ENTRYPOINT ["java","-jar","/usr/local/lib/warehouse.jar"]
