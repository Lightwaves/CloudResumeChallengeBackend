CREATE TABLE visitors (
id serial primary key,
visit_time timestamp with time zone,
ip inet,
user_agent varchar(500),
width smallint,
height smallint
)