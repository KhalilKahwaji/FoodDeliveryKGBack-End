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
    address     varchar(512) NOT NULL,
    categoryid  serial          NOT NULL,
    FOREIGN KEY (categoryid) REFERENCES restaurantCategory(categoryid)
)

CREATE TABLE Item
(
    itemid      SERIAL       NOT NULL PRIMARY KEY,
    name         varchar(255),
    price       int     not null,
    image           varchar(512)  ,
    restaurantid SERIAL not null,
    categoryid   SERIAL not null,
    FOREIGN KEY (restaurantid) REFERENCES Restaurant(restaurantid),
    foreign key (categoryid)REFERENCES foodcategory(categoryid)
)


CREATE TABLE FoodCategory
(
    categoryid      SERIAL       NOT NULL PRIMARY KEY,
    categoryName    varchar(255) NOT NULL
)



CREATE TABLE RestaurantCategory
(
    categoryid      SERIAL       NOT NULL PRIMARY KEY,
    categoryName    varchar(255) NOT NULL
)

CREATE TABLE OrderStatus
(
    statusid      SERIAL       NOT NULL PRIMARY KEY,
    statusName    varchar(255) NOT NULL
)



CREATE TABLE Order
(
    orderid      SERIAL       NOT NULL PRIMARY KEY,
    statusid    SERIAL not null,
    userid      SERIAL not null,
    restaurantid    serial not null,
    dateOfOrder     date  not null,
    FOREIGN KEY (restaurantid) REFERENCES Restaurant(restaurantid),
    FOREIGN KEY (userid) REFERENCES user(userid),
    FOREIGN KEY (statusid) REFERENCES orderstatus(statusid)

)


CREATE TABLE OrderDetail
(
    orderdetailid serial not null primary key,
    orderid      SERIAL       NOT NULL ,
    itemid      serial  not null,
    quantity    int     not null ,
    price       int not null,
    FOREIGN KEY (orderid) REFERENCES "order"(orderid),
    FOREIGN KEY (itemid) REFERENCES item(itemid)


)
