create table categoria (
  id serial primary key,
  nombre varchar(50) not null unique
);

insert into categoria (nombre) values ('categoría 1');
insert into categoria (nombre) values ('categoría 2');
insert into categoria (nombre) values ('categoría 3');

create table articulo (
  id serial primary key,
  nombre varchar(50) not null unique,
  precio decimal(10,2),
  categoria bigint unsigned,
  foreign key (categoria) references categoria (id)
);

