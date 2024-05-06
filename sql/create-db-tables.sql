CREATE DATABASE IF NOT EXISTS qvisProcesso;
use qvisProcesso;

CREATE TABLE IF NOT EXISTS usuario(
	id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    senha VARCHAR(256) NOT NULL,
    isAtivo BOOLEAN DEFAULT 1
);


CREATE TABLE IF NOT EXISTS produto(
	id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    descricao VARCHAR(500) NOT NULL,
    codigo_produto VARCHAR(10) NOT NULL,
    preco DECIMAL(18,2) NOT NULL,
    id_criador INT,
    isAtivo BOOLEAN DEFAULT 1,
    CONSTRAINT fk_usuario_criador FOREIGN KEY (id_criador) REFERENCES usuario(id)
);



