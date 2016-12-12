create table users
(
	user_id integer identity not null,
	name varchar(32) not null,
	password varchar(100) not null,
	email varchar(32) not null,
	salt varchar(100) not null

	constraint pk_user_id primary key (user_id)
	);

	create table userstournaments
	(
		user_id integer not null,
		tournament_id integer not null,
		owner bit not null,

		constraint fk_tournament_users foreign key (user_id) references users(user_id)
	);