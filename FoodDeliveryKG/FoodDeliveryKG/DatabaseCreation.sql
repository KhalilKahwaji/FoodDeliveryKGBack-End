CREATE TABLE User(
                     userid SERIAL NOT NULL PRIMARY KEY ,
                     fname varchar(255),
                     lname varchar(255),
                     username varchar(255) NOT NULL UNIQUE,
                     dateCreated DATE NOT NULL,
                     password varchar(255) NOT NULL,
                     phoneNumber int NOT NULL UNIQUE,
                     address varchar(512) NOT NULL

)


CREATE TABLE Restaurant
(
    restaurantid      SERIAL       NOT NULL PRIMARY KEY,
    name         varchar(255),
    username    varchar(255) NOT NULL UNIQUE,
    dateCreated DATE         NOT NULL,
    password    varchar(255) NOT NULL,
    phoneNumber int          NOT NULL UNIQUE,
    address     varchar(512) NOT NULL
)