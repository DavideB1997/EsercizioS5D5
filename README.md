///TABELLA ANAGRAFICA CREAZIONE

USE [Esercizio5]
GO

/****** Object:  Table [dbo].[ANAGRAFICA]    Script Date: 01/03/2024 16:41:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ANAGRAFICA](
	[IDAnagrafica] [int] IDENTITY(1,1) NOT NULL,
	[Cognome] [varchar](20) NOT NULL,
	[Nome] [varchar](20) NOT NULL,
	[Indirizzo] [varchar](50) NOT NULL,
	[Citta] [varchar](20) NOT NULL,
	[CAP] [varchar](10) NOT NULL,
	[Cod_Fisc] [varchar](16) NULL,
 CONSTRAINT [PK_Anagrafica] PRIMARY KEY CLUSTERED 
(
	[IDAnagrafica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


// POPOLARE 

INSERT INTO ANAGRAFICA (Cognome, Nome, Indirizzo, Citta, CAP, Cod_Fisc)
VALUES
    ('Rossi', 'Mario', 'Via Roma 1', 'Roma', '00100', 'RSSMRA01A01H501A'),
    ('Bianchi', 'Laura', 'Via Garibaldi 2', 'Milano', '20100', 'BNCMRA02A02H502B'),
    ('Verdi', 'Giuseppe', 'Corso Italia 3', 'Napoli', '80100', 'VRDGPP03A03H503C'),
    ('Ferrari', 'Anna', 'Piazza Duomo 4', 'Torino', '10100', 'FRRNNA04A04H504D'),
    ('Martini', 'Luigi', 'Via Venezia 5', 'Firenze', '50100', 'MRTLGI05A05H505E'),
    ('Russo', 'Giovanna', 'Corso Magenta 6', 'Bologna', '40100', 'RSSGVN06A06H506F'),
    ('Gallo', 'Paola', 'Piazza San Marco 7', 'Venezia', '30100', 'GLLPLA07A07H507G'),
    ('Conti', 'Marco', 'Via Garibaldi 8', 'Genova', '16100', 'CNTMRC08A08H508H'),
    ('De Luca', 'Antonella', 'Corso Vittorio Emanuele 9', 'Palermo', '90100', 'DLANTN09A09H509I'),
    ('Costa', 'Sara', 'Piazza Navona 10', 'Roma', '00186', 'CSTSRA10A10H510L'),
    ('Ferraro', 'Carla', 'Via Nazionale 11', 'Milano', '20122', 'FRRCRL11A11H511M'),
    ('Esposito', 'Alessandro', 'Corso Umberto 12', 'Napoli', '80122', 'ESPAAS12A12H512N'),
    ('Barbieri', 'Elena', 'Piazza del Popolo 13', 'Firenze', '50123', 'BRBELN13A13H513O'),
    ('Rizzo', 'Giorgio', 'Via della Repubblica 14', 'Bologna', '40123', 'RZZGRO14A14H514P'),
    ('Moretti', 'Roberta', 'Corso Buenos Aires 15', 'Torino', '10123', 'MRTBRT15A15H515Q'),
    ('Colombo', 'Enrico', 'Piazza Duca d'Aosta 16', 'Milano', '20123', 'CLBENC16A16H516R'),
    ('Romano', 'Federica', 'Via del Corso 17', 'Roma', '00185', 'RMNFDC17A17H517S'),
    ('Marchetti', 'Simone', 'Piazza Santa Croce 18', 'Firenze', '50124', 'MRCSMN18A18H518T'),
    ('Ferri', 'Serena', 'Corso Vittorio Veneto 19', 'Palermo', '90123', 'FRRSRN19A19H519U'),
    ('Vitale', 'Giovanni', 'Via Roma 20', 'Napoli', '80123', 'VTLGVN20A20H520V');




// TABELLA TIPO_VIOLAZIONE

  USE [Esercizio5]
GO

/****** Object:  Table [dbo].[TIPO_VIOLAZIONE]    Script Date: 01/03/2024 16:47:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TIPO_VIOLAZIONE](
	[IDViolazione] [int] IDENTITY(1,1) NOT NULL,
	[Descrizione] [varchar](100) NULL,
 CONSTRAINT [PK_TIPO_VIOLAZIONE] PRIMARY KEY CLUSTERED 
(
	[IDViolazione] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

// POPOLARE 

INSERT INTO TIPO_VIOLAZIONE (Descrizione)
VALUES
    ('Eccesso di velocità'),
    ('Mancato rispetto del semaforo rosso'),
    ('Guida sotto l''effetto di sostanze stupefacenti'),
    ('Manutenzione insufficiente del veicolo'),
    ('Guida senza cintura di sicurezza'),
    ('Utilizzo del telefono cellulare durante la guida'),
    ('Guida contromano'),
    ('Attraversamento pedonale non rispettato'),
    ('Guida in stato di ebbrezza'),
    ('Mancato rispetto delle norme sul parcheggio');



// VERBALE TABELLA

USE [Esercizio5]
GO

/****** Object:  Table [dbo].[VERBALE]    Script Date: 01/03/2024 16:48:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VERBALE](
	[IDVerbale] [int] IDENTITY(1,1) NOT NULL,
	[DataViolazione] [date] NOT NULL,
	[IndirizzoViolazione] [varchar](50) NOT NULL,
	[NominativoAgente] [varchar](50) NOT NULL,
	[DataTrascrizioneVerbale] [date] NOT NULL,
	[Importo] [money] NOT NULL,
	[DecurtamentoPunti] [smallint] NULL,
	[IDAnagrafica] [int] NOT NULL,
	[IDViolazione] [int] NOT NULL,
 CONSTRAINT [PK_VERBALE] PRIMARY KEY CLUSTERED 
(
	[IDVerbale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[VERBALE]  WITH CHECK ADD  CONSTRAINT [FK_VERBALE_ANAGRAFICA] FOREIGN KEY([IDAnagrafica])
REFERENCES [dbo].[ANAGRAFICA] ([IDAnagrafica])
GO

ALTER TABLE [dbo].[VERBALE] CHECK CONSTRAINT [FK_VERBALE_ANAGRAFICA]
GO

ALTER TABLE [dbo].[VERBALE]  WITH CHECK ADD  CONSTRAINT [FK_VERBALE_TIPO_VIOLAZIONE] FOREIGN KEY([IDViolazione])
REFERENCES [dbo].[TIPO_VIOLAZIONE] ([IDViolazione])
GO

ALTER TABLE [dbo].[VERBALE] CHECK CONSTRAINT [FK_VERBALE_TIPO_VIOLAZIONE]
GO



//POPOLA


INSERT INTO VERBALE (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IDAnagrafica, IDViolazione)
VALUES
    ('2023-01-05', 'Via Roma 1', 'Mario Rossi', '2023-01-06', 50.00, 2, 1, 1),
    ('2023-02-10', 'Via Garibaldi 2', 'Laura Bianchi', '2023-02-11', 100.00, 3, 2, 2),
    ('2023-03-15', 'Corso Italia 3', 'Giuseppe Verdi', '2023-03-16', 75.00, 1, 3, 3),
    ('2023-04-20', 'Piazza Duomo 4', 'Anna Ferrari', '2023-04-21', 120.00, 4, 4, 4),
    ('2023-05-25', 'Via Venezia 5', 'Luigi Martini', '2023-05-26', 90.00, 2, 5, 5),
    ('2023-06-30', 'Corso Magenta 6', 'Giovanna Russo', '2023-07-01', 60.00, 1, 6, 6),
    ('2023-07-05', 'Piazza San Marco 7', 'Paola Gallo', '2023-07-06', 70.00, 2, 7, 7),
    ('2023-08-10', 'Via Garibaldi 8', 'Marco Conti', '2023-08-11', 85.00, 3, 8, 8),
    ('2023-09-15', 'Corso Vittorio Emanuele 9', 'Antonella De Luca', '2023-09-16', 110.00, 4, 9, 9),
    ('2023-10-20', 'Piazza Navona 10', 'Sara Costa', '2023-10-21', 95.00, 2, 10, 10),
    ('2023-11-25', 'Via Nazionale 11', 'Carla Ferraro', '2023-11-26', 80.00, 1, 11, 11),
    ('2023-12-30', 'Corso Umberto 12', 'Alessandro Esposito', '2023-12-31', 130.00, 3, 12, 12),
    ('2024-01-05', 'Piazza del Popolo 13', 'Elena Barbieri', '2024-01-06', 70.00, 2, 13, 13),
    ('2024-02-10', 'Via della Repubblica 14', 'Giorgio Rizzo', '2024-02-11', 110.00, 4, 14, 14),
    ('2024-03-15', 'Corso Buenos Aires 15', 'Roberta Moretti', '2024-03-16', 75.00, 1, 15, 15),
    ('2024-04-20', 'Piazza Duca d''Aosta 16', 'Enrico Colombo', '2024-04-21', 90.00, 2, 16, 16),
    ('2024-05-25', 'Via del Corso 17', 'Federica Romano', '2024-05-26', 100.00, 3, 17, 17),
    ('2024-06-30', 'Piazza Santa Croce 18', 'Simone Marchetti', '2024-07-01', 120.00, 4, 18, 18),
    ('2024-07-05', 'Corso Vittorio Veneto 19', 'Serena Ferri', '2024-07-06', 85.00, 2, 19, 19),
    ('2024-08-10', 'Via Roma 20', 'Giovanni Vitale', '2024-08-11', 95.00, 1, 20, 20);

