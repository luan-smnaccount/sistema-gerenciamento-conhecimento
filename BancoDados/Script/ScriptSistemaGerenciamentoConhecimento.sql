CREATE DATABASE db_SistemaGerenciamentoConhecimento
GO 
USE db_SistemaGerenciamentoConhecimento
GO 

CREATE TABLE UsuarioStatus (
    IdUsuarioStatus TINYINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE Perfil (
    IdPerfil SMALLINT NOT NULL IDENTITY PRIMARY KEY,
    Perfil VARCHAR(50) NOT NULL,
    UsuarioCadastro INT NOT NULL,
    DataHoraCadastro DATETIME NOT NULL,
    UsuarioAtualizacao INT NOT NULL,
    DataHoraAtualizacao DATETIME NOT NULL
);

CREATE TABLE Cargo (
    IdCargo SMALLINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL,
    UsuarioCadastro INT NOT NULL,
    DataHoraCadastro DATETIME NOT NULL,
    UsuarioAtualizacao INT NOT NULL,
    DataHoraAtualizacao DATETIME NOT NULL
);

CREATE TABLE Departamento (
    IdDepartamento SMALLINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL,
    UsuarioCadastro INT NOT NULL,
    DataHoraCadastro DATETIME NOT NULL,
    UsuarioAtualizacao INT NOT NULL,
    DataHoraAtualizacao DATETIME NOT NULL
);

CREATE TABLE Usuario (
    IdUsuario INT NOT NULL IDENTITY PRIMARY KEY,
    IdUsuarioStatus TINYINT NOT NULL,
    IdPerfil SMALLINT NOT NULL,
    IdCargo SMALLINT NOT NULL,
    IdDepartamento SMALLINT NOT NULL,
    NomeCompleto VARCHAR(120) NOT NULL,
    Email VARCHAR(320) NOT NULL,
    Senha VARCHAR(60) NOT NULL,
    CPF VARCHAR(11) NOT NULL,
    CEP CHAR(8) NOT NULL,
    Rua VARCHAR(50) NOT NULL,
    Cidade VARCHAR(50) NOT NULL,
    Estado CHAR(2) NOT NULL,
    NumResidencia VARCHAR(5) NOT NULL,
    Telefone SMALLINT NOT NULL,
    UsuarioCadastro INT NOT NULL,
    DataHoraCadastro DATETIME NOT NULL,
    UsuarioAtualizacao INT NOT NULL,
    DataHoraAtualizacao DATETIME NOT NULL,
    UsuarioAdmissao INT NOT NULL,
    DataAdmissao DATETIME NOT NULL,
    FOREIGN KEY (IdUsuarioStatus) REFERENCES UsuarioStatus(IdUsuarioStatus),
    FOREIGN KEY (IdPerfil) REFERENCES Perfil(IdPerfil),
    FOREIGN KEY (IdCargo) REFERENCES Cargo(IdCargo),
    FOREIGN KEY (IdDepartamento) REFERENCES Departamento(IdDepartamento)
);

CREATE TABLE HistoricoVersao (
    IdHistoricoVersao INT NOT NULL IDENTITY PRIMARY KEY,
    IdUsuario INT NOT NULL,
    DescricaoVersao VARCHAR(255) NULL,
    UsuarioCadastro INT NOT NULL,
    DataHoraCadastro DATETIME NOT NULL,
    UsuarioAtualizacao INT NOT NULL,
    DataHoraAtualizacao DATETIME NOT NULL,
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

CREATE TABLE TipoConteudo (
    IdTipoConteudo TINYINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE Categoria (
    IdCategoria SMALLINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL,
    Descricao VARCHAR(120) NULL
);

CREATE TABLE Tag (
    IdTag SMALLINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL,
    UsuarioCadastro INT NOT NULL,
    DataHoraCadastro DATETIME NOT NULL,
    UsuarioAtualizacao INT NOT NULL,
    DataHoraAtualizacao DATETIME NOT NULL
);

CREATE TABLE Conteudo (
    IdConteudo INT NOT NULL IDENTITY PRIMARY KEY,
    IdTipoConteudo TINYINT NOT NULL,
    IdHistoricoVersao INT NOT NULL,
    IdCategoria SMALLINT NOT NULL,
    IdTag SMALLINT NOT NULL,
    Conteudo TEXT NOT NULL,
    Descricao VARCHAR(120) NULL,
    LinkVideo VARCHAR(255) NULL,
    UsuarioCadastro INT NOT NULL,
    DataHoraCadastro DATETIME NOT NULL,
    UsuarioAtualizacao INT NOT NULL,
    DataHoraAtualizacao DATETIME NOT NULL,
    FOREIGN KEY (IdTipoConteudo) REFERENCES TipoConteudo(IdTipoConteudo),
    FOREIGN KEY (IdHistoricoVersao) REFERENCES HistoricoVersao(IdHistoricoVersao),
    FOREIGN KEY (IdCategoria) REFERENCES Categoria(IdCategoria),
    FOREIGN KEY (IdTag) REFERENCES Tag(IdTag)
);

CREATE TABLE Comentario (
    IdComentario INT NOT NULL IDENTITY PRIMARY KEY,
    IdConteudo INT NOT NULL,
    Comentario VARCHAR(120) NOT NULL,
    FOREIGN KEY (IdConteudo) REFERENCES Conteudo(IdConteudo)
);

CREATE TABLE TipoAnexo (
    IdTipoAnexo TINYINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE Anexo (
    IdAnexo INT NOT NULL IDENTITY PRIMARY KEY,
    IdTipoAnexo INT NOT NULL,
    Nome VARCHAR(50) NOT NULL,
    CaminhoArquivo VARCHAR(300) NOT NULL,
    FOREIGN KEY (IdTipoAnexo) REFERENCES TipoAnexo(IdTipoAnexo)
);

CREATE TABLE TipoAvaliacao (
    IdTipoAvaliacao TINYINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE Avaliacao (
    IdAvaliacao INT NOT NULL IDENTITY PRIMARY KEY,
    IdConteudo INT NOT NULL,
    IdTipoAvaliacao INT NOT NULL,
    NotaFinal DECIMAL NOT NULL,
    DataAvaliacao DATE NOT NULL,
    UsuarioCadastro INT NOT NULL,
    DataHoraCadastro DATETIME NOT NULL,
    UsuarioAtualizacao INT NOT NULL,
    DataHoraAtualizacao DATETIME NOT NULL,
    FOREIGN KEY (IdConteudo) REFERENCES Conteudo(IdConteudo),
    FOREIGN KEY (IdTipoAvaliacao) REFERENCES TipoAvaliacao(IdTipoAvaliacao)
);

CREATE TABLE OpcaoSistema (
    IdOpcao INT NOT NULL IDENTITY PRIMARY KEY,
    IdOpcaoSistema INT NULL,
    DescricaoOpcao VARCHAR(120) NOT NULL,
    Rota VARCHAR(80) NOT NULL,
    FOREIGN KEY (IdOpcaoSistema) REFERENCES OpcaoSistema(IdOpcao)
);

CREATE TABLE Permissao (
    IdPermissao SMALLINT NOT NULL IDENTITY PRIMARY KEY,
    Permissao VARCHAR(50) NOT NULL
);

CREATE TABLE PerfilOpcaoSistemaPermissao (
    IdPerfil SMALLINT NOT NULL,
    IdOpcaoSistema INT NOT NULL,
    IdPermissao INT NOT NULL,
    PRIMARY KEY (IdPerfil, IdOpcaoSistema, IdPermissao),
    FOREIGN KEY (IdPerfil) REFERENCES Perfil(IdPerfil),
    FOREIGN KEY (IdOpcaoSistema) REFERENCES OpcaoSistema(IdOpcao),
    FOREIGN KEY (IdPermissao) REFERENCES Permissao(IdPermissao)
);

CREATE TABLE UsuarioComentario (
    IdUsuario INT NOT NULL,
    IdComentario INT NOT NULL,
    PRIMARY KEY (IdUsuario, IdComentario),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario),
    FOREIGN KEY (IdComentario) REFERENCES Comentario(IdComentario)
);

CREATE TABLE ConteudoAnexo (
    IdConteudo INT NOT NULL,
    IdAnexo INT NOT NULL,
    PRIMARY KEY (IdConteudo, IdAnexo),
    FOREIGN KEY (IdConteudo) REFERENCES Conteudo(IdConteudo),
    FOREIGN KEY (IdAnexo) REFERENCES Anexo(IdAnexo)
);
