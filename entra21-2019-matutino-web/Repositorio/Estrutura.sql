CREATE TABLE escola (
id INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(50),
);

CREATE TABLE alunos(
id INT PRIMARY KEY IDENTITY(1,1),
nome_alunos VARCHAR(50),
cpf VARCHAR (14),
nota DECIMAL (4,2)
);

INSERT INTO escola (nome)
VALUES ('Higert');



