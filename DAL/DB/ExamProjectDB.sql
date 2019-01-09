drop database if exists asp_net_core_exam_project_db;
create database if not exists asp_net_core_exam_project_db char set utf8 collate utf8_general_ci;
use asp_net_core_exam_project_db;

create table if not exists Users (
	user_id mediumint(6) primary key auto_increment,
	user_name varchar(100) unique not null,
	user_pwd varchar(100) not null
);

insert into Users(user_name, user_pwd) values('tungpt260794', '123456');

select * from Users;