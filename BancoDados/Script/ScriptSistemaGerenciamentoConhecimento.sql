CREATE DATABASE db_SistemaGerenciamentoConhecimento
GO 
USE db_SistemaGerenciamentoConhecimento
GO 

CREATE TABLE Cargo(
    Id SMALLINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE Departamento(
    Id SMALLINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE TipoPermissao(
    Id TINYINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE StatusUsuario(
    Id TINYINT NOT NULL IDENTITY PRIMARY KEY,
    Status VARCHAR(50) NOT NULL
);

CREATE TABLE Usuario(
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    IdCargo SMALLINT NOT NULL,
    IdDepartamento SMALLINT NOT NULL,
    IdTipoPermissao TINYINT NOT NULL,
    IdStatusUsuario TINYINT NOT NULL,
    Nome VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Senha VARCHAR(60) NOT NULL,
    DataCriacao DATE NOT NULL,
    DataAtualizacao DATE NOT NULL,

    FOREIGN KEY (IdCargo) REFERENCES Cargo(Id),
    FOREIGN KEY (IdDepartamento) REFERENCES Departamento(Id),
    FOREIGN KEY (IdTipoPermissao) REFERENCES TipoPermissao(Id),
    FOREIGN KEY (IdStatusUsuario) REFERENCES StatusUsuario(Id)
);

CREATE TABLE TipoConteudo(
    Id TINYINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE Categoria(
    Id SMALLINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL,
    Descricao VARCHAR(100)
);

CREATE TABLE Conteudo(
    IdConteudo INT NOT NULL IDENTITY PRIMARY KEY,
    IdTipoConteudo TINYINT NOT NULL,
    IdCategoria SMALLINT NOT NULL,
    Conteudo TEXT NOT NULL,
    Descricao VARCHAR(255),
    DataCriacao DATE NOT NULL,
    DataAtualizacao DATE NOT NULL,
    FOREIGN KEY (IdTipoConteudo) REFERENCES TipoConteudo(Id),
    FOREIGN KEY (IdCategoria) REFERENCES Categoria(Id)
);

CREATE TABLE Tag(
    Id SMALLINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE ConteudoTag(
    IdConteudo INT NOT NULL,
    IdTag SMALLINT NOT NULL,
    PRIMARY KEY (IdConteudo, IdTag),
    FOREIGN KEY (IdConteudo) REFERENCES Conteudo(IdConteudo),
    FOREIGN KEY (IdTag) REFERENCES Tag(Id)
);

CREATE TABLE HistoricoVersao(
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    IdConteudo INT NOT NULL,
    IdUsuario INT NOT NULL,
    DescricaoVersao VARCHAR(255),
    DataVersao DATETIME NOT NULL,
    FOREIGN KEY (IdConteudo) REFERENCES Conteudo(IdConteudo),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
);

CREATE TABLE Comentario(
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    IdConteudo INT NOT NULL,
    IdUsuario INT NOT NULL,
    Mensagem VARCHAR(100) NOT NULL,
    FOREIGN KEY (IdConteudo) REFERENCES Conteudo(IdConteudo),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
);

CREATE TABLE TipoAnexo(
    Id TINYINT NOT NULL IDENTITY PRIMARY KEY,
    NomeTipoAnexo VARCHAR(50) NOT NULL
);

CREATE TABLE Anexo(
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    IdTipoAnexo TINYINT NOT NULL,
    Nome VARCHAR(50) NOT NULL,
    CaminhoArquivo VARCHAR(300) NOT NULL,
    FOREIGN KEY (IdTipoAnexo) REFERENCES TipoAnexo(Id)
);

CREATE TABLE ConteudoAnexo(
    IdConteudo INT NOT NULL,
    IdAnexo INT NOT NULL,
    PRIMARY KEY (IdConteudo, IdAnexo),
    FOREIGN KEY (IdConteudo) REFERENCES Conteudo(IdConteudo),
    FOREIGN KEY (IdAnexo) REFERENCES Anexo(Id)
);

CREATE TABLE TipoAvaliacao(
    Id TINYINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE Avaliacao(
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    IdTipoAvaliacao TINYINT NOT NULL,
    NotaFinal DECIMAL NOT NULL,
    DataAvaliacao DATE NOT NULL,
    DataAtualizacao DATE NOT NULL,
    FOREIGN KEY (IdTipoAvaliacao) REFERENCES TipoAvaliacao(Id)
);

CREATE TABLE ConteudoAvaliacao(
    IdConteudo INT NOT NULL,
    IdAvaliacao INT NOT NULL,
    PRIMARY KEY (IdConteudo, IdAvaliacao),
    FOREIGN KEY (IdConteudo) REFERENCES Conteudo(IdConteudo),
    FOREIGN KEY (IdAvaliacao) REFERENCES Avaliacao(Id)
);

CREATE TABLE AnexoAvaliacao(
    IdAnexo INT NOT NULL,
    IdAvaliacao INT NOT NULL,
    PRIMARY KEY (IdAnexo, IdAvaliacao),
    FOREIGN KEY (IdAnexo) REFERENCES Anexo(Id),
    FOREIGN KEY (IdAvaliacao) REFERENCES Avaliacao(Id)
);

CREATE TABLE UsuarioAvaliacao(
    IdUsuario INT NOT NULL,
    IdAvaliacao INT NOT NULL,
    PRIMARY KEY (IdUsuario, IdAvaliacao),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id),
    FOREIGN KEY (IdAvaliacao) REFERENCES Avaliacao(Id)
);
