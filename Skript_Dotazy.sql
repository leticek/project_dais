/*1;1;20;
V�pis v�ech z�znam� tabulky Cvicenec se�azen�ch podle v�ku sestupn�.*/
SELECT *
FROM Cvicenec
ORDER BY vek desc

/*1;2;1;
Vyp�e v�k nejstar��ho cvi�ence*/
SELECT MAX(Cvicenec.vek) as Nejstarsi_cvicenec
FROM Cvicenec

/*1;3;1;
Vyp�e cenu nejlevn�j�� lekce.*/
SELECT MIN(Lekce.cena) as Nejnizsi_cena
FROM Lekce

/*1;4;10;
Vyp�e id_zmeny, id_lekce, id_trenera a druh_zmeny se�azen�ch dle data proveden�*/
SELECT Zmeny.id_zmeny, Zmeny.id_lekce, Zmeny.id_trenera, Zmeny.druh_zmeny
FROM Zmeny
ORDER BY MONTH(Zmeny.cas_zmeny), DAY(Zmeny.cas_zmeny)


/*2;1;5;
Vyp�e v�echny lekce, kter� nepo�aduj� �lenstv� v klubu a jejich cena je mezi 20 v�etn� a 40 v�etn�.*/
SELECT Lekce.id_lekce, Lekce.cena, Lekce.clenstvi
FROM Lekce
WHERE Lekce.clenstvi = 0 AND Lekce.cena BETWEEN 20 AND 40

/*2;2;7;
Vyp�e v�echny mu�e, kte�� jsou star�� 40-ti let v�etn�, nebo mlad�� 30-ti let v�etn�*/
SELECT Cvicenec.jmeno, Cvicenec.prijmeni, Cvicenec.vek, Cvicenec.email
FROM Cvicenec
WHERE Cvicenec.pohlavi LIKE 'Mu�' AND (Cvicenec.vek >= 40 OR cvicenec.vek <= 30)


/*2;3;4;
Vyp�e v�echny tren�ry jejich� jm�no neza��n� p�smenem "J".*/
SELECT Trener.id_trenera, Trener.jmeno, Trener.prijmeni, Trener.email
FROM Trener
WHERE Trener.jmeno NOT LIKE 'J%'

/*2;4;2; 
Vyp�e v�echny lekce, kter� se konaj� v ��jnu a jejich zaokrouhlenou cenu v polsk�ch zlotych(kurz aktu�ln� k 5.12.2019).*/
SELECT Lekce.id_lekce, CEILING(Lekce.cena / 5.97) as Cena_v_Polskych_Zlotych
FROM Lekce
WHERE MONTH(Lekce.cas_konani) = 10

/*3;1;4;
Vyp�e id_trenera v�ech, kte�� netr�nuj� Aerobik(id_treninku = 4).*/
SELECT Trener.id_trenera
FROM Trener
EXCEPT (
			SELECT Trenerova_specializace.id_trenera 
			FROM Trenerova_specializace 
			WHERE Trenerova_specializace.id_treninku = 4
		)

/*3;2;4;
Vyp�e id_trenera v�ech, kte�� netr�nuj� Aerobik(id_treninku = 4).*/
SELECT Trener.id_trenera
FROM Trener
WHERE NOT EXISTS  (
					SELECT Trenerova_specializace.id_trenera 
					FROM Trenerova_specializace 
					WHERE Trener.id_trenera = Trenerova_specializace.id_trenera AND Trenerova_specializace.id_treninku = 4
				  )

/*3;3;4;
Vyp�e id_trenera v�ech, kte�� netr�nuj� Aerobik(id_treninku = 4).*/
SELECT Trener.id_trenera
FROM Trener
WHERE Trener.id_trenera != ALL 
				 (
					SELECT Trenerova_specializace.id_trenera 
					FROM Trenerova_specializace 
					WHERE Trener.id_trenera = Trenerova_specializace.id_trenera AND Trenerova_specializace.id_treninku = 4
				  )
/*3;4;4;
Vyp�e id_trenera v�ech, kte�� netr�nuj� Aerobik(id_treninku = 4).*/
SELECT Trener.id_trenera
FROM Trener
WHERE Trener.id_trenera NOT IN 
				  (
					SELECT Trenerova_specializace.id_trenera 
					FROM Trenerova_specializace 
					WHERE Trener.id_trenera = Trenerova_specializace.id_trenera AND Trenerova_specializace.id_treninku = 4
				  )

/*4;1;1;
Vyp�e pr�m�rn� v�k tren�r�.*/
SELECT AVG(Trener.vek) as Prumerny_vek
FROM Trener

/*4;2;19;
Vyp�e jm�no a p��jmen� Cvicence a kolikr�t se p�ihl�sil na lekci.*/
SELECT Cvicenec.jmeno, Cvicenec.prijmeni, COUNT(*) as Pocet_prihlaseni
FROM Cvicenec
JOIN Prihlaseni_cvicenci ON Prihlaseni_cvicenci.id_cvicence = Cvicenec.id_cvicence AND Prihlaseni_cvicenci.Ucast = 1
GROUP BY Cvicenec.jmeno, Cvicenec.prijmeni

/*4;3;4;
Vyp�e jm�no a p��jmen� tren�r�, kte�� vypsali 3 a v�ce tr�nink�.*/
SELECT Trener.id_trenera, Trener.jmeno, Trener.prijmeni
FROM Trener
JOIN Lekce ON Lekce.id_trenera = Trener.id_trenera
GROUP BY Trener.id_trenera, Trener.jmeno, Trener.prijmeni
HAVING COUNT(*) >= 3

/*4;4;20;
Vyp�e id_lekce a jejich o�ek�vanou tr�bu se�azenou vzestupn�.*/
SELECT Lekce.id_lekce, SUM(Lekce.Cena) AS Trzba_za_Lekci
FROM Lekce
JOIN Prihlaseni_cvicenci ON Prihlaseni_cvicenci.id_lekce = Lekce.id_lekce AND Prihlaseni_cvicenci.Ucast = 1
GROUP BY Lekce.id_lekce
ORDER BY Trzba_za_lekci

/*5;1;9;
Vyp�e id_lekce v�ech u kter�ch prob�hla n�jak� zm�na.*/
SELECT DISTINCT Lekce.id_lekce
FROM Lekce
JOIN Zmeny ON Zmeny.id_lekce = Lekce.id_lekce


/*5;2;9;
Vyp�e id_lekce v�ech u kter�ch prob�hla n�jak� zm�na.*/
SELECT  Lekce.id_lekce
FROM Lekce
WHERE Lekce.id_lekce IN (SELECT Zmeny.id_lekce FROM Zmeny)

/*
5;3;20;
Vyp�e v�echny lekce a k nim po�et proveden�ch zm�n, vyp�ou se i ty lekce beze zm�ny.*/
SELECT Lekce.id_lekce, COUNT(Zmeny.id_lekce) as Pocet_Zmen
FROM Lekce 
LEFT JOIN Zmeny ON Zmeny.id_lekce = Lekce.id_lekce
GROUP BY Lekce.id_lekce

/*5;4;4;
Vyp�e po�et p�ihl�en� na lekci v�ech mu�� star��ch 30 let.*/
SELECT Cvicenec.id_cvicence, Cvicenec.jmeno, Cvicenec.prijmeni, COUNT(*) AS Pocet_prihlaseni
FROM Cvicenec
LEFT JOIN Prihlaseni_cvicenci ON Prihlaseni_cvicenci.id_cvicence = Cvicenec.id_cvicence AND Prihlaseni_cvicenci.Ucast = 1 
WHERE Cvicenec.vek > 30 AND Cvicenec.pohlavi LIKE 'Mu�'
GROUP BY Cvicenec.id_cvicence, Cvicenec.jmeno, Cvicenec.prijmeni


/*6;1;20;
Vyp�e v�echny cvi�ence a jejich po�et p�ihl�en� na silov� tr�nink.*/
SELECT Cvicenec.id_cvicence, Cvicenec.jmeno, Cvicenec.prijmeni,
	(
		SELECT COUNT(*) as pocet
		FROM Prihlaseni_cvicenci
		JOIN Lekce ON Lekce.id_lekce = Prihlaseni_cvicenci.id_lekce
		JOIN Trenerova_specializace ON Trenerova_specializace.id_trenera = Lekce.id_trenera
		WHERE Prihlaseni_cvicenci.id_cvicence = Cvicenec.id_cvicence 
			  AND Prihlaseni_cvicenci.Ucast = 1
			  AND Trenerova_specializace.id_treninku = 5
	) as Pocet_Prihlaseni
FROM Cvicenec

/*6;2;1;
Vyp�e cvi�ence, kter� za lekce utratil nejv�ce i s touto ��stkou.*/
SELECT utrata.id_cvicence, utrata.jmeno, utrata.prijmeni, MAX(utrata.Utrata) as  Nejvetsi_utrata
FROM (
		SELECT Cvicenec.id_cvicence, Cvicenec.jmeno, Cvicenec.prijmeni, SUM(Lekce.cena) as Utrata
		FROM Cvicenec
		JOIN Prihlaseni_cvicenci ON Prihlaseni_cvicenci.id_cvicence = Cvicenec.id_cvicence 
			 AND Prihlaseni_cvicenci.Ucast = 1
		JOIN Lekce ON Lekce.id_lekce = Prihlaseni_cvicenci.id_lekce
		GROUP BY Cvicenec.id_cvicence, Cvicenec.jmeno, Cvicenec.prijmeni
	 ) utrata
GROUP BY utrata.id_cvicence, utrata.jmeno, utrata.prijmeni
HAVING MAX(utrata.Utrata) >= ALL( SELECT u1.Utrata FROM(
															SELECT Cvicenec.id_cvicence, SUM(Lekce.cena) as Utrata
															FROM Cvicenec
															JOIN Prihlaseni_cvicenci ON Prihlaseni_cvicenci.id_cvicence = Cvicenec.id_cvicence 
																AND Prihlaseni_cvicenci.Ucast = 1
															JOIN Lekce ON Lekce.id_lekce = Prihlaseni_cvicenci.id_lekce
															GROUP BY Cvicenec.id_cvicence
														) u1
							    )







