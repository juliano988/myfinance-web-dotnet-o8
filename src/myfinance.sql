create database myfinance;

use myfinance;

create table planoconta(
	id int identity(1,1) not null,
	nome varchar(50) not null,
	tipo char(1) not null,
	primary key (id)
);

create table transacao(
	id int identity(1,1) not null,
	historico varchar(100) null,
	data datetime null,
	valor decimal(9,2),
	planocontaid int not null,
	primary key (id),
	foreign key (planocontaid) references planoconta(id)
);

insert into planoconta(nome,tipo) values('Combust�vel','D');
insert into planoconta(nome,tipo) values('Alimenta��o','D');
insert into planoconta(nome,tipo) values('Sa�de','D');
insert into planoconta(nome,tipo) values('Manuten��o do Carro','D');
insert into planoconta(nome,tipo) values('Viagens','D');
insert into planoconta(nome,tipo) values('Sal�rio','R');
insert into planoconta(nome,tipo) values('Juros Recebidos','R');
insert into planoconta(nome,tipo) values('Cr�dito de Dividendos','R');
insert into planoconta(nome,tipo) values('Restitui��o de IR','R');

select * from planoconta;

set dateformat dmy;

insert into transacao(historico,data,valor,planocontaid) values('Combust�vel Blazer',getdate(),489,1);
insert into transacao(historico,data,valor,planocontaid) values('Almo�o de domingo','18-05-2025 12:00',150,2);
insert into transacao(historico,data,valor,planocontaid) values('Pe�as da Blazer','10-05-2025 12:00',1800,4);
insert into transacao(historico,data,valor,planocontaid) values('Sal�rio','12-05-2025 10:00',10000,6);
insert into transacao(historico,data,valor,planocontaid) values('ITAUSA','14-05-2025 10:00',678,8);

select * from transacao;