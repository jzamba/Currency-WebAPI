CREATE TABLE "Currencies" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"CurrencyName"	TEXT,
	"CurrencySymbol"	TEXT,
	"CountryName"	TEXT,
	"Continent"	TEXT,
	"BiggestCoin"	TEXT,
	PRIMARY KEY("ID" AUTOINCREMENT)
);