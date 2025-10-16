CREATE TABLE UsuarioStatus (
    Id TINYINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE Perfil (
    Id SMALLINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE Cargo (
    Id SMALLINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL,
    UsuarioCadastro INT NOT NULL,
    DataHoraCadastro DATETIME NOT NULL,
    UsuarioAtualizacao INT,
    DataHoraAtualizacao DATETIME
);

CREATE TABLE Departamento (
    Id SMALLINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL,
    UsuarioCadastro INT NOT NULL,
    DataHoraCadastro DATETIME NOT NULL,
    UsuarioAtualizacao INT,
    DataHoraAtualizacao DATETIME
);

CREATE TABLE Usuario (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    IdUsuarioStatus TINYINT NOT NULL,
    IdPerfil SMALLINT NOT NULL,
    IdCargo SMALLINT NOT NULL,
    IdDepartamento SMALLINT NOT NULL,
    NomeCompleto VARCHAR(120) NOT NULL,
    Email VARCHAR(320) NOT NULL,
    Senha VARCHAR(60) NOT NULL,
    CPF VARCHAR(15) NOT NULL,
    CEP CHAR(8) NOT NULL,
    Rua VARCHAR(50) NOT NULL,
    Cidade VARCHAR(50) NOT NULL,
    UF CHAR(2) NOT NULL,
    NumResidencia VARCHAR(5) NOT NULL,
    Telefone VARCHAR(11) NOT NULL,
    UsuarioCadastro INT NOT NULL,
    DataHoraCadastro DATETIME NOT NULL,
    UsuarioAtualizacao INT,
    DataHoraAtualizacao DATETIME,
    DataAdmissao DATE NOT NULL,
    DataDemissao DATE NOT NULL,
    FOREIGN KEY (IdUsuarioStatus) REFERENCES UsuarioStatus(Id),
    FOREIGN KEY (IdPerfil) REFERENCES Perfil(Id),
    FOREIGN KEY (IdCargo) REFERENCES Cargo(Id),
    FOREIGN KEY (IdDepartamento) REFERENCES Departamento(Id)
);

CREATE TABLE TipoConteudo (
    Id TINYINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE Categoria (
    Id SMALLINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL,
    Descricao VARCHAR(120)
);

CREATE TABLE Tag (
    Id SMALLINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE Conteudo (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    IdTipoConteudo TINYINT NOT NULL,
    IdCategoria SMALLINT NOT NULL,
    IdTag SMALLINT NOT NULL,
    Conteudo TEXT NOT NULL,
    Descricao VARCHAR(120),
    LinkVideo VARCHAR(255),
    UsuarioCadastro INT NOT NULL,
    DataHoraCadastro DATETIME NOT NULL,
    UsuarioAtualizacao INT NOT NULL,
    DataHoraAtualizacao DATETIME NOT NULL,
    FOREIGN KEY (IdTipoConteudo) REFERENCES TipoConteudo(Id),
    FOREIGN KEY (IdCategoria) REFERENCES Categoria(Id),
    FOREIGN KEY (IdTag) REFERENCES Tag(Id)
);

CREATE TABLE HistoricoVersao (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    IdUsuario INT NOT NULL,
    IdConteudo INT NOT NULL,
    DescricaoVersao VARCHAR(255),
    DataHoraCadastro DATETIME NOT NULL,
    UsuarioAtualizacao INT,
    DataHoraAtualizacao DATETIME,
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id),
    FOREIGN KEY (IdConteudo) REFERENCES Conteudo(Id)
);

CREATE TABLE Comentario (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    IdUsuario INT NOT NULL
    Descricao VARCHAR(220) NOT NULL,
    DataHoraCadastro DATETIME NOT NULL,
    UsuarioAtualizacao INT,
    DataHoraAtualizacao DATETIME,
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
);

CREATE TABLE TipoAnexo (
    Id TINYINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE Anexo (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    IdTipoAnexo TINYINT NOT NULL,
    Nome VARCHAR(50) NOT NULL,
    CaminhoArquivo VARCHAR(300) NOT NULL,
    UsuarioCadastro INT NOT NULL,
    DataHoraCadastro DATETIME NOT NULL,
    UsuarioAtualizacao INT,
    DataHoraAtualizacao DATETIME,
    FOREIGN KEY (IdTipoAnexo) REFERENCES TipoAnexo(Id)
);

CREATE TABLE TipoAvaliacao (
    Id TINYINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE Avaliacao (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    IdTipoAvaliacao TINYINT NOT NULL,
    IdUsuario INT NOT NULL,
    NotaFinal DECIMAL NOT NULL,
    DataAvaliacao DATE NOT NULL,
    DataHoraCadastro DATETIME NOT NULL,
    UsuarioAtualizacao INT,
    DataHoraAtualizacao DATETIME,
    FOREIGN KEY (IdTipoAvaliacao) REFERENCES TipoAvaliacao(Id),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
);

CREATE TABLE OpcaoSistema (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    IdOpcaoSistema INT,
    DescricaoOpcao VARCHAR(120) NOT NULL,
    Rota VARCHAR(80) NOT NULL,
    FOREIGN KEY (IdOpcaoSistema) REFERENCES OpcaoSistema(Id)
);

CREATE TABLE Permissao (
    Id SMALLINT NOT NULL IDENTITY PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE PerfilOpcaoSistemaPermissao (
    IdPerfil SMALLINT NOT NULL,
    IdOpcaoSistema INT NOT NULL,
    IdPermissao SMALLINT NOT NULL,
    PRIMARY KEY (IdPerfil, IdOpcaoSistema, IdPermissao),
    FOREIGN KEY (IdPerfil) REFERENCES Perfil(Id),
    FOREIGN KEY (IdOpcaoSistema) REFERENCES OpcaoSistema(Id),
    FOREIGN KEY (IdPermissao) REFERENCES Permissao(Id)
);

CREATE TABLE ConteudoAnexo (
    IdConteudo INT NOT NULL,
    IdAnexo INT NOT NULL,
    PRIMARY KEY (IdConteudo, IdAnexo),
    FOREIGN KEY (IdConteudo) REFERENCES Conteudo(Id),
    FOREIGN KEY (IdAnexo) REFERENCES Anexo(Id)
);

CREATE TABLE Modulo (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    IdAvaliacao INT NOT NULL,
    IdModulo INT,
    Nome VARCHAR(50) NOT NULL,
    UsuarioCadastro INT NOT NULL,
    DataHoraCadastro DATETIME NOT NULL,
    UsuarioAtualizacao INT,
    DataHoraAtualizacao DATETIME,
    FOREIGN KEY (IdAvaliacao) REFERENCES Avaliacao(Id),
    FOREIGN KEY (IdModulo) REFERENCES Modulo(Id)
);

CREATE TABLE ModuloConteudo (
    IdModulo INT NOT NULL,
    IdConteudo INT NOT NULL,
    DataHoraInicio DATETIME NOT NULL,
    DataHoraFim DATETIME,
    PRIMARY KEY (IdModulo, IdConteudo),
    FOREIGN KEY (IdModulo) REFERENCES Modulo(Id),
    FOREIGN KEY (IdConteudo) REFERENCES Conteudo(Id)
);
