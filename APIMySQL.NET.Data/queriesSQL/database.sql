 Create database apiMysql 
use apiMysql;

CREATE TABLE categories(
id INT NOT NULL PRIMARY KEY auto_increment,
name varchar(30) not null,
description text null
);
CREATE TABLE services (
id int not null,
service_name  varchar(40) not null,
service_description varchar(40) null,
price double,
categoryId int not null,
primary key auto_increment (id),
foreign key (categoryId) references categories(id)
);

