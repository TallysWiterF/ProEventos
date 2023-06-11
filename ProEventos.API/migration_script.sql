CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Eventos" (
    "EventoId" INTEGER NOT NULL CONSTRAINT "PK_Eventos" PRIMARY KEY AUTOINCREMENT,
    "Local" TEXT NOT NULL,
    "DataEvento" TEXT NOT NULL,
    "Tema" TEXT NOT NULL,
    "QtdPessoas" INTEGER NOT NULL,
    "Lote" TEXT NOT NULL,
    "ImagemURL" TEXT NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230611174611_EventoMigration', '7.0.5');

COMMIT;

