GO
CREATE TABLE [Sexo]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Valor] VARCHAR(50) NOT NULL
);

GO
CREATE TABLE [TipoPessoa]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Valor] VARCHAR(50) NOT NULL
);

GO
CREATE TABLE [Usuario]
(
	[Codigo] INT NOT NULL PRIMARY KEY, 
        [Nome] VARCHAR(120) NOT NULL,
	[SexoId] INT NOT NULL, 
	[TipoPessoaId] INT NOT NULL,
	FOREIGN KEY ([SexoId]) REFERENCES Sexo([Id]),
	FOREIGN KEY ([TipoPessoaId]) REFERENCES [TipoPessoa]([Id])	
);

GO 
INSERT INTO [Sexo] (Valor) VALUES ('Masculino'),('Feminino'),('Outro');

GO 
INSERT INTO [TipoPessoa] (Valor) VALUES ('Cliente'),('Funcionario');
